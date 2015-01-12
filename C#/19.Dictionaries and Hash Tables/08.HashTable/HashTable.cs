using System;
using System.Collections;
using DictHashSet;
using System.Collections.Generic;

namespace HashTable
{
    public class HashTable<K, V> : DictHashSet.IDictionary<K, V>
    {
        private const int DEFAULT_CAPACITY = 16;
        private const double DEFAULT_LOAD_FACTOR = 0.75;
        private LinkedList<KeyValuePair<K, V>>[] table;
        private int initialCapacity;
        private int size;
        private double loadFactor;
        private int treshold;

        public HashTable()
            : this(DEFAULT_CAPACITY, DEFAULT_LOAD_FACTOR)
        {
        }

        private HashTable(int capacity, double loadFactor)
        {
            this.initialCapacity = capacity;
            this.loadFactor = loadFactor;
            this.table = new LinkedList<KeyValuePair<K, V>>[capacity];

            unchecked
            {
                this.treshold = (int)(capacity * loadFactor);
            }
        }

        private LinkedList<KeyValuePair<K, V>> FindChain(K key, bool createIfMissing)
        {
            int index = Math.Abs(key.GetHashCode() % this.table.Length);

            if (table[index] == null && createIfMissing)
            {
                table[index] = new LinkedList<KeyValuePair<K, V>>();
            }
            return table[index];
        }

        private void Expand()
        {
            LinkedList<KeyValuePair<K, V>>[] oldTable = this.table;
            int newCapacity = this.table.Length * 2;
            this.table = new LinkedList<KeyValuePair<K, V>>[newCapacity];
            this.treshold = (int)(newCapacity * DEFAULT_LOAD_FACTOR);

            foreach (LinkedList<KeyValuePair<K, V>> oldChain in oldTable)
            {
                if (oldChain != null)
                {
                    foreach (KeyValuePair<K, V> oldPair in oldChain)
                    {
                        LinkedList<KeyValuePair<K, V>> chain =
                            this.FindChain(oldPair.Key, true);
                        chain.AddLast(oldPair);
                    }
                }
            }
        }

        public V Get(K key)
        {
            LinkedList<KeyValuePair<K, V>> chain = this.FindChain(key, false);

            if (chain != null)
            {
                foreach (KeyValuePair<K, V> pair in chain)
                {
                    if (pair.Key.Equals(key))
                        return pair.Value;
                }
            }

            return default(V);
        }

        public V Set(K key, V value)
        {
            LinkedList<KeyValuePair<K, V>> chain = this.FindChain(key, true);

            KeyValuePair<K, V> newElement =
                   new KeyValuePair<K, V>(key, value);

            foreach(KeyValuePair<K, V> pair in chain)
            {
                if (pair.Key.Equals(key))
                {        
                    chain.Remove(pair);
                    chain.AddLast(newElement);
                    return pair.Value;
                }
            }

            chain.AddLast(newElement);
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

                foreach(KeyValuePair<K, V> pair in this) 
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
            LinkedList<KeyValuePair<K, V>> chain = this.FindChain(key, false);

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
            LinkedList<KeyValuePair<K, V>> chain = this.FindChain(key, false);

            if (chain != null) 
            {
                foreach (KeyValuePair<K, V> pair in chain)
                {
                    if (pair.Key.Equals(key))
                    {
                        chain.Remove(pair);
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
                this.table = new LinkedList<KeyValuePair<K, V>>[initialCapacity];
            }
            this.size = 0;
        }

        IEnumerator<KeyValuePair<K, V>>
            IEnumerable<KeyValuePair<K, V>>.GetEnumerator()
        {
            foreach (LinkedList<KeyValuePair<K, V>> chain in this.table)
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

        IEnumerator
            IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<K, V>>)this).
                  GetEnumerator();
        }
    }
}
