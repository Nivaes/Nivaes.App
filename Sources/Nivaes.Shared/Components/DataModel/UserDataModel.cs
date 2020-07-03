namespace Nivaes
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Runtime.Serialization;
    using ProtoBuf;

    [ProtoContract(Name = "User", ImplicitFirstTag = 100, ImplicitFields = ImplicitFields.None)]
    public abstract class UserDataModel
        : DataModel, IDataModel, INotifyPropertyChanged
    {
        [Key]
        [ProtoMember(1, Name = "IdUser")]
        public Guid IdUser { get; set; }

        [ProtoMember(2, Name = "IdAccount")]
        public Guid IdAccount { get; set; }

        #region TaxVat

        [IgnoreDataMember]
        private string mTaxVat = string.Empty;

        [MaxLength(20)]
        [ConcurrencyCheck]
        [Required]
        [ProtoMember(3, Name = "TaxVat")]
        public string TaxVat
        {
            get => mTaxVat;
            set => base.SetProperty(ref mTaxVat, value);
        }

        #endregion TaxVat

        #region HonorificNamePrefix

        private string mHonorificNamePrefix = string.Empty;

        [MaxLength(10)]
        [ProtoMember(4, Name = "HonorificNamePrefix")]
        public string HonorificNamePrefix
        {
            get => mHonorificNamePrefix;
            set => base.SetProperty(ref mHonorificNamePrefix, value);
        }

        #endregion HonorificNamePrefix

        #region HonorificNameSuffix

        private string mHonorificNameSuffix = string.Empty;

        [MaxLength(10)]
        [ProtoMember(5, Name = "HonorificNameSuffix")]
        public string HonorificNameSuffix
        {
            get => mHonorificNameSuffix;
            set => base.SetProperty(ref mHonorificNameSuffix, value);
        }

        #endregion HonorificNameSuffix

        #region PersonalName

        private string mPersonalName = string.Empty;

        [MaxLength(500)]
        [ProtoMember(6, Name = "PersonalName")]
        public string PersonalName
        {
            get => mPersonalName;
            set
            {
                if (base.SetProperty(ref mPersonalName, value))
                {
                    base.RaisePropertyChanged(nameof(FullName));
                }
            }
        }

        #endregion PersonalName

        #region FamilyName

        private string mFamilyName = string.Empty;

        [MaxLength(500)]
        [ProtoMember(7, Name = "FamilyName")]
        public string FamilyName
        {
            get => mFamilyName;
            set
            {
                if (base.SetProperty(ref mFamilyName, value))
                {
                    base.RaisePropertyChanged(nameof(FullName));
                }
            }
        }

        #endregion FamilyName

        [ProtoIgnore]
        public string FullName => string.Join(" ", new string[] { mHonorificNamePrefix, mPersonalName, mFamilyName, mHonorificNameSuffix }.Where(s => !string.IsNullOrEmpty(s)));

        [ProtoIgnore]
        public string Initials => mPersonalName?.Substring(0, 1) + mFamilyName?.Substring(0, 1);

        #region PhoneNumber

        private string mPhoneNumber = string.Empty;

        [MaxLength(30)]
        [DataType(DataType.PhoneNumber)]
        [ProtoMember(8, Name = "PhoneNumber")]
        public string PhoneNumber
        {
            get => mPhoneNumber;
            set => base.SetProperty(ref mPhoneNumber, value);
        }

        #endregion PhoneNumber

        #region Email

        private string mEmail = string.Empty;

        [MaxLength(1024)]
        [DataType(DataType.EmailAddress)]
        [ProtoMember(9, Name = "Email")]
        public string Email
        {
            get => mEmail;
            set => base.SetProperty(ref mEmail, value);
        }

        #endregion Email

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
