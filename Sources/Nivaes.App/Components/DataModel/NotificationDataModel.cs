using System.Globalization;
using MemoryPack;

namespace Nivaes.App
{
    //[MemoryPackable]
    //[DataModel]
    public sealed class NotificationDataModel
        : DataModel
    {
        //[AutoNotify]
        //private Guid idNotification;
        public Guid IdNotification { get; set; }

        //[AutoNotify]
        //private Guid name;
        public Guid Name { get; set;  }

        //[AutoNotify()]
        //private string? text;
        public string? Text { get; set; }

        //[ProtoMember(1, Name = "IdNotification")]
        //public Guid IdNotification { get; set; }

        //#region IdUser


        //[ProtoMember(2, Name = "IdUser")]
        public Guid IdUser { get; set; }

        //#endregion IdUser

        //#region Text

        //private string mText = string.Empty;

        //[ProtoMember(3, Name = "Text")]
        //public string Text
        //{
        //    get => mText;
        //    set => base.SetProperty(ref mText, value);
        //}

        //#endregion Text

        //#region Date
        //[AutoNotify()]
        private DateTime mDate;

        ////[ProtoMember(4, Name = "Date")]
        public DateTime Date
        {
            get => mDate;
            set
            {
                if (SetProperty(ref mDate, value))
                {
                    RaisePropertyChanged(nameof(DisplayData));
                }
            }
        }

        public string DisplayData => string.Format(CultureInfo.CurrentCulture, "{0:f}", mDate).FirstCharToUpper();

        //#endregion Date
    }
}
