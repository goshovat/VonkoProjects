using System;
using System.Collections.Generic;

namespace BiDictionary
{
    class BiDictionary<K1, K2, V> where V:IComparable<V>
    {
        private Dictionary<K1, List<V>> innerTable1;
        private Dictionary<K2, List<V>> innerTable2;

        public BiDictionary()
        {
            this.innerTable1 = new Dictionary<K1, List<V>>();
            this.innerTable2 = new Dictionary<K2, List<V>>();
        }

        public int Count
        {
            get
            {
                int count = 0;

                foreach (List<V> list in this.innerTable1.Values) 
                {
                    count += list.Count;
                }

                return count;
            }
        }

        //the indexing - elements can be accessed by one or two indexes, but set only with two
        public V this[K1 key] 
        {
            get 
            {
                if (!this.innerTable1.ContainsKey(key))
                    throw new ApplicationException(string.Format(
                        "Error! The key {0} is not presented in the BiDictionary.", key));

                return this.innerTable1[key][0] ;
            }
        }

        public V this[K2 key] 
        {
            get 
            {
                if (!this.innerTable2.ContainsKey(key))
                    throw new ApplicationException(string.Format(
                        "Error! The key {0} is not presented in the BiDictionary.", key));

                return this.innerTable2[key][0] ;
            }
        }

        public V this[K1 key1, K2 key2]
        {
            get 
            {
                //it is enough to check for only one of the keys
                if (!this.innerTable1.ContainsKey(key1))
                    throw new ApplicationException(string.Format(
                        "Error! The key {0} is not presented in the BiDictionary.", key1));

                return this.innerTable1[key1][0];
            }
            set 
            {
                //it is enough to check for only one of the keys
                if (!this.innerTable1.ContainsKey(key1))
                {
                    this.innerTable1[key1] = new List<V>();
                    this.innerTable2[key2] = new List<V>();
                }
                else
                {
                    if (this.innerTable1[key1][0].CompareTo(value) != 0)
                        throw new ApplicationException(string.Format(
                        "Error! For one key can be storer only same elements.", key1));
                }

                this.innerTable1[key1].Add(value);
                this.innerTable2[key2].Add(value);
            }
        }

        //the public methods
        public void Add(K1 key1, K2 key2, V value)
        {
            this[key1, key2] = value;
        }

        public V Remove(K1 key1, K2 key2)
        {
            //it is enough to check for only one of the keys
            if (!this.innerTable1.ContainsKey(key1))
                throw new ApplicationException(string.Format(
                    "Error! The key {0} is not presented in the BiDictionary.", key1));

            List<V> list1 = this.innerTable1[key1];
            List<V> list2 = this.innerTable2[key2];

            V elToRemove = this.innerTable1[key1][0];

            list1.RemoveAt(list1.Count - 1);
            if (list1.Count == 0)
                innerTable1.Remove(key1);

            list2.RemoveAt(list2.Count - 1);
            if (list2.Count == 0)
                innerTable2.Remove(key2);

            return elToRemove;
        }

        public void Clear() 
        {
            this.innerTable1 = new Dictionary<K1, List<V>>();
            this.innerTable2 = new Dictionary<K2, List<V>>();
        }
    }
}
