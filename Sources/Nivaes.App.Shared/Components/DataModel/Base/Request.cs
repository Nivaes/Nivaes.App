namespace Nivaes.App
{
    using ProtoBuf;

    [ProtoContract(Name = "Request", ImplicitFields = ImplicitFields.None, SkipConstructor = true)]
    public abstract class Request
        : IDataModelProtobuf
    {
        protected Request()
        { }
    }
}
