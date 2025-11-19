//HintName: ModelTest1_GuidData.g.cs

#nullable enable
#pragma warning disable 1591
using System.ComponentModel;
using Nivaes.App;

namespace Nivaes.App.Shared.Test
{
    public partial class ModelTest1 : Model, INotifyPropertyChanged
    {
        public System.Guid GuidData
        {
            get => guidData;
            set => SetProperty(ref guidData, value);
        }
    }
}
