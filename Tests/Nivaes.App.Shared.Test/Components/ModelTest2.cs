namespace Nivaes.App.Shared.Test
{
    using System.Runtime.Serialization;
    using MemoryPack;

    [MemoryPackable]
    public sealed partial class ModelTest2
        : DataModel
    {
        #region TestDataModel01Id
        [MemoryPackIgnore]
        [DataMember(Name = "StringData")]
        public string? StringData { get; set; }
        #endregion 
    }
}
