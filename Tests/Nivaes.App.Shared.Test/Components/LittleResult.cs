namespace Nivaes.App.Shared.Test
{
    using LightProto;


    [ProtoContract(Name = "LittleResult", ImplicitFirstTag = 100, ImplicitFields = ImplicitFields.None, SkipConstructor = true)]
    public partial class LittleResult
        : Result, IDataModelProtobuf
    {
        [ProtoMember(1, Name = "EndValue")]
        public bool EndValue { get; set; }
    }
}
