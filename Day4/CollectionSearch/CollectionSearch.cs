#nullable enable

using System;
using System.Collections.Generic;

public static class CollectionSearch
{
    public static T? FindFirst<T>(
        IEnumerable<T>? items,
        Func<T, bool>? predicate)
    {
        if (items == null)
        {
            throw new ArgumentNullException(nameof(items));
        }

        if (predicate == null)
        {
            throw new ArgumentNullException(nameof(predicate));
        }

        foreach (T item in items)
        {
            if (predicate(item))
            {
                return item;
            }
        }

        return default;
    }
}