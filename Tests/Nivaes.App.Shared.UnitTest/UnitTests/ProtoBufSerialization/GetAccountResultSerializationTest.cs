namespace Nivaes.App.Shared.UnitTest
{
    using System;
    using System.IO;
    using FluentAssertions;
    using Nivaes.App.Contracts;
    using Nivaes.DataTestGenerator;
    using ProtoBuf.Meta;
    using Xunit;
    using Xunit.Abstractions;

    [Trait("TestType", "Unit")]
    public sealed class GetAccountResultSerializationTest
        : IClassFixture<ProtoBufRegisterFixture>
    {
        private readonly ITestOutputHelper mTestOutputHelper;

        public GetAccountResultSerializationTest(ITestOutputHelper testOutputHelper)
        {
            mTestOutputHelper = testOutputHelper;
        }

        [Fact]
        public void GetAccountResultProtoBufSerialize1()
        {
            var getAccountResult1 = new GetAccountResult
            {
            };

            var buffer = ProtoBufHelper.Serialize(getAccountResult1);
            buffer.Should().NotBeNull();

            mTestOutputHelper.WriteLine($"Serialization size: {buffer.Length}");

            var getAccountResult2 = ProtoBufHelper.Deserialize<GetAccountResult>(buffer);

            getAccountResult2.Should().NotBeNull();
            getAccountResult2.Account.Should().BeNull();
        }

        [Fact]
        public void GetAccountResultProtoBufSerialize2()
        {
            var contact = ContactGenerator.Instance.GenerateContact();

            ProtoBufHelper.CanSerialize(typeof(GetAccountResult)).Should().BeTrue();
            ProtoBufHelper.CanSerialize(typeof(AccountDataModel)).Should().BeTrue();

            var getAccountResult1 = new GetAccountResult
            {
                Account = new AccountDataModel
                {
                    IdAccount = Guid.NewGuid(),
                    PersonalName = contact.PersonalName,
                    FamilyName = contact.FamilyName,
                    TaxVat = TaxIdGenerator.GenerateNifNie(),
                    PhoneNumber = contact.TelephoneNumber,
                    Email = contact.Email,
                    TimeStamp = DateTime.Now
                }
            };

            var buffer = ProtoBufHelper.Serialize(getAccountResult1);
            buffer.Should().NotBeNull();

            mTestOutputHelper.WriteLine($"Serialization size: {buffer.Length}");

            var getAccountResult2 = ProtoBufHelper.Deserialize<GetAccountResult>(buffer);

            getAccountResult2.Should().NotBeNull();
            getAccountResult2.Account.Should().NotBeNull();
            getAccountResult2.Account?.IdAccount.Should().Be(getAccountResult1.Account.IdAccount);
            getAccountResult2.Account?.PersonalName.Should().Be(getAccountResult1.Account.PersonalName);
            getAccountResult2.Account?.FamilyName.Should().Be(getAccountResult1.Account.FamilyName);
            getAccountResult2.Account?.TaxVat.Should().Be(getAccountResult1.Account.TaxVat);
            getAccountResult2.Account?.PhoneNumber.Should().Be(getAccountResult1.Account.PhoneNumber);
            getAccountResult2.Account?.Email.Should().Be(getAccountResult1.Account.Email);
            getAccountResult2.Account?.TimeStamp.Should().Be(getAccountResult1.Account.TimeStamp);
            getAccountResult2.Account?.TimeStampTicks.Should().Be(getAccountResult1.Account.TimeStampTicks);
        }

        [Fact]
        public void GetAccountResultProtoBufSerialize3()
        {
            var contact = ContactGenerator.Instance.GenerateContact();

            ProtoBufHelper.CanSerialize(typeof(GetAccountResult)).Should().BeTrue();
            ProtoBufHelper.CanSerialize(typeof(AccountDataModel)).Should().BeTrue();

            var getAccountResult1 = new GetAccountResult
            {
                Account = new AccountDataModel
                {
                    IdAccount = Guid.NewGuid(),
                    PersonalName = contact.PersonalName,
                    FamilyName = contact.FamilyName,
                    TaxVat = TaxIdGenerator.GenerateNifNie(),
                    PhoneNumber = contact.TelephoneNumber,
                    Email = contact.Email,
                    TimeStamp = DateTime.UtcNow
                }
            };

            var buffer = ProtoBufHelper.Serialize(getAccountResult1);
            buffer.Should().NotBeNull();

            mTestOutputHelper.WriteLine($"Serialization size: {buffer.Length}");

            var getAccountResult2 = ProtoBufHelper.Deserialize<GetAccountResult>(buffer);

            getAccountResult2.Should().NotBeNull();
            getAccountResult2.Account.Should().NotBeNull();
            getAccountResult2.Account?.IdAccount.Should().Be(getAccountResult1.Account.IdAccount);
            getAccountResult2.Account?.PersonalName.Should().Be(getAccountResult1.Account.PersonalName);
            getAccountResult2.Account?.FamilyName.Should().Be(getAccountResult1.Account.FamilyName);
            getAccountResult2.Account?.TaxVat.Should().Be(getAccountResult1.Account.TaxVat);
            getAccountResult2.Account?.PhoneNumber.Should().Be(getAccountResult1.Account.PhoneNumber);
            getAccountResult2.Account?.Email.Should().Be(getAccountResult1.Account.Email);
            getAccountResult2.Account?.TimeStamp.Should().Be(getAccountResult1.Account.TimeStamp);
            getAccountResult2.Account?.TimeStampTicks.Should().Be(getAccountResult1.Account.TimeStampTicks);
        }

        [Fact]
        public void GetAccountResultProtoBufSerialize4()
        {
            var model = RuntimeTypeModel.Create();

            //model.Add(typeof(DateTimeOffset), true);

            model.Add(typeof(Model), true)
              .AddSubType(201, typeof(DataModel));

            model.Add(typeof(DataModel), true)
                .AddSubType(100, typeof(AccountDataModel));

            model.Add(typeof(Result), true)
                .AddSubType(200, typeof(GetAccountResult));

            //model.Add(typeof(object), true)
            //    .AddSubType(201, typeof(DateTimeOffset));
            // model.Add(typeof(GetAccountResult), true);

            var contact = ContactGenerator.Instance.GenerateContact();

            using var ms1 = new MemoryStream();
            var getAccountResult1 = new GetAccountResult
            {
                Account = new AccountDataModel
                {
                    IdAccount = Guid.NewGuid(),
                    PersonalName = contact.PersonalName,
                    FamilyName = contact.FamilyName,
                    TaxVat = TaxIdGenerator.GenerateNifNie(),
                    PhoneNumber = contact.TelephoneNumber,
                    Email = contact.Email,
                    TimeStamp = DateTime.UtcNow
                }
            };

            model.Serialize(ms1, getAccountResult1);

            var buffer = ms1.ToArray();
            buffer.Should().NotBeNull();

            mTestOutputHelper.WriteLine($"Serialization size: {buffer.Length}");

            using var ms2 = new MemoryStream(buffer);
            var getAccountResult2 = (GetAccountResult)model.Deserialize(ms2, null, typeof(GetAccountResult));

            getAccountResult2.Should().NotBeNull();
            getAccountResult2.Account.Should().NotBeNull();
            getAccountResult2.Account?.IdAccount.Should().Be(getAccountResult1.Account.IdAccount);
            getAccountResult2.Account?.PersonalName.Should().Be(getAccountResult1.Account.PersonalName);
            getAccountResult2.Account?.FamilyName.Should().Be(getAccountResult1.Account.FamilyName);
            getAccountResult2.Account?.TaxVat.Should().Be(getAccountResult1.Account.TaxVat);
            getAccountResult2.Account?.PhoneNumber.Should().Be(getAccountResult1.Account.PhoneNumber);
            getAccountResult2.Account?.Email.Should().Be(getAccountResult1.Account.Email);
            getAccountResult2.Account?.TimeStampTicks.Should().Be(getAccountResult1.Account.TimeStampTicks);
            getAccountResult2.Account?.TimeStamp.Should().Be(getAccountResult1.Account.TimeStamp);
        }
    }
}
