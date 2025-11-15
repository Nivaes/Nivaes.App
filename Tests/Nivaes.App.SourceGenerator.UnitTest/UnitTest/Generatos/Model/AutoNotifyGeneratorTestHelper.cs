namespace Nivaes.App.SourceGenerator.UnitTest
{
    using System.Threading.Tasks;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;

    internal class AutoNotifyGeneratorTestHelper
    {
        protected AutoNotifyGeneratorTestHelper()
        {
        }

        public static Task Verify(string source)
        {
            // Parse the provided string into a C# syntax tree
            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(source);

            // Create a Roslyn compilation for the syntax tree.
            CSharpCompilation compilation = CSharpCompilation.Create(
                assemblyName: "Tests",
                syntaxTrees: [syntaxTree],
                references:
                [
                    MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
                    MetadataReference.CreateFromFile(typeof(AutoNotifyGeneratorTestHelper).Assembly.Location),
                    MetadataReference.CreateFromFile(typeof(IModel).Assembly.Location),
                ]);


            // Create an instance of our EnumGenerator incremental source generator
            var generator = new AutoNotifyGenerator();

            // The GeneratorDriver is used to run our generator against a compilation
            GeneratorDriver driver = CSharpGeneratorDriver.Create(generator);

            // Run the source generator!
            driver = driver.RunGenerators(compilation);

            // Use verify to snapshot test the source generator output!
            return Verifier
                .Verify(driver)
                .UseDirectory("Snapshots");
        }
    }
}
