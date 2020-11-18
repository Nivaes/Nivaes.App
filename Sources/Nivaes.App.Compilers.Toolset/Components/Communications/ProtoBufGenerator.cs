namespace Nivaes.App
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Text;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.CodeAnalysis.Text;

    [Generator]
    public class ProtoBufGenerator
        : ISourceGenerator
    {
        private readonly DebuggerLog mDebuggerLog = new DebuggerLog();

        public ProtoBufGenerator()
        {
            mDebuggerLog.DebugAppendLog("Create - ProtoBufGenerator");
        }

        public void Initialize(GeneratorInitializationContext context)
        {
            mDebuggerLog.DebugAppendLog("Initialize");

#if DEBUG
            //System.Diagnostics.Debugger.Launch();
#endif
            context.RegisterForSyntaxNotifications(() => new SyntaxReceiver(mDebuggerLog));
        }

        public void Execute(GeneratorExecutionContext context)
        {
            mDebuggerLog.DebugAppendLog("Execute");
#if DEBUG
            //System.Diagnostics.Debugger.Launch();
#endif

            mDebuggerLog.DebugAppendLog($"INI - Generating");
            try
            {
                var classes = (context.SyntaxReceiver as SyntaxReceiver)?.Classes;
                if (classes is object)
                {
                    foreach (var classSyntax in classes) Execute(context, classSyntax);
                }
            }
            catch (Exception ex)
            {
                mDebuggerLog.DebugAppendLog(ex.ToString());
            }

            mDebuggerLog.DebugAppendLog("FIN - Generating");
        }

        private void Execute(GeneratorExecutionContext context, ClassDeclarationSyntax classSyntax)
        {
            StringBuilder sourceBuilder = new StringBuilder(@"
            using System;
            namespace Nivaes.Compilers.ProtoBuf
            {
                public static class ProtoBufHelper
                {
                    public static void AddProtoBuf() 
                    {
                        Console.WriteLine(""Hello from generated code!"");
                        Console.WriteLine(""The following syntax trees existed in the compilation that created this program:"");
            ");

            //// using the context, get a list of syntax trees in the users compilation
            //IEnumerable<SyntaxTree> syntaxTrees = context.Compilation.SyntaxTrees;

            //// add the filepath of each tree to the class we're building
            //foreach (SyntaxTree tree in syntaxTrees)
            //{
            //    mDebuggerLog.DebugAppendLog($"syntaxTrees: {tree.FilePath}");
            //    sourceBuilder.AppendLine($@"Console.WriteLine(@"" - {tree.FilePath}"");");
            //}

            // finish creating the source to inject
            sourceBuilder.Append(@"
                    }
                }
            }");
            //System.Diagnostics.Debugger.Launch();


            context.AddSource("ProtoBufHelper.Generated.cs", SourceText.From(sourceBuilder.ToString(), Encoding.UTF8));

            mDebuggerLog.DebugSaveFile($"ProtoBufHelper.Generated-{DateTime.Now.Ticks}.cs", sourceBuilder.ToString());
        }

        /// <summary>
        /// Created on demand before each generation pass
        /// </summary>
        private class SyntaxReceiver : ISyntaxReceiver
        {
            private DebuggerLog mDebuggerLog;

            //public List<InterfaceDeclarationSyntax> Interfaces { get; } = new List<InterfaceDeclarationSyntax>();

            public List<ClassDeclarationSyntax> Classes { get; } = new List<ClassDeclarationSyntax>();

            public SyntaxReceiver(DebuggerLog debuggerLog)
            {
                mDebuggerLog = debuggerLog;
            }

            /// <summary>
            /// Called for every syntax node in the compilation, we can inspect the nodes and save any information useful for generation
            /// </summary>
            public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
            {
                if (syntaxNode is CompilationUnitSyntax compilationUnitSyntax)
                //&& compilationUnitSyntax.AttributeLists.Any())
                {
                    mDebuggerLog.DebugAppendLog($"OnVisitSyntaxNode.CompilationUnitSyntax:");
                    mDebuggerLog.DebugAppendLog(syntaxNode.GetText().ToString());
                    mDebuggerLog.DebugAppendLog("---------------------------------------------------------------");
                }
                if (syntaxNode is NamespaceDeclarationSyntax camespaceDeclarationSyntax)
                //&& compilationUnitSyntax.AttributeLists.Any())
                {
                    mDebuggerLog.DebugAppendLog($"OnVisitSyntaxNode.NamespaceDeclarationSyntax:");
                    mDebuggerLog.DebugAppendLog(syntaxNode.GetText().ToString());
                    mDebuggerLog.DebugAppendLog("---------------------------------------------------------------");
                }
                else if (syntaxNode is InterfaceDeclarationSyntax interfaceDeclarationSyntax)
                //&& interfaceDeclarationSyntax.AttributeLists.Any())
                {
                    //Interfaces.Add(interfaceDeclarationSyntax);
                    mDebuggerLog.DebugAppendLog($"OnVisitSyntaxNode.InterfaceDeclarationSyntax:");
                    mDebuggerLog.DebugAppendLog(syntaxNode.GetText().ToString());
                    mDebuggerLog.DebugAppendLog("---------------------------------------------------------------");
                }
                else if (syntaxNode is FieldDeclarationSyntax fieldDeclarationSyntax)
                //&& fieldDeclarationSyntax.AttributeLists.Any())
                {
                    //CandidateFields.Add(fieldDeclarationSyntax);
                    mDebuggerLog.DebugAppendLog($"OnVisitSyntaxNode.FieldDeclarationSyntax:");
                    mDebuggerLog.DebugAppendLog(syntaxNode.GetText().ToString());
                    mDebuggerLog.DebugAppendLog("---------------------------------------------------------------");
                }
                else if (syntaxNode is ClassDeclarationSyntax classDeclarationSyntax)
                //&& fieldDeclarationSyntax.AttributeLists.Any())
                {
                    Classes.Add(classDeclarationSyntax);
                    mDebuggerLog.DebugAppendLog($"OnVisitSyntaxNode.ClassDeclarationSyntax:");
                    mDebuggerLog.DebugAppendLog(syntaxNode.GetText().ToString());
                    mDebuggerLog.DebugAppendLog("---------------------------------------------------------------");
                }
                else
                {
                    mDebuggerLog.DebugAppendLog($"OnVisitSyntaxNode: {syntaxNode.GetType().Name}");
                    mDebuggerLog.DebugAppendLog(syntaxNode.GetText().ToString());
                    mDebuggerLog.DebugAppendLog("---------------------------------------------------------------");
                }
            }
        }

        ///// <summary>
        ///// Created on demand before each generation pass
        ///// </summary>
        //class SyntaxReceiver : ISyntaxReceiver
        //{
        //    private DebuggerLog mDebuggerLog;

        //    public List<FieldDeclarationSyntax> CandidateFields { get; } = new List<FieldDeclarationSyntax>();

        //    public SyntaxReceiver(DebuggerLog debuggerLog)
        //    {
        //        mDebuggerLog = debuggerLog;
        //    }

        //    /// <summary>
        //    /// Called for every syntax node in the compilation, we can inspect the nodes and save any information useful for generation
        //    /// </summary>
        //    public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
        //    {
        //        System.Diagnostics.Debugger.Launch();

        //        // any field with at least one attribute is a candidate for property generation
        //        if (syntaxNode is FieldDeclarationSyntax fieldDeclarationSyntax
        //            && fieldDeclarationSyntax.AttributeLists.Count > 0)
        //        {
        //            CandidateFields.Add(fieldDeclarationSyntax);
        //        }
        //    }
        //}

        private class DebuggerLog
        {
            private string trazeFileName = $@"E:\Traze\ProtoBufGenerator-{DateTime.Now.Ticks}.log";

            [Conditional("DEBUG")]
            public void DebugSaveFile(string fileName, string contentFile)
            {
#if DEBUG
                try
                {
                    File.AppendAllText(Path.Combine("E:\\Traze", fileName), contentFile);
                }
                catch
                {
                    //System.Diagnostics.Debugger.Launch();
                }
#endif
            }

            [Conditional("DEBUG")]
            public void DebugAppendLog(string message)
            {
#if DEBUG
                try
                {
                    File.AppendAllText(trazeFileName, $"{DateTime.Now:T} {message}  \n");
                }
                catch
                {
                    //System.Diagnostics.Debugger.Launch();
                }
#endif
            }
        }

    }
}
