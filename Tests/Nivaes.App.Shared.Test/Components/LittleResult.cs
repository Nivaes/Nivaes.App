namespace Nivaes.App.Shared.Test
{
     using MemoryPack;

    [MemoryPackable]
    public partial class LittleResult
        : Result
    {
        [MemoryPackInclude]
        public bool EndValue { get; set; }
    }
}
