//namespace Nivaes.App.Shared.UnitTest
//{
//    using System;
//    using System.IO;
//    using FluentAssertions;
//    using Nivaes.App.Shared.Test;
//    using Nivaes.DataTestGenerator;
//    using Xunit;
//    using Xunit.Abstractions;

//    [Trait("TestType", "Unit")]
//    public sealed class BigResultSerializationTest
//        : IClassFixture<ProtoBufRegisterFixture>
//    {
//        private readonly ITestOutputHelper mTestOutputHelper;

//        public BigResultSerializationTest(ITestOutputHelper testOutputHelper)
//        {
//            mTestOutputHelper = testOutputHelper;
//        }

//        [Fact]
//        public void BigResultProtoBufSerialize1()
//        {
//            var bigResult1 = new BigResult
//            {
//            };

//            var buffer = ProtoHelper.Serialize(bigResult1);
//            buffer.Should().NotBeNull();

//            mTestOutputHelper.WriteLine($"Serialization size: {buffer.Length}");

//            var getAccountResult2 = ProtoHelper.Deserialize<BigResult>(buffer);

//            getAccountResult2.Should().NotBeNull();
//            getAccountResult2.ContentValue.Should().BeNull();
//        }

//        [Fact]
//        public void BigResultProtoBufSerialize2()
//        {
//            var contact = ContactGenerator.Instance.GenerateContact();

//            ProtoHelper.CanSerialize(typeof(BigResult)).Should().BeTrue();
//            ProtoHelper.CanSerialize(typeof(BigDatamodel)).Should().BeTrue();

//            var getAccountResult1 = new BigResult
//            {
//                 ContentValue= new BigDatamodel
//                 {
//                    IdBid = Guid.NewGuid(),
//                    TextValue1 = contact.GivenName,
//                    TextValue2 = contact.FamilyName,
//                    BigTextValue = GenericGenerator.Instance.GenerateString(500),
//                    IntValue = GenericGenerator.Instance.GenerateInt(),
//                    TimeStamp = DateTime.Now
//                 }
//            };

//            var buffer = ProtoHelper.Serialize(getAccountResult1);
//            buffer.Should().NotBeNull();

//            mTestOutputHelper.WriteLine($"Serialization size: {buffer.Length}");

//            var getAccountResult2 = ProtoHelper.Deserialize<BigResult>(buffer);

//            getAccountResult2.Should().NotBeNull();
//            getAccountResult2.ContentValue.Should().NotBeNull();
//            getAccountResult2.ContentValue?.IdBid.Should().Be(getAccountResult1.ContentValue.IdBid);
//            getAccountResult2.ContentValue?.TextValue1.Should().Be(getAccountResult1.ContentValue.TextValue1);
//            getAccountResult2.ContentValue?.TextValue2.Should().Be(getAccountResult1.ContentValue.TextValue2);
//            getAccountResult2.ContentValue?.BigTextValue.Should().Be(getAccountResult1.ContentValue.BigTextValue);
//            getAccountResult2.ContentValue?.IntValue.Should().Be(getAccountResult1.ContentValue.IntValue);
//            getAccountResult2.ContentValue?.TimeStamp.Should().Be(getAccountResult1.ContentValue.TimeStamp);
//            getAccountResult2.ContentValue?.TimeStampTicks.Should().Be(getAccountResult1.ContentValue.TimeStampTicks);
//        }

//        [Fact]
//        public void BigResultProtoBufSerialize3()
//        {
//            var contact = ContactGenerator.Instance.GenerateContact();

//            ProtoHelper.CanSerialize(typeof(BigResult)).Should().BeTrue();
//            ProtoHelper.CanSerialize(typeof(BigDatamodel)).Should().BeTrue();

//            var getAccountResult1 = new BigResult
//            {
//                ContentValue = new BigDatamodel
//                {
//                    IdBid = Guid.NewGuid(),
//                    TextValue1 = contact.GivenName,
//                    TextValue2 = contact.FamilyName,
//                    BigTextValue = GenericGenerator.Instance.GenerateString(1500),
//                    IntValue = GenericGenerator.Instance.GenerateInt(),
//                    TimeStamp = DateTime.Now
//                }
//            };

//            var buffer = ProtoHelper.Serialize(getAccountResult1);
//            buffer.Should().NotBeNull();

//            mTestOutputHelper.WriteLine($"Serialization size: {buffer.Length}");

//            var getAccountResult2 = ProtoHelper.Deserialize<BigResult>(buffer);

//            getAccountResult2.Should().NotBeNull();
//            getAccountResult2.ContentValue.Should().NotBeNull();
//            getAccountResult2.ContentValue?.IdBid.Should().Be(getAccountResult1.ContentValue.IdBid);
//            getAccountResult2.ContentValue?.TextValue1.Should().Be(getAccountResult1.ContentValue.TextValue1);
//            getAccountResult2.ContentValue?.TextValue2.Should().Be(getAccountResult1.ContentValue.TextValue2);
//            getAccountResult2.ContentValue?.BigTextValue.Should().Be(getAccountResult1.ContentValue.BigTextValue);
//            getAccountResult2.ContentValue?.IntValue.Should().Be(getAccountResult1.ContentValue.IntValue);
//            getAccountResult2.ContentValue?.TimeStamp.Should().Be(getAccountResult1.ContentValue.TimeStamp);
//            getAccountResult2.ContentValue?.TimeStampTicks.Should().Be(getAccountResult1.ContentValue.TimeStampTicks);
//        }

//        [Fact]
//        public void BigResultProtoBufSerialize4()
//        {
//            var model = RuntimeTypeModel.Create();

//            model.Add(typeof(Model), true)
//              .AddSubType(201, typeof(DataModel));

//            model.Add(typeof(DataModel), true)
//                .AddSubType(100, typeof(BigDatamodel));

//            model.Add(typeof(Result), true)
//                .AddSubType(200, typeof(BigResult));

//            model.Add(typeof(BigDatamodel), true);

//            var contact = ContactGenerator.Instance.GenerateContact();

//            using var ms1 = new MemoryStream();
//            var getAccountResult1 = new BigResult
//            {
//                ContentValue = new BigDatamodel
//                {
//                    IdBid = Guid.NewGuid(),
//                    TextValue1 = contact.GivenName,
//                    TextValue2 = contact.FamilyName,
//                    BigTextValue = GenericGenerator.Instance.GenerateString(2500),
//                    IntValue = GenericGenerator.Instance.GenerateInt(),
//                    TimeStamp = DateTime.Now
//                }
//            };

//            model.Serialize(ms1, getAccountResult1);

//            var buffer = ms1.ToArray();
//            buffer.Should().NotBeNull();

//            mTestOutputHelper.WriteLine($"Serialization size: {buffer.Length}");

//            using var ms2 = new MemoryStream(buffer);
//            var getAccountResult2 = (BigResult)model.Deserialize(ms2, null, typeof(BigResult));

//            getAccountResult2.Should().NotBeNull();
//            getAccountResult2.ContentValue.Should().NotBeNull();
//            getAccountResult2.ContentValue?.IdBid.Should().Be(getAccountResult1.ContentValue.IdBid);
//            getAccountResult2.ContentValue?.TextValue1.Should().Be(getAccountResult1.ContentValue.TextValue1);
//            getAccountResult2.ContentValue?.TextValue2.Should().Be(getAccountResult1.ContentValue.TextValue2);
//            getAccountResult2.ContentValue?.BigTextValue.Should().Be(getAccountResult1.ContentValue.BigTextValue);
//            getAccountResult2.ContentValue?.IntValue.Should().Be(getAccountResult1.ContentValue.IntValue);
//            getAccountResult2.ContentValue?.TimeStamp.Should().Be(getAccountResult1.ContentValue.TimeStamp);
//            getAccountResult2.ContentValue?.TimeStampTicks.Should().Be(getAccountResult1.ContentValue.TimeStampTicks);
//        }
//    }
//}
