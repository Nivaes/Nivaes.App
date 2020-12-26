namespace Nivaes.App
{
    using System.ComponentModel.DataAnnotations;
    //using FluentValidation.Attributes;
    using ProtoBuf;

    //[Validator(typeof(NewAccountValidator))]
    [ProtoContract(Name = "NewAccount", ImplicitFirstTag = 100, ImplicitFields = ImplicitFields.None)]
    public class NewAccountModel
        : Model
    {
        #region Account

        private AccountDataModel? mAccount;

        [ProtoMember(1, Name = "Account")]
        public AccountDataModel? Account
        {
            get => mAccount;
            set => base.SetProperty(ref mAccount, value);
        }

        #endregion Account

        #region Password

        private string mPassword = string.Empty;

        [ProtoMember(2, Name = "Password")]
        public string Password
        {
            get => mPassword;
            set => base.SetProperty(ref mPassword, value);
        }

        #endregion Password
    }
}
