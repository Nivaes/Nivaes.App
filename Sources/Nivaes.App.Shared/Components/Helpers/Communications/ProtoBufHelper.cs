namespace Nivaes.App
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using ProtoBuf.Meta;

    public static class ProtoBufHelper
    {
        private static readonly ProccessModel MProccessModel = new ProccessModel();

        static ProtoBufHelper()
        {
        }

        /// <summary>Initialize load runtime.</summary>
        public static void LoadCache()
        {
            // Method intentionally left empty.
        }

        public static void RegisterType(Type type)
        {
            MProccessModel.RegisterType(type);
        }

        public static bool CanSerialize(Type type)
        {
            return MProccessModel.CanSerialize(type);
        }

        public static byte[] Serialize<T>(T value)
        {
            if (object.Equals(value, default(T)))
                return Array.Empty<byte>();

            using (var ms = new MemoryStream())
            {
                MProccessModel.Serialize(ms, value);

                return ms.ToArray();
            }
        }

        public static T Deserialize<T>(byte[] payload)
        {
            try
            {
                using (var ms = new MemoryStream(payload))
                {
                    return (T)MProccessModel.Deserialize(ms, null, typeof(T));
                }
            }
            catch (ArgumentException ex)
            {
                throw new CommunicationException($"Error deserializing {typeof(T).FullName}", ex);
            }
            catch (Exception ex)
            {
                throw new CommunicationException($"Error deserializing {typeof(T).FullName}", ex);
            }
        }

        private sealed class ProccessModel
        {
            private int mSequenceFieldNumber = 1;
            private readonly RuntimeTypeModel mRuntimeTypeModel;
            private readonly Dictionary<Type, MetaType> mTypes;

            public ProccessModel()
            {
                mRuntimeTypeModel = RuntimeTypeModel.Create();

                mTypes = new Dictionary<Type, MetaType>();

                _ = RegisterType(typeof(Model));
                _ = RegisterType(typeof(DataModel));
                _ = RegisterType(typeof(Result));
                _ = RegisterType(typeof(Request));
            }

            [SuppressMessage("Reliability", "CA2002:Do not lock on objects with weak identity", Justification = "There's no record of the type more than once.")]
            public MetaType? RegisterType(Type type)
            {
                if (type == null) throw new ArgumentNullException(nameof(type));

                if (!typeof(IDataModelProtobuf).IsAssignableFrom(type))
                    return null;

                lock (type)
                {
                    if (type.BaseType != null && !mTypes.ContainsKey(type))
                    {
                        MetaType? metaType;
                        if (type.BaseType == typeof(object))
                        {
                            metaType = mRuntimeTypeModel.Add(type, true);
                        }
                        else
                        {
                            if (!mTypes.TryGetValue(type.BaseType, out MetaType? baseMetaType))
                            {
                                baseMetaType = RegisterType(type.BaseType);
                            }

                            baseMetaType?.AddSubType(mSequenceFieldNumber++, type);

                            metaType = mRuntimeTypeModel.Add(type, true);
                        }

                        mTypes.Add(type, metaType);

                        return metaType;
                    }
                }

                return null;
            }

            public object Deserialize(Stream source, object? value, Type type)
            {
                return mRuntimeTypeModel.Deserialize(source, value, type);
            }

            public void Serialize(Stream dest, object value)
            {
                mRuntimeTypeModel.Serialize(dest, value);
            }

            public bool CanSerialize(Type type)
            {
                return mRuntimeTypeModel.CanSerialize(type);
            }
        }
    }
}
