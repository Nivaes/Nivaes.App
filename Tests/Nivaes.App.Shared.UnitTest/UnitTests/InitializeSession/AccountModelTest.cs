namespace Nivaes.UnitTest
{
    using System;
    using System.Runtime.Serialization;
    using Xunit;
    using Nivaes.Test;
    using FluentAssertions;
    using Nivaes.DataTestGenerator;
    using Xunit.Abstractions;
    using FluentValidation.TestHelper;
    using Nivaes.DataTestGenerator.Xunit;

    [Trait("TestType", "Unit")]
    public class AccountModelTest
    {
        private readonly ITestOutputHelper mTestOutputHelper;
        private readonly AccountValidator validator;

        public AccountModelTest(ITestOutputHelper testOutputHelper)
        {
            mTestOutputHelper = testOutputHelper;
            validator = new AccountValidator();
        }

        [Fact]
        public void NewAccount1()
        {
            var contact = ContactGenerator.Instance.GenerateContact();

            AccountDataModel accountDataModel1 = new AccountDataModel()
            {
                IdAccount = Guid.NewGuid(),
                TaxVat = TaxIdGenerator.GenerateNifNie(),
                PersonalName = contact.PersonalName,
                FamilyName = contact.FamilyName,
                PhoneNumber = contact.TelephoneNumber,
                Email = contact.Email,
                TimeStamp = DateTime.Now
            };

            var buffer = ProtoBufHelper.Serialize(accountDataModel1);
            buffer.Should().NotBeNull();

            mTestOutputHelper.WriteLine($"Serialization size: {buffer.Length}");

            var accountDataModel2 = ProtoBufHelper.Deserialize<AccountDataModel>(buffer);

            accountDataModel2.Should().NotBeNull();
            accountDataModel2.IdAccount.Should().Be(accountDataModel1?.IdAccount ?? Guid.Empty);
            accountDataModel2.TaxVat.Should().Be(accountDataModel1?.TaxVat);
            accountDataModel2.PersonalName.Should().Be(accountDataModel1?.PersonalName);
            accountDataModel2.PhoneNumber.Should().Be(accountDataModel1?.PhoneNumber);
            accountDataModel2.Email.Should().Be(accountDataModel1?.Email);
            accountDataModel2.TimeStamp.Should().Be(accountDataModel1?.TimeStamp ?? default);
        }

        [Theory]
        [GenerateContactInlineData(DataNumber = 3)]
        public void NewAccountValidator1(ContactTest contact)
        {
            AccountDataModel accountDataModel1 = new AccountDataModel()
            {
                IdAccount = Guid.NewGuid(),
                TaxVat = TaxIdGenerator.GenerateNifNie(),
                PersonalName = contact.PersonalName,
                FamilyName = contact.FamilyName,
                PhoneNumber = contact.TelephoneNumber,
                Email = contact.Email,
                TimeStamp = DateTime.Now
            };

            validator.ShouldHaveValidationErrorFor(account => account!.PersonalName, null as string);
            validator.ShouldHaveValidationErrorFor(account => account!.PersonalName, string.Empty);
            validator.ShouldHaveValidationErrorFor(account => account!.FamilyName, null as string);
            validator.ShouldHaveValidationErrorFor(account => account!.FamilyName, string.Empty);
            validator.ShouldNotHaveValidationErrorFor(account => account!.PersonalName, contact.PersonalName);
            validator.ShouldHaveValidationErrorFor(account => account!.PersonalName, "");
        }
    }
}
