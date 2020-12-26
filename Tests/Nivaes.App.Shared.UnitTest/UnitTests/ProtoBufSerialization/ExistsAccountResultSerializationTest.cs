namespace Nivaes.App.Shared.UnitTest
{
    using FluentAssertions;
    using Nivaes.App.Contracts;
    using Xunit;
    using Xunit.Abstractions;

    [Trait("TestType", "Unit")]
    public sealed class ExistsAccountResultSerializationTest
    {
        private readonly ITestOutputHelper mTestOutputHelper;

        public ExistsAccountResultSerializationTest(ITestOutputHelper testOutputHelper)
        {
            mTestOutputHelper = testOutputHelper;
        }

        [Fact]
        public void ExistsAccountResultProtoBufSerialize1()
        {
            var existsAccountResult1 = new ExistsAccountResult
            {
                ExistsAccount = true
            };

            var buffer = ProtoBufHelper.Serialize(existsAccountResult1);
            buffer.Should().NotBeNull();

            mTestOutputHelper.WriteLine($"Serialization size: {buffer.Length}");

            var existsAccountResult2 = ProtoBufHelper.Deserialize<ExistsAccountResult>(buffer);

            existsAccountResult2.Should().NotBeNull();
            existsAccountResult2.ExistsAccount.Should().Be(existsAccountResult1.ExistsAccount);
        }

        [Fact]
        public void ExistsAccountResultProtoBufSerialize2()
        {
            var existsAccountResult1 = new ExistsAccountResult
            {
                ExistsAccount = false
            };

            var buffer = ProtoBufHelper.Serialize(existsAccountResult1);
            buffer.Should().NotBeNull();

            mTestOutputHelper.WriteLine($"Serialization size: {buffer.Length}");

            var existsAccountResult2 = ProtoBufHelper.Deserialize<ExistsAccountResult>(buffer);

            existsAccountResult2.Should().NotBeNull();
            existsAccountResult2.ExistsAccount.Should().Be(existsAccountResult1.ExistsAccount);
        }
    }
}
