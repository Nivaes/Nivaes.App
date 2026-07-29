namespace Nivaes.App.Shared.Test
{
    using System;
    using System.Runtime.Serialization;
    using MemoryPack;

    [MemoryPackable]
    public sealed partial class ModelTest1
        : DataModel
    {
        #region Dato01
        [MemoryPackInclude()]
        [DataMember(Name = "GuidData")]
        public Guid GuidData { get; set; }
        #endregion 
    }
}
