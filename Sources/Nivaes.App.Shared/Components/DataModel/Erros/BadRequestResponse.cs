namespace Nivaes
{
    using System;
    using System.Collections.Generic;
    using ProtoBuf;

    [ProtoContract(Name = "IdentityErrorResponse", ImplicitFirstTag = 100, ImplicitFields = ImplicitFields.None)]
    public class BadRequestResponse
    {
        [ProtoMember(1, Name = "Errors")]
        public IEnumerable<(string, string[])> Errors { get; set; } = Array.Empty<(string, string[])>();

        [ProtoMember(2, Name = "Title")]
        public string Title { get; set; } = string.Empty;

        [ProtoMember(3, Name = "Status")]
        public string Status { get; set; } = string.Empty;
    }
}
