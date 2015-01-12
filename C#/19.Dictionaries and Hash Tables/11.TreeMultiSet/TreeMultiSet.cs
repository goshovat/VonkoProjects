using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TreeMultiSet
{
    public class TreeMultiSet<T> : ICollection<T>
    {
        private SortedDictionary<T, int> innerDictionary;

        public TreeMultiSet(IComparer<T> comparer)
        {
            this.innerDictionary = new SortedDictionary<T, int>(comparer);
        }

        public TreeMultiSet(ICollection<T> collection)
            : this()
        {
            foreach (T item in collection)
            {
                if (!this.innerDictionary.ContainsKey(item))
                    this.innerDictionary[item] = 1;
                else
                    this.innerDictionary[item]++;
            }
        }

        public TreeMultiSet(ICollection<T> collection,
            IComparer<T> comparer)
            : this(comparer)
        {
            foreach (T item in collection)
            {
                if (!this.innerDictionary.ContainsKey(item))
                    this.innerDictionary[item] = 1;
                else
                    this.innerDictionary[item]++;
            }
        }

        public TreeMultiSet()
        {
            this.innerDictionary = new SortedDictionary<T, int>();
        }

        public void Add(T item)
        {
            if (!this.innerDictionary.ContainsKey(item))
                this.innerDictionary[item] = 1;
            else
                this.innerDictionary[item]++;
        }

        public void IntersectWith(TreeMultiSet<T> other)
        {
            SortedDictionary<T, int> newDict = new SortedDictionary<T, int>();

            foreach (T element in this.innerDictionary.Keys)
            {
                if (other.Contains(element))
                {
                    for (int i = 0; i < Math.Min(this.Encounters(element),
                        other.Encounters(element)); i++)
                    {
                        if (newDict.ContainsKey(element))
                            newDict[element]++;
                        else
                            newDict[element] = 1;
                    }
                }
            }

            this.innerDictionary = newDict;
        }

        public void UnionWith(TreeMultiSet<T> other)
        {
            foreach (T element in other)
            {
                this.Add(element);
            }
        }

        public int Encounters(T element)
        {
            if (this.innerDictionary.ContainsKey(element))
                return this.innerDictionary[element];
            else
                return 0;
        }

        public T GetSmallest()
        {
            if (this.Count == 0)
                return default(T);

            T firstKey = innerDictionary.Keys.First();
            return firstKey;
        }

        public T GetBiggest()
        {
            if (this.Count == 0)
                return default(T);

            T lastKey = innerDictionary.Keys.Last();
            return lastKey;
        }

        public bool RemoveSmallest()
        {
            if (this.Count == 0)
                return false;

            T firstKey = innerDictionary.Keys.First();
            this.innerDictionary[firstKey]--;

            //if (this.innerDictionary[firstKey] == 0)
            //    this.innerDictionary.Remove(firstKey);

            return false;
        }

        public bool RemoveBiggest()
        {
            if (this.Count == 0)
                return false;

            T lastKey = innerDictionary.Keys.Last();
            this.innerDictionary[lastKey]--;

            if (this.innerDictionary[lastKey] == 0)
                this.innerDictionary.Remove(lastKey);

            return true;
        }

        #region ICollection<T> Members

        void ICollection<T>.Add(T element)
        {
            this.Add(element);
        }

        public void Clear()
        {
            this.innerDictionary = new SortedDictionary<T, int>();
        }

        public bool Contains(T element)
        {
            return this.innerDictionary.ContainsKey(element);
        }

        public void CopyTo(T[] array, int index)
        {
            if (array.Length - index < this.Count)
                throw new ApplicationException(string.Format(
                    "The array cannot embed your set starting from index {0}", index));

            foreach (T element in this)
            {
                array[index] = element;
                index++;
            }
        }

        public int Count
        {
            get
            {
                int count = 0;
                foreach (T element in this.innerDictionary.Keys)
                    count += innerDictionary[(T)element];

                return count;
            }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(T item)
        {
            if (!this.innerDictionary.ContainsKey(item))
                return false;

            this.innerDictionary[item]--;
            if (this.innerDictionary[item] == 0)
                this.innerDictionary.Remove(item);

            return true;
        }

        #endregion

        #region IEnumerable<T> Members

        public IEnumerator<T> GetEnumerator()
        {
            List<T> allKeys = new List<T>();

            foreach (T key in this.innerDictionary.Keys)
            {
                for (int i = 0; i < innerDictionary[key]; i++)
                    allKeys.Add(key);
            }

            return allKeys.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            List<T> allKeys = new List<T>();

            foreach (T key in this.innerDictionary.Keys)
            {
                for (int i = 0; i < innerDictionary[key]; i++)
                    allKeys.Add(key);
            }

            return allKeys.GetEnumerator();
        }

        #endregion
    }
}
