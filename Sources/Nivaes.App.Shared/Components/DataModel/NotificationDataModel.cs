namespace Nivaes.App
{
    using System;
    using System.Globalization;
    using LightProto;
    using Nivaes;

    //[ProtoContract(Name = "Notification", ImplicitFirstTag = 100, ImplicitFields = ImplicitFields.None)]
    [DataModel]
    public sealed partial class NotificationDataModel
    //: IDataModel
    {
        [AutoNotify]
        private Guid idNotification;

        [AutoNotify]
        private Guid name;

        [AutoNotify(PropertyName="hola")]
        private string? text;

        //[ProtoMember(1, Name = "IdNotification")]
        //public Guid IdNotification { get; set; }

        //#region IdUser


        //[ProtoMember(2, Name = "IdUser")]
        //public Guid IdUser { get; set; }

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

        //private DateTime mDate;

        //[ProtoMember(4, Name = "Date")]
        //public DateTime Date
        //{
        //    get => mDate;
        //    set
        //    {
        //        if (this.SetProperty(ref mDate, value))
        //        {
        //            this.RaisePropertyChanged(nameof(DisplayData));
        //        }
        //    }
        //}

        //[ProtoIgnore]
        //public string DisplayData => string.Format(CultureInfo.CurrentCulture, "{0:f}", mDate).FirstCharToUpper();

        //#endregion Date
    }
}
