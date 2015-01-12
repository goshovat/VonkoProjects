using System;
using System.Collections.Generic;

namespace DictHashSet
{
    public interface IDictionary<K, V> : IEnumerable<KeyValuePair<K, V>>
    {
        V Set(K key, V value);

        V Get(K key);

        V this[K key] { get; set; }

        bool Remove(K key);

        int Count { get; }

        void Clear();
    }
}
