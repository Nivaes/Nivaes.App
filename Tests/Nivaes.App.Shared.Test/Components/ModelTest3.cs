namespace Nivaes.App.Shared.Test
{
    using System.Runtime.Serialization;
    using ProtoBuf;

    [ProtoContract(Name = "ModelTest3", ImplicitFirstTag = 100, ImplicitFields = ImplicitFields.None)]
    public sealed class ModelTest3
        : DataModel
    {
        #region TestDataModel01Id
        [ProtoMember(1, Name = "StringData")]
        [DataMember(Name = "StringData")]
        public string StringData { get; set; } = string.Empty;
        #endregion 
    }
}
