using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuckooHashTable
{
    public class CuckooHashTable<K, V> : DictHashSet.IDictionary<K, V>
    {
        private const int DEFAULT_CAPACITY = 16;
        private const double DEFAULT_LOAD_FACTOR = 0.75;
        private KeyValuePair<K, V>[] table;
        private double loadFactor;
        private int treshold;
        private int size;
        private int initialCapacity;

        public CuckooHashTable()
            : this(DEFAULT_CAPACITY, DEFAULT_LOAD_FACTOR)
        {
        }

        private CuckooHashTable(int capacity, double loadFactor)
        {
            this.initialCapacity = capacity;
            this.loadFactor = loadFactor;
            this.table = new KeyValuePair<K, V>[capacity];
            unchecked
            {
                this.treshold = (int)(this.loadFactor * capacity);
            }
        }

        private void AddAfterExpand(KeyValuePair<K, V> pair)
        {
            int index = Math.Abs(pair.Key.GetHashCode() % this.table.Length);

            if (this.table[index].Equals(default(KeyValuePair<K, V>)))
                this.table[index] = pair;
            else
                this.Set(pair.Key, pair.Value);
        }

        private void Expand()
        {
            int tempSize = this.size;
            int newCapacity = this.table.Length * 2;
            KeyValuePair<K, V>[] oldTable = this.table;
            this.table = new KeyValuePair<K, V>[newCapacity];
            this.treshold = (int)(newCapacity * this.loadFactor);

            foreach (KeyValuePair<K, V> oldPair in oldTable)
            {
                if (!oldPair.Equals(default(KeyValuePair<K, V>)))
                {
                    this.AddAfterExpand(oldPair);
                }
            }

            this.size = tempSize;
        }

        public V Get(K key)
        {
            foreach (KeyValuePair<K, V> entry in this.table)
            {
                if (!entry.Equals(default(KeyValuePair<K, V>)))
                {
                    if (entry.Key.Equals(key))
                        return entry.Value;
                }
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
                foreach (KeyValuePair<K, V> pair in this)
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

        public V Set(K key, V value)
        {
            for (int i = 0; i < this.table.Length; i++)
            {
                if (!this.table[i].Equals(default(KeyValuePair<K, V>)))
                {
                    KeyValuePair<K, V> entry = this.table[i];
                    if (entry.Key.Equals(key))
                    {
                        this.table[i] = new KeyValuePair<K, V>(key, value);
                        return entry.Value;
                    }
                }
            }

            //the first hash function is executed here
            int index = Math.Abs(key.GetHashCode() % this.table.Length);

            if (this.table[index].Equals(default(KeyValuePair<K, V>)))
                this.table[index] = new KeyValuePair<K, V>(key, value);
            else
                this.CuckooHash(new KeyValuePair<K, V>(key, value));

            if (this.size++ >= this.treshold)
                this.Expand();

            return default(V);
        }

        private void CuckooHash(KeyValuePair<K, V> newPair)
        {
            //the second hash function
            int index = Math.Abs((newPair.Key.GetHashCode() * 83 + 7) % this.table.Length);
            if (this.table[index].Equals(default(KeyValuePair<K, V>)))
            {
                this.table[index] = newPair;
                return;
            }
            //the third hash function
            index = Math.Abs(newPair.Key.GetHashCode() *
                newPair.Key.GetHashCode() + 19) % this.table.Length;

            if (this.table[index].Equals(default(KeyValuePair<K, V>)))
            {
                this.table[index] = newPair;
                return;
            }

            //we start to kick out elements from their cells
            List<int> visitedCells = new List<int>();
            Random randomGen = new Random();
            while (!this.table[index].Equals(default(KeyValuePair<K, V>)))
            {
                KeyValuePair<K, V> kickedOutCell = this.table[index];
                this.table[index] = newPair;
                //by this formulla we will find in which cell to kick out the element
                index = randomGen.Next(0, this.table.Length);
          
                if (this.table[index].Equals(default(KeyValuePair<K, V>)))
                {
                    this.table[index] = kickedOutCell;
                    break;
                }
                else
                {
                    newPair = kickedOutCell;
                }
            }
        }

        public bool Remove(K key)
        {

            for (int i = 0; i < this.table.Length; i++)
            {
                if (this.table[i].Key.Equals(key))
                {
                    this.table[i] = default(KeyValuePair<K, V>);
                    this.size--;
                    return true;
                }
            }

            return false;
        }

        public bool ContainsKey(K key)
        {
            foreach (KeyValuePair<K, V> pair in this.table)
            {
                if (pair.Key.Equals(key))
                    return true;
            }

            return false;
        }

        public void Clear()
        {
            if (this.table != null)
            {
                this.table = new KeyValuePair<K, V>[initialCapacity];
            }
            this.size = 0;
        }

        IEnumerator<KeyValuePair<K, V>>
            IEnumerable<KeyValuePair<K, V>>.GetEnumerator()
        {
            foreach (KeyValuePair<K, V> pair in this.table)
            {
                if (!pair.Equals(default(KeyValuePair<K, V>)))
                    yield return pair;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<K, V>>)this).
                  GetEnumerator();
        }
    }
}
