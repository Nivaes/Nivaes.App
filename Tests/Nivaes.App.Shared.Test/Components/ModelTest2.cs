
namespace Nivaes.App.Test
{
    using System;
    using ProtoBuf;
    using System.Runtime.Serialization;

    [ProtoContract(Name = "ModelTest2", ImplicitFirstTag = 100, ImplicitFields = ImplicitFields.None)]
    public sealed class ModelTest2
        : DataModel
    {
        #region TestDataModel01Id
        [ProtoMember(1, Name = "StringData")]
        [DataMember(Name = "StringData")]
        public string? StringData { get; set; }
        #endregion 
    }
}
