namespace Nivaes.App.Shared.UnitTest
{
    using System;
    using FluentAssertions;
    using FluentValidation.TestHelper;
    using Nivaes.DataTestGenerator;
    using Nivaes.DataTestGenerator.Xunit;
    using Xunit;
    using Xunit.Abstractions;

    [Trait("TestType", "Unit")]
    public class AccountModelTest
        : IClassFixture<ProtoBufRegisterFixture>
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
                GivenName = contact.PersonalName ?? string.Empty,
                FamilyName = contact.FamilyName ?? string.Empty,
                PhoneNumber = contact.TelephoneNumber ?? string.Empty,
                Email = contact.Email ?? string.Empty,
                TimeStamp = DateTime.Now
            };

            var buffer = ProtoBufHelper.Serialize(accountDataModel1);
            buffer.Should().NotBeNull();

            mTestOutputHelper.WriteLine($"Serialization size: {buffer.Length}");

            var accountDataModel2 = ProtoBufHelper.Deserialize<AccountDataModel>(buffer);

            accountDataModel2.Should().NotBeNull();
            _ = accountDataModel2.IdAccount.Should().Be(accountDataModel1!.IdAccount);
            _ = accountDataModel2.TaxVat.Should().Be(accountDataModel1!.TaxVat);
            _ = accountDataModel2.GivenName.Should().Be(accountDataModel1!.GivenName);
            _ = accountDataModel2.PhoneNumber.Should().Be(accountDataModel1!.PhoneNumber);
            _ = accountDataModel2.Email.Should().Be(accountDataModel1!.Email);
            _ = accountDataModel2.TimeStamp.Should().Be(accountDataModel1!.TimeStamp);
            _ = accountDataModel2.TimeStampTicks.Should().Be(accountDataModel1!.TimeStampTicks);
        }

        [Theory]
        [GenerateContactInlineData(DataNumber = 3)]
        public void NewAccountValidator1(ContactTest contact)
        {
            AccountDataModel accountDataModel1 = new AccountDataModel()
            {
                IdAccount = Guid.NewGuid(),
                TaxVat = TaxIdGenerator.GenerateNifNie(),
                GivenName = contact!.PersonalName ?? string.Empty,
                FamilyName = contact.FamilyName ?? string.Empty,
                PhoneNumber = contact.TelephoneNumber ?? string.Empty,
                Email = contact.Email ?? string.Empty,
                TimeStamp = DateTime.Now
            };

            var testValidateResult = validator.TestValidate(accountDataModel1);

            testValidateResult.ShouldNotHaveValidationErrorFor(account => account!.GivenName);
            testValidateResult.ShouldNotHaveValidationErrorFor(account => account!.FamilyName);
            testValidateResult.ShouldNotHaveValidationErrorFor(account => account!.PhoneNumber);
            testValidateResult.ShouldNotHaveValidationErrorFor(account => account!.Email);
        }

        [Theory]
        [GenerateContactInlineData(DataNumber = 3)]
        public void NewAccountValidator2(ContactTest contact)
        {
            AccountDataModel accountDataModel1 = new AccountDataModel()
            {
                IdAccount = Guid.NewGuid(),
                TaxVat = TaxIdGenerator.GenerateNifNie(),
                GivenName =  string.Empty,
                FamilyName = contact.FamilyName ?? string.Empty,
                PhoneNumber = string.Empty,
                Email = contact.Email ?? string.Empty,
                TimeStamp = DateTime.Now
            };

            var testValidateResult = validator.TestValidate(accountDataModel1);

            testValidateResult.ShouldHaveValidationErrorFor(account => account!.GivenName);
            testValidateResult.ShouldNotHaveValidationErrorFor(account => account!.FamilyName);
            testValidateResult.ShouldHaveValidationErrorFor(account => account!.PhoneNumber);
            testValidateResult.ShouldNotHaveValidationErrorFor(account => account!.Email);
        }

        [Fact]
        public void NewAccountNotValidator1()
        {
            AccountDataModel accountDataModel1 = new AccountDataModel()
            {
                IdAccount = Guid.NewGuid(),
                TaxVat = TaxIdGenerator.GenerateNifNie(),
                GivenName = string.Empty,
                FamilyName = string.Empty,
                PhoneNumber = string.Empty,
                Email = string.Empty,
                TimeStamp = DateTime.Now
            };

            var testValidateResult = validator.TestValidate(accountDataModel1);

            testValidateResult.ShouldHaveValidationErrorFor(account => account!.GivenName);
            testValidateResult.ShouldHaveValidationErrorFor(account => account!.FamilyName);
            testValidateResult.ShouldHaveValidationErrorFor(account => account!.PhoneNumber);
            testValidateResult.ShouldHaveValidationErrorFor(account => account!.Email);
        }
    }
}
