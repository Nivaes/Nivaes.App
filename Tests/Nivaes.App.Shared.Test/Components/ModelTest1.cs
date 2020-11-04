
namespace Nivaes.App.Test
{
    using System;
    using ProtoBuf;
    using System.Runtime.Serialization;

    [ProtoContract(Name = "ModelTest1", ImplicitFirstTag = 100, ImplicitFields = ImplicitFields.None)]
    public sealed class ModelTest1
        : DataModel
    {
        #region TestDataModel01Id
        [ProtoMember(1, Name = "Dato01")]
        [DataMember(Name = "Dato01")]
        public Guid Dato01 { get; set; }
        #endregion 
    }
}
