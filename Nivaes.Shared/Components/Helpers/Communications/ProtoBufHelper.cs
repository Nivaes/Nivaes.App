namespace Nivaes
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using ProtoBuf;
    using ProtoBuf.Meta;

    //https://stackoverflow.com/questions/12308196/protobuf-net-serialization-without-annotation

    public static class ProtoBufHelper
    {
        public static RuntimeTypeModel Default { get; private set; }

        static ProtoBufHelper()
        {
            Default = new ProccessModel().LoadRuntimeTypeModelDefaultDataModel();
        }

        /// <summary>Initialize load runtime.</summary>
        public static void LoadCache()
        { }

        public static void RegisterType(Type type)
        {
            Default.Add(type, true);
        }

        public static bool CanSerialize(Type type)
        {
            return Default.CanSerialize(type);
        }

        public static byte[] Serialize<T>(T value)
        {
            using var ms = new MemoryStream();

            Default.Serialize(ms, value);

            return ms.ToArray();
        }

        public static T Deserialize<T>(byte[] payload)
        {
            try
            {
                using var ms = new MemoryStream(payload);

                var aa = ProtoBufHelper.Default.Deserialize(ms, null, typeof(T));

                //var aa = System.Runtime.Serialization.FormatterServices.GetUninitializedObject(typeof(T));
                //var cc = ProtoBufHelper.Default.Deserialize(ms, aa, typeof(T));

                return (T)aa;
            }
            catch (ArgumentException ex)
            {
                throw new NetException($"Error deserializing {typeof(T).FullName}", ex);
            }
            catch (Exception ex)
            {
                throw new NetException($"Error deserializing {typeof(T).FullName}", ex);
            }
        }

        private class ProccessModel
        {
            private int mSequenceFieldNumber = 1;
            private RuntimeTypeModel mModel;
            private Dictionary<Type, MetaType> mTypes;

            [SuppressMessage("Design", "CA1031:Do not catch general exception types")]
            public RuntimeTypeModel LoadRuntimeTypeModelDefaultDataModel()
            {
                mModel = RuntimeTypeModel.Create();

                mTypes = new Dictionary<Type, MetaType>();

                RegisterType(typeof(Model));
                RegisterType(typeof(DataModel));
                RegisterType(typeof(Result));
                RegisterType(typeof(Request));

                var assemblies = AppDomain.CurrentDomain.GetAssemblies();

                foreach (var assembly in assemblies)
                {
                    try
                    {
                        var availableTypes = from t in assembly.DefinedTypes
                                             where t.IsClass && typeof(IDataModelProtobuf).IsAssignableFrom(t)
                                             select t;

                        foreach (var type in availableTypes)
                        {
                            var protoContractAttribute = type.GetCustomAttribute<ProtoContractAttribute>();
                            if (protoContractAttribute != null)
                            {
                                RegisterType(type);
                            }
                        }
                    }
                    catch (ReflectionTypeLoadException) { }
                    //catch (TypeInitializationException) { }
                    catch (TypeLoadException) { }
                }

                return mModel;
            }

            private MetaType RegisterType(Type type)
            {
                Console.WriteLine(type.FullName);

                if (!mTypes.ContainsKey(type))
                {
                    MetaType metaType;
                    if (type.BaseType == typeof(object))
                    {
                        metaType = mModel.Add(type, true);
                    }
                    else
                    {
                        if (!mTypes.TryGetValue(type.BaseType, out MetaType baseMetaType))
                        {
                            baseMetaType = RegisterType(type.BaseType);
                        }

                        baseMetaType?.AddSubType(mSequenceFieldNumber++, type);

                        metaType = mModel.Add(type, true);
                    }

                    mTypes.Add(type, metaType);

                    //mSequenceFieldNumber++;
                    //mSequenceFieldNumber += type.GetMembers().Length;

                    return metaType;
                }

                return null;
            }
        }
    }
}
