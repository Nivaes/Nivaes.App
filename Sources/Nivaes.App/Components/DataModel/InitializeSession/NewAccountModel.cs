namespace Nivaes.App
{
    public class NewAccountModel : Model
    {
        public AccountDataModel? Account
        {
            get => field;
            set => base.SetProperty(ref field, value);
        }

        public string? Password
        {
            get => field;
            set => base.SetProperty(ref field, value);
        }
    }
}
