using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace Nivaes.App.Shared.SourceGenerator;

[Generator]
public class AutoNotifyGenerator
    : IIncrementalGenerator
{
    private const string TargetAttributeMetadataName = "Nivaes.App.AutoNotifyAttribute";

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
//#if DEBUG
//        System.Diagnostics.Debugger.Launch();
//#endif

        var provider = context.SyntaxProvider.ForAttributeWithMetadataName(
             TargetAttributeMetadataName,
             predicate: static (node, _) =>
             {
                 return node is VariableDeclaratorSyntax;
             },
             transform: static (attrCtx, _) =>
             {
                 if (attrCtx.TargetNode is VariableDeclaratorSyntax variableDecl)
                 {
                     var model = attrCtx.SemanticModel;
                     if (model.GetDeclaredSymbol(variableDecl) is IFieldSymbol symbol)
                     {
                         return [symbol];
                     }
                 }
                 return Array.Empty<IFieldSymbol>();
             })
            .Where(static s => s is not null)
            .SelectMany((symbols, _) => symbols);

        context.RegisterSourceOutput(provider, GenerateProperty);
    }

    private static void GenerateProperty(SourceProductionContext context, IFieldSymbol? fieldSymbol)
    {
        var classSymbol = fieldSymbol!.ContainingType;
        var namespaceName = classSymbol.ContainingNamespace.ToDisplayString();

        // Obtener nombre de la propiedad
        var attr = fieldSymbol.GetAttributes()
            .FirstOrDefault(a => a.AttributeClass?.ToDisplayString() == TargetAttributeMetadataName);

        var nameFromAttr = GetAttributeStringValue(attr, "PropertyName");

        var name = nameFromAttr ?? ToPascalCase(fieldSymbol.Name);

        var fieldType = fieldSymbol.Type.ToDisplayString();
        var fieldName = fieldSymbol.Name;
        var className = classSymbol.Name;

        // Generar archivo
        var source = $@"
#nullable enable
#pragma warning disable 1591
using System.ComponentModel;
using Nivaes.App;

namespace {namespaceName}
{{
    public partial class {className} : Model, INotifyPropertyChanged
    {{
        public {fieldType} {name}
        {{
            get => {fieldName};
            set => SetProperty(ref {fieldName}, value);
        }}
    }}
}}
";
        context.AddSource($"{className}_{name}.g.cs", SourceText.From(source, Encoding.UTF8));
    }

    private static string? GetAttributeStringValue(AttributeData? attr, string namedKey)
    {
        if (attr is null) return null;

        // 1) Named argument, e.g. [AutoNotify(PropertyName = "X")]
        foreach (var kv in attr.NamedArguments)
        {
            if (kv.Key == namedKey)
                return kv.Value.Value as string;
        }

        // 2) Positional constructor argument fallback (if attribute uses ctor param)
        if (attr.ConstructorArguments.Length > 0)
        {
            // You might need to map the constructor position depending on your attribute signature.
            var tc = attr.ConstructorArguments[0];
            return tc.Value as string;
        }

        return null;
    }


    private static string ToPascalCase(string fieldName)
    {
        var name = fieldName.StartsWith("_") ? fieldName[1..] : fieldName;
        return char.ToUpper(name[0]) + name[1..];
    }
}
