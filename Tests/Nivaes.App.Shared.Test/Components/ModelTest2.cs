namespace Nivaes.App.Shared.Test
{
    using System.Runtime.Serialization;
    using LightProto;

    [ProtoContract(Name = "ModelTest2", ImplicitFirstTag = 100, ImplicitFields = ImplicitFields.None)]
    public sealed partial class ModelTest2
        : DataModel
    {
        #region TestDataModel01Id
        [ProtoMember(1, Name = "StringData")]
        [DataMember(Name = "StringData")]
        public string? StringData { get; set; }
        #endregion 
    }
}
