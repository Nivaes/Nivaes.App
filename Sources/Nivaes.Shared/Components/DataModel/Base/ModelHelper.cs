namespace Nivaes
{
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Json;
    using System.Text;

    /// <summary>Helper for <see cref="IModel"/>.</summary>
    public static class ModelHelper
    {
        [DebuggerStepThrough]
        public static TModel? Clone<TModel>(this TModel model)
            where TModel : class, IModel
        {
            return CloneProtoBuf(model);
        }

        /// <summary>Clone a <see cref="IModel"/> object.</summary>
        /// <typeparam name="TModel">Type of object.</typeparam>
        /// <param name="model">Original model object.</param>
        /// <returns>New model object, clone of original.</returns>
        [DebuggerStepThrough]
        public static TModel? CloneDataContract<TModel>(this TModel model)
            where TModel : class, IModel
        {
            if (model == null)
                return null;

            using (MemoryStream stream = new MemoryStream())
            {
                DataContractSerializer ser = new DataContractSerializer(typeof(TModel),
                   new DataContractSerializerSettings()
                   {
                       MaxItemsInObjectGraph = int.MaxValue
                   });

                ser.WriteObject(stream, model);
                stream.Seek(0, SeekOrigin.Begin);
                return (TModel)ser.ReadObject(stream);
            }
        }

        /// <summary>Clone a <see cref="IModel"/> object.</summary>
        /// <typeparam name="TModel">Type of object.</typeparam>
        /// <param name="model">Original model object.</param>
        /// <returns>New model object, clone of original.</returns>
        [DebuggerStepThrough]
        public static TModel? CloneProtoBuf<TModel>(this TModel model)
            where TModel : class, IModel
        {
            if (model == null)
                return null;

            var cache = ProtoBufHelper.Serialize(model);
            return ProtoBufHelper.Deserialize<TModel>(cache);
        }

        #region Binary Serialization

        /// <summary>Crate a object for a byte array.</summary>
        /// <param name="data">Serialization object. In byte array format.</param>
        /// <returns>Reference to <see cref="DataModel"/> object.</returns>
        [DebuggerStepThrough]
        public static TModel? DeserializaDataContract<TModel>(byte[] data)
            where TModel : class, IModel
        {
            if (data == null)
                return null;

            using (MemoryStream stream = new MemoryStream(data))
            {
                DataContractSerializer ser = new DataContractSerializer(typeof(TModel),
                   new DataContractSerializerSettings()
                   {
                       MaxItemsInObjectGraph = int.MaxValue,
                   });
                return ser.ReadObject(stream) as TModel;
            }
        }

        /// <summary>Serialize a <see cref="DataModel"/>.</summary>
        /// <returns>Byte array that represent a object.</returns>
        [DebuggerStepThrough]
        public static byte[]? SerializeDataContract<TModel>(this TModel model)
            where TModel : class, IModel
        {
            if (model == null)
                return null;

            using (MemoryStream stream = new MemoryStream())
            {
                DataContractSerializer ser = new DataContractSerializer(model.GetType(),
                   new DataContractSerializerSettings()
                   {
                       MaxItemsInObjectGraph = int.MaxValue,
                   });
                ser.WriteObject(stream, model);
                return stream.ToArray();
            }
        }

        #endregion Binary Serialization

        #region Json Serialization

        /// <summary>Crate a object for a byte array.</summary>
        /// <param name="json">Serialization object. In byte array format.</param>
        /// <returns>Reference to <see cref="DataModel"/> object.</returns>
        [DebuggerStepThrough]
        public static TModel? DeserializeDataContractJson<TModel>(string json)
            where TModel : class, IModel
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(TModel),
                   new DataContractJsonSerializerSettings()
                   {
                       MaxItemsInObjectGraph = int.MaxValue,
                   });
                return ser.ReadObject(stream) as TModel;
            }
        }

        #endregion Json Serialization
    }
}
