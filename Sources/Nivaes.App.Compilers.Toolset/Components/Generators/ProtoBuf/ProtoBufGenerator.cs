namespace Nivaes.App.Compilers.Toolset.Components.Generators.ProtoBuf
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.CodeAnalysis.Text;
    using Nivaes.App.Compilers.Toolset.Components.Generators.ProtoBuf.Extensions;

    [Generator(LanguageNames.CSharp)]
    public class ProtoBufGenerator
        : IIncrementalGenerator
    {
        private readonly List<ClassDeclarationSyntax> classes = new();

        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            //#if DEBUG
            //            System.Diagnostics.Debugger.Launch();
            //#endif
            var pipeline = context.SyntaxProvider.ForAttributeWithMetadataName(
                "ProtoBuf.ProtoContractAttribute",
                predicate: static (_, _) => true,
                transform: (context, _) =>
                {
                    //#if DEBUG
                    //                    System.Diagnostics.Debugger.Break();
                    //#endif

                    if (context.Attributes.Any(x => x.AttributeClass?.Name == "ProtoContractAttribute")
                            && context.TargetNode is ClassDeclarationSyntax classDeclarationSyntax)
                    {
                        classes.Add(classDeclarationSyntax);

                        if (classes.Count == 1)
                            return context.SemanticModel.Compilation.AssemblyName;
                    }

                    return null;
                }).Where(static m => m is not null);

            context.RegisterSourceOutput(pipeline, (context, model) =>
            {
                //#if DEBUG
                //                System.Diagnostics.Debugger.Break();
                //#endif

                var assemblyName = model;

                StringBuilder sourceBuilder = new StringBuilder(@$"
                            namespace {assemblyName}.Helpers
                            {{
                                using System;
                                using Nivaes.App;

                                public static class ProtoBufRegisterHelper
                                {{
                                    public static void RegisterProtoBufTypes() 
                                    {{
                            ");

                foreach (var classSyntax in classes.Distinct())
                {
                    sourceBuilder.AppendLine($"ProtoBufHelper.RegisterType(typeof({classSyntax.GetFullName()}));");
                }

                sourceBuilder.Append(@"
                                                    }
                                                }
                                            }");

                context.AddSource("Nivaes.App.Compilers.Toolset.ProtoBufHelper.Generated.cs", SourceText.From(sourceBuilder.ToString(), Encoding.UTF8));
            });
        }
    }
}
