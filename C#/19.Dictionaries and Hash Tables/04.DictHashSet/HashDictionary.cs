using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictHashSet
{
    public class HashDictionary<K, V> : IDictionary<K, V>
    {
        private const int DEFAULT_CAPACITY = 16;
        private const double DEFAULT_LOAD_FACTOR = 0.75;
        private List<KeyValuePair<K, V>>[] table;
        private double loadFactor;
        private int treshold;
        private int size;
        private int initialCapacity;

        public HashDictionary()
            : this(DEFAULT_CAPACITY, DEFAULT_LOAD_FACTOR)
        {
        }

        private HashDictionary(int capacity, double loadFactor)
        {
            this.initialCapacity = capacity;
            this.loadFactor = loadFactor;
            this.table = new List<KeyValuePair<K, V>>[capacity];
            unchecked
            {
                this.treshold = (int)(this.loadFactor * capacity);
            }
        }

        private List<KeyValuePair<K, V>> FindChain(K key, bool createIfMissing)
        {
            int index = key.GetHashCode();
            index = Math.Abs(index % this.table.Length);

            if (this.table[index] == null && createIfMissing)
            {
                this.table[index] = new List<KeyValuePair<K, V>>();
            }
            return this.table[index];
        }

        private void Expand()
        {
            int newCapacity = this.table.Length * 2;
            List<KeyValuePair<K, V>>[] oldTable = this.table;
            this.table = new List<KeyValuePair<K, V>>[newCapacity];
            this.treshold = (int)(newCapacity * DEFAULT_LOAD_FACTOR);

            foreach (List<KeyValuePair<K, V>> oldChain in oldTable)
            {
                if (oldChain != null)
                {
                    foreach (KeyValuePair<K, V> oldPair in oldChain)
                    {
                        List<KeyValuePair<K, V>> chain = this.FindChain(oldPair.Key, true);
                        chain.Add(oldPair);
                    }
                }
            }
        }

        public V Get(K key)
        {
            List<KeyValuePair<K, V>> chain = this.FindChain(key, false);

            if (chain != null)
            {
                foreach (KeyValuePair<K, V> entry in chain)
                {
                    if (entry.Key.Equals(key))
                        return entry.Value;
                }
            }

            return default(V);
        }

        public V Set(K key, V value)
        {
            List<KeyValuePair<K, V>> chain = this.FindChain(key, true);

            for (int i = 0; i < chain.Count; i++)
            {
                KeyValuePair<K, V> entry = chain[i];
                if (entry.Key.Equals(key))
                {
                    chain[i] = new KeyValuePair<K, V>(key, value);
                    return entry.Value;
                }
            }

            chain.Add(new KeyValuePair<K, V>(key, value));
            if (this.size++ >= this.treshold)
            {
                this.Expand();
            }

            return default(V);
        }

        public V this[K key]
        {
            get
            {
                return this.Get(key);
            }
            set
            {
                this.Set(key, value);
            }
        }

        public List<K> Keys
        {
            get
            {
                List<K> keys = new List<K>();

                foreach (KeyValuePair<K,V> pair in this)
                {
                    keys.Add(pair.Key);
                }

                return keys;
            }
        }

        public List<V> Values
        {
            get
            {
                List<V> values = new List<V>();

                foreach (KeyValuePair<K, V> pair in this)
                {
                    values.Add(pair.Value);
                }

                return values;
            }
        }

        public int Count
        {
            get { return this.size; }
        }

        public bool ContainsKey(K key)
        {
            List<KeyValuePair<K, V>> chain = this.FindChain(key, false);

            if (chain != null)
            {
                foreach (KeyValuePair<K, V> pair in chain)
                {
                    if (pair.Key.Equals(key))
                        return true;
                }
            }

            return false;
        }

        public bool Remove(K key)
        {
            List<KeyValuePair<K, V>> chain = this.FindChain(key, false);

            if (chain != null)
            {
                for (int i = 0; i < chain.Count; i++)
                {
                    if (chain[i].Key.Equals(key)) 
                    {
                        chain.RemoveAt(i);
                        this.size--;
                        return true;
                    }
                }
            }

            return false;
        }

        public void Clear()
        {
            if (this.table != null)
            {
                this.table = new List<KeyValuePair<K, V>>[initialCapacity];
            }
            this.size = 0;
        }

        IEnumerator<KeyValuePair<K, V>>
            IEnumerable<KeyValuePair<K, V>>.GetEnumerator()
        {
            foreach(List<KeyValuePair<K, V>> chain in this.table) 
            {
                if (chain != null)
                {
                    foreach (KeyValuePair<K, V> pair in chain)
                    {
                        yield return pair;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<K, V>>)this).
                  GetEnumerator();
        }
    }
}
