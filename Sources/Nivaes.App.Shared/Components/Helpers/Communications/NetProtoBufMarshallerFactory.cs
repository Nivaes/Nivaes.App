namespace Nivaes.App
{
    using System;
    using System.Diagnostics;
    using ProtoBuf.Grpc.Configuration;

    public class NetProtoBufMarshallerFactory
        : MarshallerFactory
    {
        [DebuggerStepperBoundary]
        protected override bool CanSerialize(Type type)
        {
            return ProtoBufHelper.CanSerialize(type);
        }

        [DebuggerStepperBoundary]
        protected override byte[] Serialize<T>(T value)
        {
            return ProtoBufHelper.Serialize<T>(value);
        }

        [DebuggerStepperBoundary]
        protected override T Deserialize<T>(byte[] payload)
        {
            return ProtoBufHelper.Deserialize<T>(payload);
        }
    }
}
