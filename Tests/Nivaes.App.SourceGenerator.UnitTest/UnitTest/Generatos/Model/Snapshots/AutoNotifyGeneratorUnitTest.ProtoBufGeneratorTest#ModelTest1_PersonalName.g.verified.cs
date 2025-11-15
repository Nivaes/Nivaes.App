//HintName: ModelTest1_PersonalName.g.cs

#nullable enable
using System.ComponentModel;
using Nivaes.App;

namespace Nivaes.App.Shared.Test
{
    public partial class ModelTest1 : Model, INotifyPropertyChanged
    {
        public string PersonalName
        {
            get => personalName;
            set => SetProperty(ref personalName, value);
        }
    }
}
