using System.ComponentModel;
using Nivaes.Serializer;

namespace Nivaes.App
{
    public abstract class DataModel
        : Model, IDataModel, INotifyPropertyChanged
    {
        protected DataModel()
        { }

        [SerializeIgnore]
        public DateTime DateTimeStamp
        {
            get => new DateTime(DateTimeStampTicks, DateTimeKind.Utc);
            set => DateTimeStampTicks = value.Ticks;
        }

        public long DateTimeStampTicks
        {
            get => field == 0 ? field = DateTime.Now.Ticks : field;
            set => field = value;
        }

        [SerializeIgnore]
        public DateTime? DeleteDateTimeStamp
        {
            get => DeleteDateTimeStampTicks.HasValue
                ? new(DeleteDateTimeStampTicks.Value, DateTimeKind.Utc)
                : null;
            set => DeleteDateTimeStampTicks = value?.Ticks;
        }

        public long? DeleteDateTimeStampTicks { get; set; }
    }
}
