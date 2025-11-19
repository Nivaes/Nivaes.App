//HintName: ModelTest1_MAge.g.cs

#nullable enable
#pragma warning disable 1591
using System.ComponentModel;
using Nivaes.App;

namespace Nivaes.App.Shared.Test
{
    public partial class ModelTest1 : Model, INotifyPropertyChanged
    {
        public int MAge
        {
            get => mAge;
            set => SetProperty(ref mAge, value);
        }
    }
}
