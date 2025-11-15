//HintName: ModelTest1_PersonalName.g.cs

#nullable enable
using System.ComponentModel;
using System.App;

namespace Nivaes.App.Shared.Test
{
    public partial class ModelTest1 : Model, INotifyPropertyChanged
    {
        public string PersonalName
        {
            get => personalName;
            set
            {
                if (!EqualityComparer<string>.Default.Equals(personalName, value))
                {
                    personalName = value;
                    OnPropertyChanged(nameof(PersonalName));
                }
            }
        }
    }
}
