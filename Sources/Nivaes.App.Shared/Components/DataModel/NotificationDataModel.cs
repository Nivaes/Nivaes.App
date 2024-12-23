namespace Nivaes.App
{
    using System;
    using System.Globalization;
    using ProtoBuf;
    using Nivaes;

    [ProtoContract(Name = "Notification", ImplicitFirstTag = 100, ImplicitFields = ImplicitFields.None)]
    public sealed class NotificationDataModel
        : DataModel
    {
        [ProtoMember(1, Name = "IdNotification")]
        public Guid IdNotification { get; set; }

        #region IdUser

        [ProtoMember(2, Name = "IdUser")]
        public Guid IdUser { get; set; }

        #endregion IdUser

        #region Text

        private string mText = string.Empty;

        [ProtoMember(3, Name = "Text")]
        public string Text
        {
            get => mText;
            set => base.SetProperty(ref mText, value);
        }

        #endregion Text

        #region Date

        private DateTime mDate;

        [ProtoMember(4, Name = "Date")]
        public DateTime Date
        {
            get => mDate;
            set
            {
                if (base.SetProperty(ref mDate, value))
                {
                    base.RaisePropertyChanged(nameof(DisplayData));
                }
            }
        }

        [ProtoIgnore]
        public string DisplayData => string.Format(CultureInfo.CurrentCulture, "{0:f}", mDate).FirstCharToUpper();

        #endregion Date
    }
}
