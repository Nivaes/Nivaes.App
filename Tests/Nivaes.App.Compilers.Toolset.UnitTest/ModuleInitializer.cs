namespace Nivaes.App.Compilers.Toolset.UnitTest
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
