namespace Nivaes.App
{
    using System;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;
    using ProtoBuf;

    [ProtoContract(Name = "Model", ImplicitFields = ImplicitFields.None, SkipConstructor = true)]
    [DataContract(Name = "Model", Namespace = "http://nivaes")]
    [Serializable]
    public abstract class Model
        : IModel, INotifyPropertyChanged
    {
        protected Model()
        { }

        #region INotifyPropertyChanged

        /// <summary>Occurs when a property value changes.</summary>
        private PropertyChangedEventHandler? mPropertyChanged;

        /// <summary>Occurs when a property value changes.</summary>
        public event PropertyChangedEventHandler? PropertyChanged
        {
            add { mPropertyChanged += value; }
            remove { mPropertyChanged -= value; }
        }

        /// <summary>Raises the <see cref="PropertyChanged"/> event.</summary>
        /// <param name="propertyName">The property name of the property that has changed.</param>
        [DebuggerStepThrough]
        [SuppressMessage("Design", "CA1030:Use events where appropriate")]
        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            RaisePropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>Raises the <see cref="PropertyChanged"/> event.</summary>
        /// <param name="e">The <see cref="System.ComponentModel.PropertyChangedEventArgs"/> instance containing the event data.</param>
        [DebuggerStepThrough]
        [SuppressMessage("Design", "CA1030:Use events where appropriate")]
        protected void RaisePropertyChanged(PropertyChangedEventArgs e)
        {
            mPropertyChanged?.Invoke(this, e);
        }

        /// <summary>Change value of property.</summary>
        [DebuggerStepThrough]
        protected void RegisterNewValueProperty<T>(T property)
            where T : IModel
        {
            if (property == null) throw new NullReferenceException(nameof(property));

            property.PropertyChanged += RaisePropertyChanged;
        }

        /// <summary>Unregister change value of property.</summary>
        [DebuggerStepThrough]
        protected void UnregisterNewValueProperty<T>(T property)
            where T : IModel
        {
            if (property == null) throw new NullReferenceException(nameof(property));

            property.PropertyChanged -= RaisePropertyChanged;
        }

        /// <summary>Change value of property.</summary>
        [DebuggerStepThrough]
        [SuppressMessage("Microsoft.Design", "CA1045:DoNotPassTypesByReference", MessageId = "0#")]
        protected bool SetProperty<T>(ref T property, T newValue, [CallerMemberName] string propertyName = "")
        {
            if (object.Equals((object?)property, (object?)newValue))
            {
                return false;
            }
            else
            {
                IModel? propertyModel = property as IModel;

                if (propertyModel != null)
                    propertyModel.PropertyChanged -= RaisePropertyChanged;

                property = newValue;

                if (propertyModel != null)
                    propertyModel.PropertyChanged += RaisePropertyChanged;

                RaisePropertyChanged(propertyName);

                return true;
            }
        }

        [DebuggerStepThrough]
        [SuppressMessage("Microsoft.Design", "CA1045:DoNotPassTypesByReference", MessageId = "0#")]
        protected bool SetProperty<T>(ref T property, T newValue,
            Action<NotifyCollectionChangedEventArgs> notificationCollectionChanged, [CallerMemberName] string propertyName = "")
            where T : INotifyCollectionChanged
        {
            if (object.Equals((object)property, (object)newValue))
            {
                return false;
            }
            else
            {
                IModel? propertyModel = property as IModel;

                if (propertyModel != null)
                    propertyModel.PropertyChanged -= RaisePropertyChanged;

                property = newValue;

                if (propertyModel != null)
                    propertyModel.PropertyChanged += RaisePropertyChanged;

                if (property != null)
                    property.CollectionChanged += (o, e) => notificationCollectionChanged(e);

                RaisePropertyChanged(propertyName);

                return true;
            }
        }

        /// <summary>Response to <see cref="INotifyPropertyChanged.PropertyChanged"/> of fiscal office.</summary>
        [DebuggerStepThrough]
        private void RaisePropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            mPropertyChanged?.Invoke(sender, e);
        }

        #endregion INotifyPropertyChanged
    }
}
