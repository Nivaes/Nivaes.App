namespace Nivaes
{
    using ProtoBuf;

    [ProtoContract(Name = "IdentityErrorResponse", ImplicitFirstTag = 100, ImplicitFields = ImplicitFields.None)]
    public class ErrorResponse
    {
        [ProtoMember(1, Name = "Code")]
        public string Code { get; set; } = string.Empty;

        [ProtoMember(2, Name = "Description")]
        public string Description { get; set; } = string.Empty;
    }
}
