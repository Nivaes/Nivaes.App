using System.ComponentModel;

namespace Nivaes.App
{
    public abstract partial class DataModel
        : Model, IDataModel, INotifyPropertyChanged
    {
        protected DataModel()
        { }

        public DateTime DateTimeStamp
        {
            get => new DateTime(DateTimeStampTicks, DateTimeKind.Utc);
            set => DateTimeStampTicks = value.Ticks;
        }

        public long DateTimeStampTicks
        {
            get => field == 0 ? DateTime.Now.Ticks : field;
            set => field = value;
        }

        //[MemoryPackIgnore]
        public DateTime? DeleteDataTimeStamp
        {
            get => DeleteDateTimeStampTicks.HasValue
                ? new(DeleteDateTimeStampTicks.Value, DateTimeKind.Utc)
                : null;
            set => DeleteDateTimeStampTicks = value?.Ticks;
        }

        public long? DeleteDateTimeStampTicks { get; set; }
    }
}
