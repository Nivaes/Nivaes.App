namespace Nivaes.App
{
    using System.Buffers;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using MemoryPack;

    /// <summary>Helper for <see cref="IModel"/>.</summary>
    public static class ModelHelper
    {

        /// <summary>Clone a <see cref="IModel"/> object.</summary>
        /// <typeparam name="TModel">Type of object.</typeparam>
        /// <param name="model">Original model object.</param>
        /// <returns>New model object, clone of original.</returns>
        [DebuggerStepThrough]
        public static TModel? CloneProto<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TModel>(this TModel model)
            where TModel : class, IModel
        {
            if (model == null)
                return null;

            ArrayBufferWriter<byte> bufferWriter = new ArrayBufferWriter<byte>();

            MemoryPackSerializer.Serialize(bufferWriter, model);

            var datos = bufferWriter.WrittenSpan;
            
            return MemoryPackSerializer.Deserialize<TModel>(datos);
        }
    }
}
