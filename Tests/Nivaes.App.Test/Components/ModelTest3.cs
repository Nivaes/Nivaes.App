using Nivaes.Serializer;

namespace Nivaes.App.Shared.Test
{
    [SerializeModel]
    public sealed partial class ModelTest3
        : DataModel
    {
        #region TestDataModel01Id
        public string StringData { get; set; } = string.Empty;
        #endregion 
    }
}
