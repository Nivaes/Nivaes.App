namespace Nivaes.App.Shared.UnitTest
{
    using System;
    using FluentAssertions;
    using Nivaes.App.Shared.Test;
    using Xunit;
    using Xunit.Abstractions;

    [Trait("TestType", "Unit")]
    public sealed class ToolsetTest
        : IClassFixture<ProtoBufRegisterFixture>
    {
        private readonly ITestOutputHelper mTestOutputHelper;

        public ToolsetTest(ITestOutputHelper testOutputHelper)
        {
            mTestOutputHelper = testOutputHelper;
        }

        [Fact]
        public void ModelTest1Serialize1()
        {
            var modelTest1 = new ModelTest1
            {
                GuidData = Guid.NewGuid(),
                TimeStamp = DateTime.UtcNow,
            };

            var buffer = ProtoBufHelper.Serialize(modelTest1);
            buffer.Should().NotBeNull();

            mTestOutputHelper.WriteLine($"Serialization size: {buffer.Length}");

            var modelTest2 = ProtoBufHelper.Deserialize<ModelTest1>(buffer);

            modelTest2.Should().NotBeNull();
            modelTest2.GuidData.Should().Be(modelTest1.GuidData);
            modelTest2.TimeStampTicks.Should().Be(modelTest1.TimeStampTicks);
            modelTest2.TimeStamp.Should().Be(modelTest1.TimeStamp);
        }

        [Fact]
        public void ModelTest2Serialize1()
        {
            var modelTest1 = new ModelTest2
            {
                StringData = "lñkasdfoekandsñfa akdf añei fd",
                TimeStamp = DateTime.UtcNow
            };

            var buffer = ProtoBufHelper.Serialize(modelTest1);
            buffer.Should().NotBeNull();

            mTestOutputHelper.WriteLine($"Serialization size: {buffer.Length}");

            var modelTest2 = ProtoBufHelper.Deserialize<ModelTest2>(buffer);

            modelTest2.Should().NotBeNull();
            modelTest2.StringData.Should().Be(modelTest1.StringData);
            modelTest2.TimeStampTicks.Should().Be(modelTest1.TimeStampTicks);
            modelTest2.TimeStamp.Should().Be(modelTest1.TimeStamp);
        }

        [Fact]
        public void ModelTest3Serialize1()
        {
            var modelTest1 = new ModelTest3
            {
                StringData = "kajñdflkj eañfk j823rifjdr823r     kfj 02ur",
                TimeStamp = DateTime.UtcNow
            };

            var buffer = ProtoBufHelper.Serialize(modelTest1);
            buffer.Should().NotBeNull();

            mTestOutputHelper.WriteLine($"Serialization size: {buffer.Length}");

            var modelTest2 = ProtoBufHelper.Deserialize<ModelTest3>(buffer);

            modelTest2.Should().NotBeNull();
            modelTest2.StringData.Should().Be(modelTest1.StringData);
            modelTest2.TimeStampTicks.Should().Be(modelTest1.TimeStampTicks);
            modelTest2.TimeStamp.Should().Be(modelTest1.TimeStamp);
        }
    }
}
