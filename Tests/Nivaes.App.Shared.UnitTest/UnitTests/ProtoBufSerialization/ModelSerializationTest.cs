namespace Nivaes.App.Shared.UnitTest
{
    using FluentAssertions;
    using Nivaes.App.Shared.Test;
    using Xunit;
    using Xunit.Abstractions;

    [Trait("TestType", "Unit")]
    public sealed class ModelSerializationTest
        : IClassFixture<ProtoBufRegisterFixture>
    {
        private readonly ITestOutputHelper mTestOutputHelper;

        public ModelSerializationTest(ITestOutputHelper testOutputHelper)
        {
            mTestOutputHelper = testOutputHelper;
        }

        [Fact]
        public void ModelTest1ProtoBufSerialize1()
        {
            var modelTest1 = new ModelTest1
            {
                GuidData = Guid.NewGuid(),
            };

            var buffer = ProtoBufHelper.Serialize(modelTest1);
            buffer.Should().NotBeNull();

            mTestOutputHelper.WriteLine($"Serialization size: {buffer.Length}");

            var modelTest2 = ProtoBufHelper.Deserialize<ModelTest1>(buffer);

            modelTest2.Should().NotBeNull();
            modelTest2.GuidData.Should().Be(modelTest1.GuidData);
        }

        [Fact]
        public void ModelTest2ProtoBufSerialize1()
        {
            var modelTest1 = new ModelTest2
            {
                StringData = DataTestGenerator.GenericGenerator.Instance.GenerateString(100, 300)
            };

            var buffer = ProtoBufHelper.Serialize(modelTest1);
            buffer.Should().NotBeNull();

            mTestOutputHelper.WriteLine($"Serialization size: {buffer.Length}");

            var modelTest2 = ProtoBufHelper.Deserialize<ModelTest2>(buffer);

            modelTest2.Should().NotBeNull();
            modelTest2.StringData.Should().Be(modelTest1.StringData);
        }

        [Fact]
        public void ModelTest3ProtoBufSerialize1()
        {
            var modelTest1 = new ModelTest3
            {
                StringData = DataTestGenerator.GenericGenerator.Instance.GenerateString(100, 300)
            };

            var buffer = ProtoBufHelper.Serialize(modelTest1);
            buffer.Should().NotBeNull();

            mTestOutputHelper.WriteLine($"Serialization size: {buffer.Length}");

            var modelTest2 = ProtoBufHelper.Deserialize<ModelTest3>(buffer);

            modelTest2.Should().NotBeNull();
            modelTest2.StringData.Should().Be(modelTest1.StringData);
        }

        [Fact]
        public void TestDataModel01ProtoBufSerialize1()
        {
            var modelTest1 = new TestDataModel01
            {
                StringValueReadOnly = DataTestGenerator.GenericGenerator.Instance.GenerateString(100, 300),
                StringValue = DataTestGenerator.GenericGenerator.Instance.GenerateString(100, 300),
                IntValue = DataTestGenerator.GenericGenerator.Instance.GenerateInt(),
                DoubleValue = DataTestGenerator.GenericGenerator.Instance.GenerateDouble(double.NegativeInfinity, double.PositiveInfinity),
                Telephone = DataTestGenerator.GenericGenerator.Instance.GenerateString(12)

            };

            var buffer = ProtoBufHelper.Serialize(modelTest1);
            buffer.Should().NotBeNull();

            mTestOutputHelper.WriteLine($"Serialization size: {buffer.Length}");

            var modelTest2 = ProtoBufHelper.Deserialize<TestDataModel01>(buffer);

            modelTest2.Should().NotBeNull();
            modelTest2.StringValueReadOnly.Should().Be(modelTest1.StringValueReadOnly);
            modelTest2.StringValue.Should().Be(modelTest1.StringValue);
            modelTest2.IntValue.Should().Be(modelTest1.IntValue);
            modelTest2.DoubleValue.Should().Be(modelTest1.DoubleValue);
            modelTest2.Telephone.Should().Be(modelTest1.Telephone);
        }
    }
}
