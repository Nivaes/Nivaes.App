namespace Nivaes.App
{
    using System.Buffers;
    using System.Diagnostics;
    using LightProto;

    /// <summary>Helper for <see cref="IModel"/>.</summary>
    public static class ModelHelper
    {
        [DebuggerStepThrough]
        public static TModel? Clone<TModel>(this TModel model)
            where TModel : class, IModel, IProtoParser<TModel>
        {
            return CloneProto(model);
        }

        /// <summary>Clone a <see cref="IModel"/> object.</summary>
        /// <typeparam name="TModel">Type of object.</typeparam>
        /// <param name="model">Original model object.</param>
        /// <returns>New model object, clone of original.</returns>
        [DebuggerStepThrough]
        public static TModel? CloneProto<TModel>(this TModel model)
            where TModel : class, IModel, IProtoParser<TModel>
        {
            if (model == null)
                return null;

            var buffer = new ArrayBufferWriter<byte>();
            Serializer.Serialize(buffer, model);
            return Serializer.Deserialize<TModel>(buffer.GetSpan());
        }
    }
}
