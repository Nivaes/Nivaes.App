using Nivaes.Serializer;

namespace Nivaes.App.Shared.Test;

[SerializePacker]
public sealed partial class ModelTest1
    : DataModel
{
    #region Dato01
    public Guid GuidData { get; set; }
    #endregion 
}
