namespace Nivaes.App.SourceGenerator.UnitTest
{
    public class AutoNotifyGeneratorUnitTest
    {
        [Fact]
        public Task ProtoBufGeneratorTest()
        {
            var source = @"
               namespace Nivaes.App.Shared.Test
{
    using System;
    using System.Runtime.Serialization;
    using ProtoBuf;

    public sealed class ModelTest1
        : IModel
    {
        [AutoNotify]
        private Guid guidData;

        [AutoNotify]
        private string personalName;

        [AutoNotify]
        private string familyName;
    }
}
";

            return AutoNotifyGeneratorTestHelper.Verify(source);
        }
    }
}
