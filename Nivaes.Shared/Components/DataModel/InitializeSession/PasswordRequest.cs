namespace Nivaes
{
    using System;
    using System.Runtime.Serialization;

    [Obsolete("User gRPC", true)]
    [DataContract(IsReference = false, Name = "PasswordRequest", Namespace = "http://nivaes")]
    public class PasswordRequest
    {
        [DataMember(Name = "Password")]
        public string Password { get; set; }
    }
}
