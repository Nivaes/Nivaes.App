//namespace Nivaes.App.Shared.SourceGenerator
//{
//    using System.Collections.Generic;
//    using System.Linq;
//    using System.Reflection;
//    using System.Text;
//    using Microsoft.CodeAnalysis;
//    using Microsoft.CodeAnalysis.CSharp.Syntax;
//    using Microsoft.CodeAnalysis.Text;

//    [Generator(LanguageNames.CSharp)]
//    public class ModelGenerator
//        : IIncrementalGenerator
//    {
//        private const string TargetAttributeMetadataName = "Nivaes.App.DataModelAttribute";

//        public void Initialize(IncrementalGeneratorInitializationContext context)
//        {
//#if DEBUG
//            System.Diagnostics.Debugger.Launch();
//#endif

//            // Use ForAttributeWithMetadataName to find classes annotated with the target attribute
//            var provider = context.SyntaxProvider.ForAttributeWithMetadataName(
//                    TargetAttributeMetadataName,
//                    predicate: static (node, _) =>
//                    {
//                        return node is ClassDeclarationSyntax cds && cds.AttributeLists.Count > 0;
//                    },
//                    transform: static (attrCtx, _) =>
//                    {
//                        // attrCtx.TargetNode is the node that has the attribute (syntax-level)
//                        if (attrCtx.TargetNode is ClassDeclarationSyntax classDecl)
//                        {
//                            var classSymbol = attrCtx.SemanticModel.GetDeclaredSymbol(classDecl) as INamedTypeSymbol;
//                            return classSymbol;
//                        }

//                        return null;
//                    })
//                .Where(static s => s is not null)
//                .Select((s, _) => (INamedTypeSymbol)s!);

//            var allMatches = provider.Collect();

//            context.RegisterSourceOutput(allMatches, (spc, list) =>
//            {
//                var distinct = list.Distinct(SymbolEqualityComparer.Default).ToArray();
//                if (distinct.Length == 0)
//                    return;

//                // Use the containing assembly name of the first symbol for namespace, fallback to "Generated"
//                var assemblyName = distinct[0].ContainingAssembly?.Name ?? "Generated";

//                var sb = new StringBuilder();
//                sb.AppendLine("using System;");
//                sb.AppendLine();
//                sb.AppendLine($"namespace Nivaes.App.Helpers");
//                sb.AppendLine("{");
//                sb.AppendLine($"    public partial class {assemblyName}");
//                sb.AppendLine("    {");
//                sb.AppendLine("        public static Type[] GetAttributedTypes()");
//                sb.AppendLine("        {");
//                sb.AppendLine("            return new Type[]");
//                sb.AppendLine("            {");

//                foreach (var sym in distinct)
//                {
//                    // Use fully-qualified name (global:: allowed) to avoid ambiguous references
//                    var fullName = sym.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
//                    sb.AppendLine($"                typeof({fullName}),");
//                }

//                sb.AppendLine("            };");
//                sb.AppendLine("        }");
//                sb.AppendLine("    }");
//                sb.AppendLine("}");

//                spc.AddSource("Nivaes.App.Model.Generated.cs", SourceText.From(sb.ToString(), Encoding.UTF8));
//            });
//        }
//    }
//}
