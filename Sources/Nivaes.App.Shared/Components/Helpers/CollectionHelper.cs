namespace Nivaes
{
    using System;
    using System.Collections.Generic;

    public static class CollectionHelper
    {
        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> query)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (query == null) throw new ArgumentNullException(nameof(query));

            foreach (T value in query)
            {
                collection.Add(value);
            }
        }
    }
}
