using System;
using System.Collections;
using System.Collections.Generic;
using HashTable;

namespace HashedSet
{
    public class HashedSet<T> : ICollection<T>
    {
        private HashTable<T, bool> innerDictionary;

        public HashedSet(ICollection<T> collection)
            :this() 
        {
            foreach (T item in collection)
            {
                this.innerDictionary[item] = true;
            }
        }

        public HashedSet()
        {
            this.innerDictionary = new HashTable<T, bool>();
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

        public void IntersectWith(HashedSet<T> other)
        {
            List<T> elementsToRemove = new List<T>();

            foreach (T element in this.innerDictionary.Keys) 
            {
                if (!other.Contains(element))
                    elementsToRemove.Add(element);
            }

            foreach (T element in elementsToRemove)
            {
                this.Remove(element);
            }    
        }

        public void UnionWith(HashedSet<T> other)
        {
            foreach (T element in other)
            {
                this.Add(element);
            }
        }

        #region ICollection<T> Members

        void ICollection<T>.Add(T element) 
        {
            this.Add(element);
        }

        public void Clear()
        {
            this.innerDictionary = new HashTable<T, bool>();
        }

        public bool Contains(T item)
        {
            return this.innerDictionary.ContainsKey(item);
        }

        public void CopyTo(T[] array, int index)
        {
            this.innerDictionary.Keys.CopyTo(array, index);
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

        #endregion

        #region IEnumerable<T> Members

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
