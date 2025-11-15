//HintName: ModelTest1_FamilyName.g.cs

#nullable enable
using System.ComponentModel;
using System.App;

namespace Nivaes.App.Shared.Test
{
    public partial class ModelTest1 : Model, INotifyPropertyChanged
    {
        public string FamilyName
        {
            get => familyName;
            set
            {
                if (!EqualityComparer<string>.Default.Equals(familyName, value))
                {
                    familyName = value;
                    OnPropertyChanged(nameof(FamilyName));
                }
            }
        }
    }
}
