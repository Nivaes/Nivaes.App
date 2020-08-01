//namespace Nivaes
//{
//    using System;
//    using System.Collections;
//    using System.Collections.Generic;
//    using System.Collections.ObjectModel;
//    using System.Collections.Specialized;
//    using System.ComponentModel;
//    using System.Text;
//    using System.Threading.Tasks;

//    public class DataLoadObservableCollection<T>
//        : IEnumerable<T>, INotifyCollectionChanged
//    {
//        //public DataLoadObservableCollection(Func<IList<T>> firstLoad, Func<IList<T>> restLoad)
//        //{
//        //}

//        //public DataLoadObservableCollection(Func<Task<IList<T>>> firstLoad, Func<Task<IList<T>>> restLoad)
//        //{
//        //}

//        //public void AddRange(IList<T> items)
//        //{
//        //    foreach(var item in items)
//        //        base.Add(item);

//        //    CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, items));
//        //}

//        public event NotifyCollectionChangedEventHandler CollectionChanged;

//        IEnumerator<T> IEnumerable<T>.GetEnumerator()
//        {
//            return new DataLoadEnumerator<T>();
//        }

//        IEnumerator IEnumerable.GetEnumerator()
//        {
//            return new DataLoadEnumerator<T>();
//        }

//        private void OnCollectionChanged()
//        {
//            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add));
//        }

//        //protected override void ClearItems()
//        //{
//        //    base.ClearItems();
//        //}

//        //protected override void InsertItem(int index, T item)
//        //{
//        //    base.InsertItem(index, item);
//        //}

//        //protected override void MoveItem(int oldIndex, int newIndex)
//        //{
//        //    base.MoveItem(oldIndex, newIndex);
//        //}

//        //protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
//        //{
//        //    base.OnCollectionChanged(e);
//        //}

//        //protected override void OnPropertyChanged(PropertyChangedEventArgs e)
//        //{
//        //    base.OnPropertyChanged(e);
//        //}

//        //protected override void RemoveItem(int index)
//        //{
//        //    base.RemoveItem(index);
//        //}

//        //protected override void SetItem(int index, T item)
//        //{
//        //    base.SetItem(index, item);
//        //}
//    }

//    public class DataLoadEnumerator<T>
//        : IEnumerator<T>
//    {
//        public DataLoadEnumerator()
//        {
//        }

//        public T Current => throw new NotImplementedException();

//        object IEnumerator.Current => throw new NotImplementedException();

//        public void Dispose()
//        {
//            throw new NotImplementedException();
//        }

//        public bool MoveNext()
//        {
//            throw new NotImplementedException();
//        }

//        public void Reset()
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
