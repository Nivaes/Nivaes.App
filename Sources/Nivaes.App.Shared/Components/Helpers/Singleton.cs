namespace Nivaes.App
{
    using System;
    using System.Collections.Concurrent;

    public static class Singleton<T>
         where T : new()
    {
        private static ConcurrentDictionary<Type, T> mInstances = new ConcurrentDictionary<Type, T>();

        public static T Instance => mInstances.GetOrAdd(typeof(T), (_) => new T());
    }
}
