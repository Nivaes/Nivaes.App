using System.Collections;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;

namespace Nivaes.App
{
    public class WeakEventSource<TEventArgs>
    {
        private readonly DelegateCollection mHandlers;

        public WeakEventSource()
        {
            mHandlers = new DelegateCollection();
        }

        public void Raise(object sender, TEventArgs e)
        {
            List<StrongHandler> validHandlers;
            lock (mHandlers)
            {
                validHandlers = new List<StrongHandler>(mHandlers.Count);
                for (int i = 0; i < mHandlers.Count; i++)
                {
                    var weakHandler = mHandlers[i];
                    if (weakHandler != null)
                    {
                        if (weakHandler.TryGetStrongHandler() is StrongHandler handler)
                            validHandlers.Add(handler);
                        else
                            mHandlers.Invalidate(i);
                    }
                }

                mHandlers.CollectDeleted();
            }

            foreach (var handler in validHandlers)
            {
                handler.Invoke(sender, e);
            }
        }

        [DebuggerStepperBoundary]
        public void Subscribe(EventHandler<TEventArgs> handler)
        {
            if (handler == null) throw new ArgumentNullException(nameof(handler));

            var singleHandlers = handler
                .GetInvocationList()
                .Cast<EventHandler<TEventArgs>>()
                .ToList();

            lock (mHandlers)
            {
                foreach (var h in singleHandlers)
                    mHandlers.Add(h);
            }
        }

        [DebuggerStepperBoundary]
        public void Unsubscribe(EventHandler<TEventArgs> handler)
        {
            if (handler == null) throw new ArgumentNullException(nameof(handler));

            var singleHandlers = handler
                .GetInvocationList()
                .Cast<EventHandler<TEventArgs>>();

            lock (mHandlers)
            {
                foreach (var singleHandler in singleHandlers)
                {
                    mHandlers.Remove(singleHandler);
                }

                mHandlers.CollectDeleted();
            }
        }

        private delegate void OpenEventHandler(object target, object sender, TEventArgs e);

        private sealed class WeakDelegate
        {
            #region Open handler generation and cache

            // ReSharper disable once StaticMemberInGenericType (by design)
            private static readonly ConcurrentDictionary<MethodInfo, OpenEventHandler> OpenHandlerCache =
                new ConcurrentDictionary<MethodInfo, OpenEventHandler>();

            private static OpenEventHandler CreateOpenHandler(MethodInfo method)
            {
                var target = Expression.Parameter(typeof(object), "target");
                var sender = Expression.Parameter(typeof(object), "sender");
                var e = Expression.Parameter(typeof(TEventArgs), "e");

                if (method.IsStatic)
                {
                    var expr = Expression.Lambda<OpenEventHandler>(
                        Expression.Call(
                            method,
                            sender, e),
                        target, sender, e);
                    return expr.Compile();
                }
                else
                {
                    var expr = Expression.Lambda<OpenEventHandler>(
                        Expression.Call(
                            Expression.Convert(target, method.DeclaringType),
                            method,
                            sender, e),
                        target, sender, e);
                    return expr.Compile();
                }
            }

            #endregion

            private readonly WeakReference? weakTarget;
            private readonly MethodInfo method;
            private readonly OpenEventHandler openHandler;

            public WeakDelegate(Delegate handler)
            {
                weakTarget = handler.Target != null ? new WeakReference(handler.Target) : null;
                method = handler.GetMethodInfo();
                openHandler = OpenHandlerCache.GetOrAdd(method, CreateOpenHandler);
            }

            public StrongHandler? TryGetStrongHandler()
            {
                object? target = null;
                if (weakTarget != null)
                {
                    target = weakTarget.Target;
                    if (target == null)
                        return null;
                }

                return new StrongHandler(target, openHandler);
            }

            public bool IsMatch(EventHandler<TEventArgs> handler)
            {
                return ReferenceEquals(handler.Target, weakTarget?.Target)
                       && handler.GetMethodInfo().Equals(method);
            }

            public static int GetHashCode(EventHandler<TEventArgs> handler)
            {
                var hashCode = -335093136;
                hashCode = hashCode * -1521134295 + (handler?.Target?.GetHashCode()).GetValueOrDefault();
                hashCode = hashCode * -1521134295 + (handler?.GetMethodInfo()?.GetHashCode()).GetValueOrDefault();
                return hashCode;
            }
        }

        private struct StrongHandler
        {
            private readonly object? _target;
            private readonly OpenEventHandler _openHandler;

            public StrongHandler(object? target, OpenEventHandler openHandler)
            {
                _target = target;
                _openHandler = openHandler;
            }

            public void Invoke(object sender, TEventArgs e)
            {
                _openHandler(_target, sender, e);
            }
        }

        private class DelegateCollection : IEnumerable<WeakDelegate>
        {
            private List<WeakDelegate> _delegates;

            private readonly Dictionary<long, List<int>> _index;

            private int _deletedCount;

            public DelegateCollection()
            {
                _delegates = new List<WeakDelegate>();
                _index = new Dictionary<long, List<int>>();
            }

            public void Add(EventHandler<TEventArgs> singleHandler)
            {
                _delegates.Add(new WeakDelegate(singleHandler));
                var index = _delegates.Count - 1;
                AddToIndex(singleHandler, index);
            }

            public void Invalidate(int index)
            {
                _delegates.RemoveAt(index);
                _deletedCount++;
            }

            internal void Remove(EventHandler<TEventArgs> singleHandler)
            {
                var hashCode = WeakDelegate.GetHashCode(singleHandler);

                if (!_index.ContainsKey(hashCode))
                    return;

                var indices = _index[hashCode];
                for (int i = indices.Count - 1; i >= 0; i--)
                {
                    int index = indices[i];
                    if (_delegates[index] != null &&
                        _delegates[index].IsMatch(singleHandler))
                    {
                        _delegates.RemoveAt(index);
                        _deletedCount++;
                        indices.Remove(i);
                    }
                }

                if (indices.Count == 0)
                    _index.Remove(hashCode);
            }

            public void CollectDeleted()
            {
                if (_deletedCount < _delegates.Count / 4)
                    return;

                Dictionary<int, int> newIndices = new Dictionary<int, int>();
                var newDelegates = new List<WeakDelegate>();
                int oldIndex = 0;
                int newIndex = 0;
                foreach (var item in _delegates)
                {
                    if (item != null)
                    {
                        newDelegates.Add(item);
                        newIndices.Add(oldIndex, newIndex);
                        newIndex++;
                    }

                    oldIndex++;
                }

                _delegates = newDelegates;

                var hashCodes = _index.Keys.ToList();
                foreach (var hashCode in hashCodes)
                {
                    _index[hashCode] = _index[hashCode]
                        .Where(oi => newIndices.ContainsKey(oi))
                        .Select(oi => newIndices[oi]).ToList();
                }

                _deletedCount = 0;
            }

            private void AddToIndex(EventHandler<TEventArgs> singleHandler, int index)
            {
                var hashCode = WeakDelegate.GetHashCode(singleHandler);
                if (_index.ContainsKey(hashCode))
                    _index[hashCode].Add(index);
                else
                    _index.Add(hashCode, new List<int> { index });
            }

            public WeakDelegate this[int index] => _delegates[index];

            /// <summary>Returns an enumerator that iterates through the collection.</summary>
            /// <returns>A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.</returns>
            public IEnumerator<WeakDelegate> GetEnumerator()
            {
                return _delegates.GetEnumerator();
            }

            /// <summary>Returns an enumerator that iterates through a collection.</summary>
            /// <returns>An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.</returns>
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public int Count => _delegates.Count;
        }
    }
}
