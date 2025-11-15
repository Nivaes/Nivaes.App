//namespace Nivaes.App.SourceGenerator.UnitTest.UnitTest.Generatos.ProtoBuf
//{
//    using System.Threading.Tasks;
//    using LightProto;
//    using Microsoft.CodeAnalysis;
//    using Microsoft.CodeAnalysis.CSharp;
//    using Nivaes.App.SourceGenerator.Components.Generators.ProtoBuf;

//    internal class ModelGeneratorTestHelper
//    {
//        protected ModelGeneratorTestHelper()
//        {
//        }

//        public static Task Verify(string source)
//        {
//            // Parse the provided string into a C# syntax tree
//            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(source);

//            // Create a Roslyn compilation for the syntax tree.
//            CSharpCompilation compilation = CSharpCompilation.Create(
//                assemblyName: "Tests",
//                syntaxTrees: [syntaxTree],
//                references:
//                [
//                    MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
//                    MetadataReference.CreateFromFile(typeof(ModelGeneratorTestHelper).Assembly.Location),
//                    MetadataReference.CreateFromFile(typeof(ProtoContractAttribute).Assembly.Location),
//                ]);


//            // Create an instance of our EnumGenerator incremental source generator
//            var generator = new ModelGenerator();

//            // The GeneratorDriver is used to run our generator against a compilation
//            GeneratorDriver driver = CSharpGeneratorDriver.Create(generator);

//            // Run the source generator!
//            driver = driver.RunGenerators(compilation);

//            // Use verify to snapshot test the source generator output!
//            return Verifier
//                .Verify(driver)
//                .UseDirectory("Snapshots");
//        }
//    }
//}
