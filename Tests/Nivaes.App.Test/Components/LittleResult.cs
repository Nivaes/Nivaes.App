using Nivaes.Serializer;

namespace Nivaes.App.Shared.Test;

[SerializePacker]
public partial class LittleResult
    : Result
{
    public bool EndValue { get; set; }
}
