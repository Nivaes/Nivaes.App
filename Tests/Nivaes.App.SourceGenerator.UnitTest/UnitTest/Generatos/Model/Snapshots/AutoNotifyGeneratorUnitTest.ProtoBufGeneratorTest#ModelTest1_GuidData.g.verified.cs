//HintName: ModelTest1_GuidData.g.cs

#nullable enable
using System.ComponentModel;
using System.App;

namespace Nivaes.App.Shared.Test
{
    public partial class ModelTest1 : Model, INotifyPropertyChanged
    {
        public System.Guid GuidData
        {
            get => guidData;
            set
            {
                if (!EqualityComparer<System.Guid>.Default.Equals(guidData, value))
                {
                    guidData = value;
                    OnPropertyChanged(nameof(GuidData));
                }
            }
        }
    }
}
