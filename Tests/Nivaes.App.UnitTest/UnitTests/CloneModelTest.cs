using Nivaes.App.Shared.Test;
using Nivaes.Serializer;
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
                DeleteDateTimeStamp = DateTime.Now
            };

            var testDataModel2 = SerializeModel.Clone(testDataModel);

            testDataModel2.ShouldNotBeNull();
            testDataModel.TestDataModel01Id.ShouldBe(testDataModel2.TestDataModel01Id);
            testDataModel.StringValue.ShouldBe(testDataModel2.StringValue);
            testDataModel.StringValueReadOnly.ShouldBe(testDataModel2.StringValueReadOnly);
            testDataModel.DoubleValue.ShouldBe(testDataModel2.DoubleValue);
            testDataModel.IntValue.ShouldBe(testDataModel2.IntValue);

            testDataModel.DateTimeStamp.ShouldBe(testDataModel2.DateTimeStamp);
            testDataModel.DateTimeStamp.Ticks.ShouldBe(testDataModel2.DateTimeStamp.Ticks);

            testDataModel.DateTimeStampTicks.ShouldBe(testDataModel2.DateTimeStampTicks);

            testDataModel.DeleteDateTimeStamp.ShouldBe(testDataModel2.DeleteDateTimeStamp);
            testDataModel.DeleteDateTimeStamp.Value.Ticks.ShouldBe(testDataModel2.DeleteDateTimeStamp!.Value.Ticks);

            testDataModel.DeleteDateTimeStampTicks.ShouldBe(testDataModel2.DeleteDateTimeStampTicks);
        }
    }
}
