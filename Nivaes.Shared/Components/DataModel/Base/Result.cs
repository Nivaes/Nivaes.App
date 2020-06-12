namespace Nivaes
{
    using ProtoBuf;

    [ProtoContract(Name = "Result", ImplicitFields = ImplicitFields.None, SkipConstructor = true)]
    public abstract class Result
        : IDataModelProtobuf
    {
        protected Result()
        { }
    }
}
