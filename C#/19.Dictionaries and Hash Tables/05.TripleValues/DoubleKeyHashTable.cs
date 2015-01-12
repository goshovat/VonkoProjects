using System;
using System.Collections.Generic;

namespace TripleValues
{
    class DoubleKeyHashTable<K, V>
    {
        private Dictionary<K[], V> innerDictionary;

        //define constructor
        public DoubleKeyHashTable()
        {
            this.innerDictionary = new Dictionary<K[], V>();
        }

        //define indexator
        public V this[K key1, K key2] 
        {
            get
            {
                foreach (K[] array in this.innerDictionary.Keys)
                {
                    if (array[0].Equals(key1) && array[1].Equals(key2))
                        return this.innerDictionary[array];
                }

                throw new ApplicationException(string.Format("Error! No value for the pair of keys [{0}, {1}]",
                    key1, key2));
            }
            set
            {
                K[] keyArray = new K[2];
                bool alreadyInside = false;

                foreach (K[] array in this.innerDictionary.Keys)
                {
                    if (array[0].Equals(key1) && array[1].Equals(key2))
                        keyArray = array;
                        alreadyInside = true;
                }
                if (!alreadyInside)
                {
                    keyArray = new K[] { key1, key2 };
                }
                this.innerDictionary[keyArray] = value;
            }
        }

        //define method for adding two keys with a value
        public void Add(K key1, K key2, V value)
        {
            this.innerDictionary.Add(new K[] { key1, key2 }, value);
        }
    }
}
