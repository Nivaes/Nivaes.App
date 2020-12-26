namespace Nivaes.App.Shared.Test
{
    using System;
    using System.Runtime.Serialization;
    using ProtoBuf;

    [ProtoContract(Name = "ModelTest1", ImplicitFirstTag = 100, ImplicitFields = ImplicitFields.None)]
    public sealed class ModelTest1
        : DataModel
    {
        #region Dato01
        [ProtoMember(1, Name = "GuidData")]
        [DataMember(Name = "GuidData")]
        public Guid GuidData { get; set; }
        #endregion 
    }
}
