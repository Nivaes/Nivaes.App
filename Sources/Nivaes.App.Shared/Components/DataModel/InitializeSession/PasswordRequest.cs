namespace Nivaes.App
{
    using System;
    using System.Runtime.Serialization;

    [Obsolete("User gRPC", true)]
    [DataContract(IsReference = false, Name = "PasswordRequest", Namespace = "http://nivaes")]
    public class PasswordRequest
        : IDataModelProtobuf
    {
        [DataMember(Name = "Password")]
        public string Password { get; set; } = string.Empty;
    }
}
