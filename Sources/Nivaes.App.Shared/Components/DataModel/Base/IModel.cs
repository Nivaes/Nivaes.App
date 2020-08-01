namespace Nivaes
{
    using System.ComponentModel;

    /// <summary>Interface for <see cref="Model"/> and <see cref="DataModel"/>.</summary>
    public interface IModel
        : IDataModelProtobuf, INotifyPropertyChanged
    {
    }
}
