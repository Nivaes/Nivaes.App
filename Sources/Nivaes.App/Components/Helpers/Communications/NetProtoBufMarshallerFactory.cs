//namespace Nivaes.App
//{
//    using System;
//    using System.Diagnostics;
//    using ProtoBuf.Grpc.Configuration;

//    public class NetProtoBufMarshallerFactory
//        : MarshallerFactory
//    {
//        [DebuggerStepperBoundary]
//        protected override bool CanSerialize(Type type)
//        {
//            return ProtoHelper.CanSerialize(type);
//        }

//        [DebuggerStepperBoundary]
//        protected override byte[] Serialize<T>(T value)
//        {
//            return ProtoHelper.Serialize<T>(value);
//        }

//        [DebuggerStepperBoundary]
//        protected override T Deserialize<T>(byte[] payload)
//        {
//            return ProtoHelper.Deserialize<T>(payload);
//        }
//    }
//}
