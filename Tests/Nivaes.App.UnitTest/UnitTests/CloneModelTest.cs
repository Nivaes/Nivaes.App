using Nivaes.App.Shared.Test;
using Shouldly;
using Xunit;

namespace Nivaes.App.Shared.UnitTest
{
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

            testDataModel2.ShouldNotBeNull();
            testDataModel.TestDataModel01Id.ShouldBe(testDataModel2.TestDataModel01Id);
            testDataModel.StringValue.ShouldBe(testDataModel2.StringValue);
            testDataModel.StringValueReadOnly.ShouldBe(testDataModel2.StringValueReadOnly);
            testDataModel.DoubleValue.ShouldBe(testDataModel2.DoubleValue);
            testDataModel.IntValue.ShouldBe(testDataModel2.IntValue);
            testDataModel.TimeStampTicks.ShouldBe<long>(testDataModel2.TimeStampTicks);
            testDataModel.TimeStamp.ShouldBe(testDataModel2.TimeStamp);
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

            var testDataModel2 = testDataModel.Clone();

            testDataModel2.ShouldNotBeNull();
            testDataModel.TestDataModel01Id.ShouldBe(testDataModel2!.TestDataModel01Id);
            testDataModel.StringValue.ShouldBe(testDataModel2!.StringValue);
            testDataModel.StringValueReadOnly.ShouldBe(testDataModel2!.StringValueReadOnly);
            testDataModel.DoubleValue.ShouldBe(testDataModel2!.DoubleValue);
            testDataModel.IntValue.ShouldBe(testDataModel2!.IntValue);
            testDataModel.TimeStampTicks.ShouldBe<long>(testDataModel2!.TimeStampTicks);
            testDataModel.TimeStamp.ShouldBe(testDataModel2.TimeStamp);
        }
    }
}
