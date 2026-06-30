using System;
using System.Globalization;
using Shouldly;
using Xunit;

namespace Nivaes.App.Shared.UnitTest
{
    [Trait("TestType", "Unit")]
    public class SerializationTest
    {
        [Fact]
        public void DataTimeSerializationTest()
        {
            DateTime t1 = new DateTime(2019, 1, 6, 0, 0, 0, DateTimeKind.Utc);

            string s = t1.ToString(CultureInfo.InvariantCulture);

            DateTime t2 = DateTime.Parse(s, CultureInfo.InvariantCulture);

            Assert.Equal(t1, t2);
            t1.ShouldBe(t2);
        }

        [Fact]
        public void DataTimeOffsetSerializationTest()
        {
            DateTimeOffset t1 = new DateTimeOffset(new DateTime(2019, 1, 6, 0, 0, 0, DateTimeKind.Utc));

            string s = t1.ToString(CultureInfo.InvariantCulture);

            DateTimeOffset t2 = DateTimeOffset.Parse(s, CultureInfo.InvariantCulture);

            Assert.Equal(t1, t2);
            t1.ShouldBe(t2);
        }
    }
}
