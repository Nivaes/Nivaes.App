namespace Nivaes.App
{
    using LightProto;

    [ProtoContract(Name = "Result", ImplicitFields = ImplicitFields.None, SkipConstructor = true)]
    public abstract partial class Result
    {
        protected Result()
        { }
    }
}
