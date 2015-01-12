using System;
using System.Collections;
using System.Collections.Generic;

namespace DictHashSet
{
    public class DictHashSet<T>:ICollection<T>
    {
        private HashDictionary<T, bool> innerDictionary;

        public DictHashSet(IEnumerable<T> collection)
            : this()
        {
            foreach (T item in collection)
            {
                this.Add(item);
            }
        }

        public DictHashSet()
        {
            this.innerDictionary = new HashDictionary<T, bool>();
        }

        public bool Add(T element)
        {
            if (!this.innerDictionary.ContainsKey(element))
            {
                this.innerDictionary[element] = true;
                return true;
            }
            return false;
        }

        public void IntersectWith(DictHashSet<T> other)
        {
            List<T> elementsToRemove = new List<T>();

            foreach (T key in this.innerDictionary.Keys)
            {
                if (!other.Contains(key))
                    elementsToRemove.Add(key);
            }

            foreach (T key in elementsToRemove)
            {
                this.Remove(key);
            }
        }

        public void UnionWith(DictHashSet<T> other)
        {
            foreach (T key in other)
            {
                this.Add(key);
            }
        }

        #region ICollection<T> Members

        void ICollection<T>.Add(T item)
        {
            this.Add(item);
        }

        public void Clear()
        {
            this.innerDictionary.Clear();
        }

        public bool Contains(T item)
        {
            return this.innerDictionary.ContainsKey(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            this.innerDictionary.Keys.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return this.innerDictionary.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(T item)
        {
            return this.innerDictionary.Remove(item);
        }

        # endregion

        #region IEnumberable<T> Members

        public IEnumerator<T> GetEnumerator()
        {
            return this.innerDictionary.Keys.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.innerDictionary.Keys.GetEnumerator();
        }

        #endregion
    }
}
