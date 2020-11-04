namespace Nivaes.App
{
    using System.Runtime.Serialization;

    [DataContract(IsReference = false, Name = "LoginUser", Namespace = "http://nivaes")]
    public class LoginUserModel
    {
        [DataMember(Name = "User")]
        public string User { get; set; } = string.Empty;

        [DataMember(Name = "Password")]
        public string Password { get; set; } = string.Empty;
    }
}
