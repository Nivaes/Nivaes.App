namespace Nivaes.App.Shared.Test
{
    using System.ComponentModel.DataAnnotations;
    using MemoryPack;

    [MemoryPackable]
    public partial class BigResult
        : Result
    {
        public BigDatamodel? ContentValue { get; set; }
    }

    [MemoryPackable]
    public partial class BigDatamodel
        : DataModel
    {
        public Guid IdBid { get; set; }

        private string? mTextValue1 = string.Empty;

        [MaxLength(20)]
        [ConcurrencyCheck]
        [Required]
        public string? TextValue1
        {
            get => mTextValue1;
            set => base.SetProperty(ref mTextValue1, value);
        }

        private string? mTextValue2 = string.Empty;

        public string? TextValue2
        {
            get => mTextValue2;
            set => base.SetProperty(ref mTextValue2, value);
        }

        private string? mBigTextValue = string.Empty;

        public string? BigTextValue
        {
            get => mBigTextValue;
            set => base.SetProperty(ref mBigTextValue, value);
        }

        //[ProtoIgnore]
        public string? TextValue => string.Join(",", mTextValue1, mTextValue2);


        private int? mIntValue1;

        //[ProtoMember(5, Name = "IntValue")]
        public int? IntValue
        {
            get => mIntValue1;
            set => base.SetProperty(ref mIntValue1, value);
        }
    }
}
