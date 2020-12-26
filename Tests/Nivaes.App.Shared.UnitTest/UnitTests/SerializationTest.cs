namespace Nivaes.App.Shared.UnitTest
{
    using System;
    using System.Globalization;
    using FluentAssertions;
    using ProtoBuf.Meta;
    using Xunit;

    [Trait("TestType", "Unit")]
    public class SerializationTest
    {
        [Fact]
        public void DataTimeSerializationTest()
        {
            DateTime t1 = new DateTime(2019, 1, 6);

            string s = t1.ToString(CultureInfo.InvariantCulture);

            DateTime t2 = DateTime.Parse(s, CultureInfo.InvariantCulture);

            Assert.Equal(t1, t2);
            t1.Should().Be(t2);
        }

        [Fact]
        public void DataTimeOffsetSerializationTest()
        {
            DateTimeOffset t1 = new DateTimeOffset(new DateTime(2019, 1, 6));

            string s = t1.ToString(CultureInfo.InvariantCulture);

            DateTimeOffset t2 = DateTimeOffset.Parse(s, CultureInfo.InvariantCulture);

            Assert.Equal(t1, t2);
            t1.Should().Be(t2);
        }

        [Fact]
        public void ProtoBufHelperSerialization()
        {
            ProtoBufHelper.CanSerialize(typeof(int)).Should().BeTrue();
            ProtoBufHelper.CanSerialize(typeof(string)).Should().BeTrue();
            ProtoBufHelper.CanSerialize(typeof(decimal)).Should().BeTrue();
            ProtoBufHelper.CanSerialize(typeof(DateTime)).Should().BeTrue();
        }

        [Fact]
        public void ProtoBufSerialization()
        {
            var model = RuntimeTypeModel.Create();
            model.Add(typeof(DateTimeOffset), true);

            model.CanSerialize(typeof(int)).Should().BeTrue();
            model.CanSerialize(typeof(string)).Should().BeTrue();
            model.CanSerialize(typeof(decimal)).Should().BeTrue();
            model.CanSerialize(typeof(DateTime)).Should().BeTrue();
        }
    }
}
