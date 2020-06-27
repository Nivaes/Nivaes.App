namespace Nivaes
{
    using ProtoBuf.Grpc.Configuration;

    public static class NetClientFactory
    {
        private static readonly BinderConfiguration BinderConfig =
            BinderConfiguration.Create(new[] {
                    new NetProtoBufMarshallerFactory(),
                    ProtoBufMarshallerFactory.Default
            });

        public static readonly ClientFactory ClientFactory = ClientFactory.Create(BinderConfig);
    }
}
