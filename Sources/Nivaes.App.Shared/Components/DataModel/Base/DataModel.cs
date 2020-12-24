namespace Nivaes.App
{
    using System;
    using System.ComponentModel;
    using System.Runtime.Serialization;
    using ProtoBuf;

    [ProtoContract(Name = "DataModel", ImplicitFirstTag = 100, ImplicitFields = ImplicitFields.None, SkipConstructor = true)]
    [DataContract(IsReference = false, Name = "DataModel", Namespace = "http://nivaes")]
    [Serializable]
    public abstract class DataModel
        : Model, IDataModel, INotifyPropertyChanged
    {
        protected DataModel()
        { }

        private DateTime mTimeStamp;

        [ProtoIgnore]
        [DataMember(Name = "TimeStamp")]
        public DateTime TimeStamp
        {
            get => mTimeStamp;
            set => mTimeStamp = value;
        }

        [ProtoMember(99999999, Name = "TimeStampTicks")]
        public long TimeStampTicks
        {
            get => mTimeStamp.Ticks;
            set => mTimeStamp = new DateTime(value, DateTimeKind.Utc);
        }
    }
}
