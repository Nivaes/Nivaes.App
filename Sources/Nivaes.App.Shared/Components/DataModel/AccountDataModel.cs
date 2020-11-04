namespace Nivaes.App
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Runtime.Serialization;
    //using FluentValidation.Attributes;
    using ProtoBuf;

    //[Validator(typeof(AccountDataModel))]
    [ProtoContract(Name = "Account", ImplicitFirstTag = 100, ImplicitFields = ImplicitFields.None, SkipConstructor = false)]
    public sealed class AccountDataModel
        : DataModel
    {
        [ProtoMember(1, Name = "IdAccount")]
        public Guid IdAccount { get; set; }

        #region TaxVat

        private string mTaxVat = string.Empty;

        [Display(Name = "TaxVat")]
        [MaxLength(20)]
        [ConcurrencyCheck]
        [Required]
        [ProtoMember(2, Name = "TaxVat")]
        public string TaxVat
        {
            get => mTaxVat;
            set => base.SetProperty(ref mTaxVat, value);
        }

        #endregion TaxVat

        #region HonorificNamePrefix

        private string mHonorificNamePrefix = string.Empty;

        [MaxLength(10)]
        [ProtoMember(3, Name = "HonorificNamePrefix")]
        public string HonorificNamePrefix
        {
            get => mHonorificNamePrefix;
            set => base.SetProperty(ref mHonorificNamePrefix, value);
        }

        #endregion HonorificNamePrefix

        #region HonorificNameSuffix

        private string mHonorificNameSuffix = string.Empty;

        [MaxLength(10)]
        [ProtoMember(4, Name = "HonorificNameSuffix")]
        public string HonorificNameSuffix
        {
            get => mHonorificNameSuffix;
            set => base.SetProperty(ref mHonorificNameSuffix, value);
        }

        #endregion HonorificNameSuffix

        #region PersonalName

        [IgnoreDataMember]
        private string mPersonalName = string.Empty;

        [MaxLength(500)]
        [Required]
        [ProtoMember(5, Name = "PersonalName")]
        public string PersonalName
        {
            get => mPersonalName;
            set => base.SetProperty(ref mPersonalName, value);
        }

        #endregion PersonalName

        #region FamilyName

        [IgnoreDataMember]
        private string mFamilyName = string.Empty;

        [MaxLength(500)]
        [Required]
        [ProtoMember(6, Name = "FamilyName")]
        public string FamilyName
        {
            get => mFamilyName;
            set => base.SetProperty(ref mFamilyName, value);
        }

        #endregion FamilyName

        [ProtoIgnore]
        public string FullName => string.Join(" ", new string[] { mHonorificNamePrefix, mPersonalName, mFamilyName, mHonorificNameSuffix }.Where(s => !string.IsNullOrEmpty(s)));

        [ProtoIgnore]
        public string Initials => mPersonalName?.Substring(0, 1) + mFamilyName?.Substring(0, 1);

        #region Email

        private string mEmail = string.Empty;

        [ProtoMember(7, Name = "Email")]
        public string Email
        {
            get => mEmail;
            set => base.SetProperty(ref mEmail, value);
        }

        #endregion Email

        #region PhoneNumber

        private string mPhoneNumber = string.Empty;

        [Required(ErrorMessage = "Ha de especificar un teléfono.")]
        [ProtoMember(8, Name = "PhoneNumber")]
        public string PhoneNumber
        {
            get => mPhoneNumber;
            set => base.SetProperty(ref mPhoneNumber, value);
        }

        #endregion PhoneNumber

        #region ProfileAvatar

        private string mProfileAvatar = string.Empty;

        [ProtoIgnore]
        public string ProfileAvatar
        {
            get => mProfileAvatar;
            set => base.SetProperty(ref mProfileAvatar, value);
        }

        #endregion ProfileAvatar
    }
}
