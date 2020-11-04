namespace Nivaes.App.UnitTest
{
    using System;
    using System.Runtime.Serialization;
    using Xunit;
    using Nivaes.Test;
    using FluentAssertions;

    [Trait("TestType", "Unit")]
    public class CloneModelUnitTest
    {
        [Fact]
        public void CloneModelTest()
        {
            TestDataModel01 testDataModel = new TestDataModel01()
            {
                StringValue = "StringValue",
                StringValueReadOnly = "StringValueReadOnly",
                DoubleValue = 10.3,
                IntValue = 3
            };

            var testDataModel2 = testDataModel.Clone();

            testDataModel2.Should().NotBeNull();
            testDataModel.TestDataModel01Id.Should().Be(testDataModel2?.TestDataModel01Id ?? Guid.Empty);
            testDataModel.StringValue.Should().Be(testDataModel2?.StringValue);
            testDataModel.StringValueReadOnly.Should().Be(testDataModel2?.StringValueReadOnly);
            testDataModel.DoubleValue.Should().Be(testDataModel2?.DoubleValue);
            testDataModel.IntValue.Should().Be(testDataModel2?.IntValue);
        }

        [Fact]
        public void CloneDataContractTest()
        {
            TestDataModel01 testDataModel = new TestDataModel01()
            {
                StringValue = "StringValue",
                StringValueReadOnly = "StringValueReadOnly",
                DoubleValue = 10.3,
                IntValue = 3
            };

            var testDataModel2 = testDataModel.CloneDataContract();

            testDataModel2.Should().NotBeNull();
            testDataModel.TestDataModel01Id.Should().Be(testDataModel2?.TestDataModel01Id ?? Guid.Empty);
            testDataModel.StringValue.Should().Be(testDataModel2?.StringValue);
            testDataModel.StringValueReadOnly.Should().Be(testDataModel2?.StringValueReadOnly);
            testDataModel.DoubleValue.Should().Be(testDataModel2?.DoubleValue);
            testDataModel.IntValue.Should().Be(testDataModel2?.IntValue);
        }

        [Fact]
        public void CloneModelProtoBufTest()
        {
            TestDataModel01 testDataModel = new TestDataModel01()
            {
                StringValue = "StringValue",
                StringValueReadOnly = "StringValueReadOnly",
                DoubleValue = 10.3,
                IntValue = 3
            };

            var testDataModel2 = testDataModel.CloneProtoBuf();

            testDataModel2.Should().NotBeNull();
            testDataModel.TestDataModel01Id.Should().Be(testDataModel2?.TestDataModel01Id ?? Guid.Empty);
            testDataModel.StringValue.Should().Be(testDataModel2?.StringValue);
            testDataModel.StringValueReadOnly.Should().Be(testDataModel2?.StringValueReadOnly);
            testDataModel.DoubleValue.Should().Be(testDataModel2?.DoubleValue);
            testDataModel.IntValue.Should().Be(testDataModel2?.IntValue);
        }
    }
}
