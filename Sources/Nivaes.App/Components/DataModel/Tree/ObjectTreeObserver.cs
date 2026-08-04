//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Collections.Specialized;
//using System.ComponentModel;
//using System.Reflection;
//using System.Text;

//namespace Nivaes.App;

//public class ObjectTreeObserver : IDisposable
//{
//    private readonly HashSet<object> _visited =
//        new(ReferenceEqualityComparer.Instance);

//    public event EventHandler? TreeChanged;

//    public void Observe(object? root)
//    {
//        Clear();
//        Attach(root);
//    }

//    private void Attach(object? obj)
//    {
//        if (obj is null)
//            return;

//        if (!_visited.Add(obj))
//            return;

//        if (obj is INotifyPropertyChanged npc)
//            npc.PropertyChanged += PropertyChanged;

//        if (obj is INotifyCollectionChanged ncc)
//            ncc.CollectionChanged += CollectionChanged;

//        foreach (var child in GetChildren(obj))
//            Attach(child);
//    }

//    private void PropertyChanged(object? sender, PropertyChangedEventArgs e)
//    {
//        TreeChanged?.Invoke(sender!, EventArgs.Empty);

//        if (sender != null)
//        {
//            foreach (var child in GetChildren(sender))
//            {
//                Attach(child);
//            }
//        }
//    }

//    private void CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
//    {
//        TreeChanged?.Invoke(sender!, EventArgs.Empty);

//        if (e.NewItems != null)
//        {
//            foreach (var item in e.NewItems)
//            {
//                Attach(item);
//            }
//        }
//    }

//    private static IEnumerable<object> GetChildren(object obj)
//    {
//        foreach (var property in obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
//        {
//            if (!property.CanRead)
//                continue;

//            if (property.PropertyType == typeof(string))
//                continue;

//            object? value;

//            try
//            {
//                value = property.GetValue(obj);
//            }
//            catch
//            {
//                continue;
//            }

//            if (value == null)
//                continue;

//            if (value is IEnumerable enumerable && value is not string)
//            {
//                foreach (var item in enumerable)
//                {
//                    if (item != null)
//                    {
//                        yield return item;
//                    }
//                }
//            }
//            else
//            {
//                yield return value;
//            }
//        }
//    }

//    public void Clear()
//    {
//        foreach (var obj in _visited)
//        {
//            if (obj is INotifyPropertyChanged npc)
//                npc.PropertyChanged -= PropertyChanged;

//            if (obj is INotifyCollectionChanged ncc)
//                ncc.CollectionChanged -= CollectionChanged;
//        }

//        _visited.Clear();
//    }

//    public void Dispose()
//    {
//        Dispose(true);
//        GC.SuppressFinalize(this);
//    }

//    private void Dispose(bool disposing)
//    {
//        if (disposing)
//        {
//            Clear();
//        }
//    }
//}
