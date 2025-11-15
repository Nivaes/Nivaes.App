namespace Nivaes.App
{
    using LightProto;

    [ProtoContract(Name = "Request", ImplicitFields = ImplicitFields.None, SkipConstructor = true)]
    public abstract partial class Request
    {
        protected Request()
        { }
    }
}
