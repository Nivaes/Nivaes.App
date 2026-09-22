using System.ComponentModel;
using MemoryPack;

namespace Nivaes.App
{
    public abstract partial class DataModel
        : Model, IDataModel, INotifyPropertyChanged
    {
        protected DataModel()
        { }

        [MemoryPackIgnore]
        public DateTime DateTimeStamp
        {
            get => new DateTime(DateTimeStampTicks, DateTimeKind.Utc);
            set => DateTimeStampTicks = value.Ticks;
        }

        [MemoryPackInclude]
        [MemoryPackOrder(0)]
        public long DateTimeStampTicks
        {
            get => field == 0 ? DateTime.Now.Ticks : field;
            set => field = value;
        }

        [MemoryPackIgnore]
        public DateTime? DeleteDataTimeStamp
        {
            get => DeleteDateTimeStampTicks.HasValue
                ? new(DeleteDateTimeStampTicks.Value, DateTimeKind.Utc)
                : null;
            set => DeleteDateTimeStampTicks = value?.Ticks;
        }

        [MemoryPackInclude]
        [MemoryPackOrder(1)]
        public long? DeleteDateTimeStampTicks { get; set; }
    }
}
