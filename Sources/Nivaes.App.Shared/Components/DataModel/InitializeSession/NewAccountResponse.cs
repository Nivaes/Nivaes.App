namespace Nivaes.App
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [Obsolete("User gRPC", true)]
    [DataContract(IsReference = false, Name = "NewAccountResponse", Namespace = "http://nivaes")]
    public class NewAccountResponse
    {
        [DataMember(Name = "IdAccount")]
        public Guid IdAccount { get; set; }

        [DataMember(Name = "AccountCreated")]
        public bool AccountCreated { get; set; }

        [DataMember(Name = "Errors")]
        public IEnumerable<ErrorResponse> Errors { get; set; } = Array.Empty<ErrorResponse>();
    }
}
