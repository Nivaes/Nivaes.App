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
        public DateTime TimeStamp
        {
            get => new DateTime(TimeStampTicks, DateTimeKind.Utc);
            set => TimeStampTicks = value.Ticks;
        }

        [MemoryPackInclude]
        public long TimeStampTicks
        {
            get
            {
                if(field == 0)
                    field = DateTime.Now.Ticks;
                return field;
            }
            set => field = value;
        }
    }
}
