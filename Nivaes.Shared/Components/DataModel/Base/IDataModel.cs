namespace Nivaes
{
    using System.ComponentModel;

    /// <summary>Interface for <see cref="DataModel"/>.</summary>
    public interface IDataModel
        : IModel, IDataModelProtobuf, INotifyPropertyChanged
    {
    }
}
