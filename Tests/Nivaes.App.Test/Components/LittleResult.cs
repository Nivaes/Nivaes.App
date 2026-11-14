using Nivaes.Serializer;

namespace Nivaes.App.Shared.Test;

[SerializeModel]
public partial class LittleResult
    : Result
{
    public bool EndValue { get; set; }
}
