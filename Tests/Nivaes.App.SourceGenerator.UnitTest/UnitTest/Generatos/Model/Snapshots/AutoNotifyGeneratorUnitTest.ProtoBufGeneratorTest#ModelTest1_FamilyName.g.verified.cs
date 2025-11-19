//HintName: ModelTest1_FamilyName.g.cs

#nullable enable
#pragma warning disable 1591
using System.ComponentModel;
using Nivaes.App;

namespace Nivaes.App.Shared.Test
{
    public partial class ModelTest1 : Model, INotifyPropertyChanged
    {
        public string FamilyName
        {
            get => familyName;
            set => SetProperty(ref familyName, value);
        }
    }
}
