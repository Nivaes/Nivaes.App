namespace Nivaes.App.Shared.Test
{
    using System.ComponentModel.DataAnnotations;
    using ProtoBuf;

    [ProtoContract(Name = "BigResult", ImplicitFirstTag = 100, ImplicitFields = ImplicitFields.None, SkipConstructor = true)]
    public class BigResult
        : Result, IDataModelProtobuf
    {
        [ProtoMember(1, Name = "ContentValue")]
        public BigDatamodel? ContentValue { get; set; }
    }

    [ProtoContract(Name = "BigDatamodel", ImplicitFirstTag = 100, ImplicitFields = ImplicitFields.None, SkipConstructor = false)]
    public class BigDatamodel
        : DataModel
    {
        [ProtoMember(1, Name = "IdAccount")]
        public Guid IdBid { get; set; }

        private string? mTextValue1 = string.Empty;

        [MaxLength(20)]
        [ConcurrencyCheck]
        [Required]
        [ProtoMember(2, Name = "TaxtValue1")]
        public string? TextValue1
        {
            get => mTextValue1;
            set => base.SetProperty(ref mTextValue1, value);
        }

        private string? mTextValue2 = string.Empty;

        [ProtoMember(3, Name = "TaxtValue2")]
        public string? TextValue2
        {
            get => mTextValue2;
            set => base.SetProperty(ref mTextValue2, value);
        }

        private string? mBigTextValue = string.Empty;

        [ProtoMember(4, Name = "BigTextValue")]
        public string? BigTextValue
        {
            get => mBigTextValue;
            set => base.SetProperty(ref mBigTextValue, value);
        }

        [ProtoIgnore]
        public string? TextValue => string.Join(",", mTextValue1, mTextValue2);


        private int? mIntValue1;

        [ProtoMember(5, Name = "IntValue")]
        public int? IntValue
        {
            get => mIntValue1;
            set => base.SetProperty(ref mIntValue1, value);
        }
    }
}
