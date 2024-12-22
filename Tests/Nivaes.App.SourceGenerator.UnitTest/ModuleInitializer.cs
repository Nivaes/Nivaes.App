namespace Nivaes.App.SourceGenerator.UnitTest
{
    using System.Runtime.CompilerServices;
    using VerifyTests;

    public static class ModuleInitializer
    {
        [ModuleInitializer]
        public static void Init()
        {
            VerifySourceGenerators.Initialize();
        }
    }
}
