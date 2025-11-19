namespace Nivaes.App.Shared.Test
{
    using System.Runtime.Serialization;
    using MemoryPack;

    [MemoryPackable]
    public sealed partial class ModelTest3
        : DataModel
    {
        #region TestDataModel01Id
        [MemoryPackInclude]
        [DataMember(Name = "StringData")]
        public string StringData { get; set; } = string.Empty;
        #endregion 
    }
}
