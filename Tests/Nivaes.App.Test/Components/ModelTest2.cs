using Nivaes.Serializer;

namespace Nivaes.App.Shared.Test;

[SerializeModel]
public sealed partial class ModelTest2
    : DataModel
{
    #region TestDataModel01Id
    public string? StringData { get; set; }
    #endregion 
}
