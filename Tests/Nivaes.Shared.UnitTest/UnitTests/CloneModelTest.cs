namespace Nivaes.UnitTest
{
    using System;
    using System.Runtime.Serialization;
    using Xunit;
    using Nivaes.Test;

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

            Assert.Equal(testDataModel.TestDataModel01Id, testDataModel2.TestDataModel01Id);
            Assert.Equal(testDataModel.StringValue, testDataModel2.StringValue);
            Assert.Equal(testDataModel.StringValueReadOnly, testDataModel2.StringValueReadOnly);
            Assert.Equal(testDataModel.DoubleValue, testDataModel2.DoubleValue);
            Assert.Equal(testDataModel.IntValue, testDataModel2.IntValue);
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

            Assert.Equal(testDataModel.TestDataModel01Id, testDataModel2.TestDataModel01Id);
            Assert.Equal(testDataModel.StringValue, testDataModel2.StringValue);
            Assert.Equal(testDataModel.StringValueReadOnly, testDataModel2.StringValueReadOnly);
            Assert.Equal(testDataModel.DoubleValue, testDataModel2.DoubleValue);
            Assert.Equal(testDataModel.IntValue, testDataModel2.IntValue);
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

            Assert.Equal(testDataModel.TestDataModel01Id, testDataModel2.TestDataModel01Id);
            Assert.Equal(testDataModel.StringValue, testDataModel2.StringValue);
            Assert.Equal(testDataModel.StringValueReadOnly, testDataModel2.StringValueReadOnly);
            Assert.Equal(testDataModel.DoubleValue, testDataModel2.DoubleValue);
            Assert.Equal(testDataModel.IntValue, testDataModel2.IntValue);
        }
    }
}
