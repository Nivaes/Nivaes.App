namespace Nivaes.App.Shared.UnitTest
{
    using FluentAssertions;
    using Nivaes.App.Shared.Test;
    using Xunit;
    using Xunit.Abstractions;

    [Trait("TestType", "Unit")]
    public sealed class LittleResultSerializationTest
        : IClassFixture<ProtoBufRegisterFixture>
    {
        private readonly ITestOutputHelper mTestOutputHelper;

        public LittleResultSerializationTest(ITestOutputHelper testOutputHelper)
        {
            mTestOutputHelper = testOutputHelper;
        }

        [Fact]
        public void LittleResultResultProtoBufSerialize1()
        {
            var appTestResult1 = new LittleResult
            {
                EndValue = true
            };

            var buffer = ProtoBufHelper.Serialize(appTestResult1);
            buffer.Should().NotBeNull();

            mTestOutputHelper.WriteLine($"Serialization size: {buffer.Length}");

            var appTestResult2 = ProtoBufHelper.Deserialize<LittleResult>(buffer);

            appTestResult2.Should().NotBeNull();
            appTestResult2.EndValue.Should().Be(appTestResult1.EndValue);
        }

        [Fact]
        public void LittleResultResultProtoBufSerialize2()
        {
            var appTestResult1 = new LittleResult
            {
                EndValue = false
            };

            var buffer = ProtoBufHelper.Serialize(appTestResult1);
            buffer.Should().NotBeNull();

            mTestOutputHelper.WriteLine($"Serialization size: {buffer.Length}");

            var appTestResult2 = ProtoBufHelper.Deserialize<LittleResult>(buffer);

            appTestResult2.Should().NotBeNull();
            appTestResult2.EndValue.Should().Be(appTestResult1.EndValue);
        }
    }
}
