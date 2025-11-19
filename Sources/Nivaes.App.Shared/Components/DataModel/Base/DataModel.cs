namespace Nivaes.App
{
    using System;
    using System.ComponentModel;
    using MemoryPack;

    public abstract partial class DataModel
        : Model, IDataModel, INotifyPropertyChanged
    {
        protected DataModel()
        { }

        private DateTime mTimeStamp;

        [MemoryPackIgnore]
        public DateTime TimeStamp
        {
            get => mTimeStamp;
            set => mTimeStamp = value;
        }

        [MemoryPackInclude]
        public long TimeStampTicks
        {
            get => mTimeStamp.Ticks;
            set => mTimeStamp = new DateTime(value, DateTimeKind.Utc);
        }
    }
}
