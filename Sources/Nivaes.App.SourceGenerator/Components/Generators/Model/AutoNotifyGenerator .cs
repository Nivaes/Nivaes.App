using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace Nivaes.App.SourceGenerator;

[Generator]
public class AutoNotifyGenerator : IIncrementalGenerator
{
    private const string TargetAttributeMetadataName = "Nivaes.App.AutoNotifyAttribute";

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        // Filtrar solo nodos que son campos con atributos
        var fieldsWithAttributes = context.SyntaxProvider
            .CreateSyntaxProvider(
                predicate: static (node, _) =>
                    node is FieldDeclarationSyntax { AttributeLists.Count: > 0 },
                transform: static (ctx, _) =>
                {
                    var field = (FieldDeclarationSyntax)ctx.Node;
                    var model = ctx.SemanticModel;

                    var variables = field.Declaration.Variables;

                    // Se devuelven todos los campos del FieldDeclarationSyntax
                    return variables.Select(v =>
                    {
                        var symbol = model.GetDeclaredSymbol(v) as IFieldSymbol;
                        return symbol;
                    }).Where(s => s != null);
                }
            )
            .SelectMany((symbols, _) => symbols!);

        // Filtrar solo los campos que tengan [AutoNotify]
        var autoNotifyFields = fieldsWithAttributes
            .Where(static f =>
                f!.GetAttributes().Any(a =>
                    a.AttributeClass?.ToDisplayString() == TargetAttributeMetadataName));

        context.RegisterSourceOutput(autoNotifyFields, GenerateProperty);
    }

    private void GenerateProperty(SourceProductionContext context, IFieldSymbol? fieldSymbol)
    {
        var classSymbol = fieldSymbol!.ContainingType;
        var namespaceName = classSymbol.ContainingNamespace.ToDisplayString();

        // Obtener nombre de la propiedad
        var attr = fieldSymbol.GetAttributes()
            .First(a => a.AttributeClass?.ToDisplayString() == TargetAttributeMetadataName);

        var name = attr.NamedArguments.FirstOrDefault(k => k.Key == "PropertyName").Value.Value as string
                   ?? ToPascalCase(fieldSymbol.Name);

        var fieldType = fieldSymbol.Type.ToDisplayString();
        var fieldName = fieldSymbol.Name;
        var className = classSymbol.Name;

        // Generar archivo
        var source = $@"
#nullable enable
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

    private static string ToPascalCase(string fieldName)
    {
        var name = fieldName.StartsWith("_") ? fieldName[1..] : fieldName;
        return char.ToUpper(name[0]) + name[1..];
    }
}
