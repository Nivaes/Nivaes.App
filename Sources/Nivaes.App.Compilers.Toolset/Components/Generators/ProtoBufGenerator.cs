namespace Nivaes.App
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.CodeAnalysis.Text;

    [Generator]
    public class ProtoBufGenerator
        : ISourceGenerator
    {
        public ProtoBufGenerator()
        {
        }

        public void Initialize(GeneratorInitializationContext context)
        {
            context.RegisterForSyntaxNotifications(() => new SyntaxReceiver());
        }

        public void Execute(GeneratorExecutionContext context)
        {
            var classes = (context.SyntaxReceiver as SyntaxReceiver)?.Classes;

            if (classes is object)
            {
                StringBuilder sourceBuilder = new StringBuilder(@$"
                    namespace {context.Compilation.AssemblyName}.Runtime.CompilerServices
                    {{
                        using System;
                        using Nivaes.App;

                        public static class ProtoBufRegisterHelper
                        {{
                            public static void RegisterProtoBufTypes() 
                            {{
                    ");

                foreach (var classSyntax in classes)
                {
                    sourceBuilder.AppendLine($"ProtoBufHelper.RegisterType(typeof({classSyntax.GetFullName()}));");
                }

                sourceBuilder.Append(@"
                            }
                        }
                    }");

                context.AddSource("ProtoBufHelper.Generated.cs", SourceText.From(sourceBuilder.ToString(), Encoding.UTF8));
            }
        }

        /// <summary>
        /// Created on demand before each generation pass
        /// </summary>
        private class SyntaxReceiver
            : ISyntaxReceiver
        {
            public List<ClassDeclarationSyntax> Classes { get; } = new List<ClassDeclarationSyntax>();

            /// <summary>
            /// Called for every syntax node in the compilation, we can inspect the nodes and save any information useful for generation
            /// </summary>
            public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
            {
                if (syntaxNode is ClassDeclarationSyntax classDeclarationSyntax)
                {
                    if (classDeclarationSyntax.AttributeLists.Any(x => x.Attributes.Any(a => a.Name.ToString().Equals("ProtoContract"))))
                    {
                        Classes.Add(classDeclarationSyntax);
                    }
                }
            }
        }
    }
}
