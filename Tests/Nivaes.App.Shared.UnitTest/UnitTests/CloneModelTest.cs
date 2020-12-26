namespace Nivaes.App.Shared.UnitTest
{
    using System;
    using FluentAssertions;
    using Nivaes.App.Shared.Test;
    using Xunit;

    [Trait("TestType", "Unit")]
    public class CloneModelUnitTest
        : IClassFixture<ProtoBufRegisterFixture>
    {
        [Fact]
        public void CloneModelTest()
        {
            TestDataModel01 testDataModel = new TestDataModel01()
            {
                TestDataModel01Id = Guid.NewGuid(),
                StringValue = "StringValue",
                StringValueReadOnly = "StringValueReadOnly",
                DoubleValue = 10.3,
                IntValue = 3,
                TimeStamp = DateTime.Now
            };

            var testDataModel2 = testDataModel.Clone();

            testDataModel2.Should().NotBeNull();
            testDataModel.TestDataModel01Id.Should().Be(testDataModel2?.TestDataModel01Id ?? Guid.Empty);
            testDataModel.StringValue.Should().Be(testDataModel2?.StringValue);
            testDataModel.StringValueReadOnly.Should().Be(testDataModel2?.StringValueReadOnly);
            testDataModel.DoubleValue.Should().Be(testDataModel2?.DoubleValue);
            testDataModel.IntValue.Should().Be(testDataModel2?.IntValue);
            testDataModel.TimeStampTicks.Should().Be(testDataModel2?.TimeStampTicks);
            testDataModel.TimeStamp.Should().Be(testDataModel2?.TimeStamp ?? default);
        }

        [Fact]
        public void CloneDataContractTest()
        {
            TestDataModel01 testDataModel = new TestDataModel01()
            {
                TestDataModel01Id = Guid.NewGuid(),
                StringValue = "StringValue",
                StringValueReadOnly = "StringValueReadOnly",
                DoubleValue = 10.3,
                IntValue = 3,
                TimeStamp = DateTime.Now
            };

            var testDataModel2 = testDataModel.CloneDataContract();

            testDataModel2.Should().NotBeNull();
            testDataModel.TestDataModel01Id.Should().Be(testDataModel2?.TestDataModel01Id ?? Guid.Empty);
            testDataModel.StringValue.Should().Be(testDataModel2?.StringValue);
            testDataModel.StringValueReadOnly.Should().Be(testDataModel2?.StringValueReadOnly);
            testDataModel.DoubleValue.Should().Be(testDataModel2?.DoubleValue);
            testDataModel.IntValue.Should().Be(testDataModel2?.IntValue);
            testDataModel.TimeStampTicks.Should().Be(testDataModel2?.TimeStampTicks);
            testDataModel.TimeStamp.Should().Be(testDataModel2?.TimeStamp ?? default);
        }

        [Fact]
        public void CloneModelProtoBufTest()
        {
            TestDataModel01 testDataModel = new TestDataModel01()
            {
                TestDataModel01Id = Guid.NewGuid(),
                StringValue = "StringValue",
                StringValueReadOnly = "StringValueReadOnly",
                DoubleValue = 10.3,
                IntValue = 3,
                TimeStamp = DateTime.UtcNow
            };

            var testDataModel2 = testDataModel.CloneProtoBuf();

            testDataModel2.Should().NotBeNull();
            testDataModel.TestDataModel01Id.Should().Be(testDataModel2?.TestDataModel01Id ?? Guid.Empty);
            testDataModel.StringValue.Should().Be(testDataModel2?.StringValue);
            testDataModel.StringValueReadOnly.Should().Be(testDataModel2?.StringValueReadOnly);
            testDataModel.DoubleValue.Should().Be(testDataModel2?.DoubleValue);
            testDataModel.IntValue.Should().Be(testDataModel2?.IntValue);
            testDataModel.TimeStampTicks.Should().Be(testDataModel2?.TimeStampTicks);
            testDataModel.TimeStamp.Should().Be(testDataModel2?.TimeStamp ?? default);
        }
    }
}
