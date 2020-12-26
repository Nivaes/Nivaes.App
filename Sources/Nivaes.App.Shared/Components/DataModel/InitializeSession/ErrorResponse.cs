namespace Nivaes.App
{
    using ProtoBuf;

    [ProtoContract(Name = "IdentityErrorResponse", ImplicitFirstTag = 100, ImplicitFields = ImplicitFields.None)]
    public class ErrorResponse
        : IDataModelProtobuf
    {
        [ProtoMember(1, Name = "Code")]
        public string Code { get; set; } = string.Empty;

        [ProtoMember(2, Name = "Description")]
        public string Description { get; set; } = string.Empty;
    }
}
