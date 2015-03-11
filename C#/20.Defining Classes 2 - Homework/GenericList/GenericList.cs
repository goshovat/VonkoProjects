namespace GenericList
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class GenericList<T> : IEnumerable<T>
        where T: IComparable<T>
    {
        public const int DEFAULT_START_SIZE = 4;
        private int count;
        private T[] innerArray;

        public GenericList(int startSize)
        {
            if (startSize <= 0)
                throw new ArgumentException("The initial size of the list must be positive");

            this.innerArray = new T[startSize];
            this.count = 0;
        }

        public GenericList() : this(DEFAULT_START_SIZE) { }

        public int Count { get { return this.count; } }

        public T this[int index]
        {
            get 
            {
                if (index < 0 || index >= this.count)
                    throw new ArgumentException("Index is outside the bounders of the list.");

                return this.innerArray[index]; 
            }
            set 
            {
                if (index < 0 || index >= this.count)
                    throw new ArgumentException("Index is outside the bounders of the list.");

                this.innerArray[index] = value;
            }
        }

        public void Add(T element)
        {
            if (this.innerArray.Length - this.count <= 2)
                this.Expand();

            this.innerArray[count] = element;
            this.count++;
        }

        public void InsertAt(int index, T element)
        {
            if (index < 0 || index > this.count)
                throw new ArgumentException("The index you try to insert at is outside the bounders of the list.");
            if (this.innerArray.Length - this.count <= 2)
                this.Expand();

            if (index == this.count)
            {
                this.innerArray[index] = element;
            }
            else
            {
                for (int i = this.count; i > index; i--)
                {
                    this.innerArray[i] = this.innerArray[i - 1];
                }
                this.innerArray[index] = element;
            }
            this.count++;
        }

        public int IndexOf(T value)
        {
            int index = -1;

            for (int i = 0; i < this.count; i++)
            {
                if (this.innerArray[i].Equals(value))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        public bool Remove(T element)
        {
            int indexRemoved = -1;
            indexRemoved = this.IndexOf(element);
            this.innerArray[indexRemoved] = default(T);

            //we rearange so there are no holes in the inner array.
            RearangeAfterRemoving(indexRemoved);

            this.count--;

            if (indexRemoved != -1)
                return true;
            else
                return false;
        }

        public T RemoveAt(int index)
        {
            if (index < 0 || index >= this.count)
                throw new ArgumentException(
                    "Cannot execute RemoveAt. Index is outside the bounders of the list.");

            T elementRemoved = this.innerArray[index];
            this.innerArray[index] = default(T);

            RearangeAfterRemoving(index);

            this.count--;
            return elementRemoved;
        }

        public void Clear()
        {
            this.innerArray = new T[DEFAULT_START_SIZE];
            this.count = 0;
        }

        public T Min()
        {
            if (this.count == 0)
                throw new ApplicationException("Cannot find min element in an empty list/");

            T minElement = this[0];
            foreach (T element in this)
            {
                if (element.CompareTo(minElement) < 0)
                    minElement = element;
            }
            return minElement;
        }

        public T Max()
        {
            if (this.count == 0)
                throw new ApplicationException("Cannot find max element in an empty list/");

            T maxElement = this[0];
            foreach (T element in this)
            {
                if (element.CompareTo(maxElement) > 0)
                    maxElement = element;
            }
            return maxElement;
        }

        private void Expand()
        {
            int newLen = this.innerArray.Length * 2;
            T[] newArray = new T[newLen];

            for (int i = 0; i < this.count; i++)
            {
                newArray[i] = this.innerArray[i];
            }

            this.innerArray = newArray;
        }

        private void RearangeAfterRemoving(int indexRemoved)
        {
            if (indexRemoved != -1 && indexRemoved != this.count - 1)
            {
                for (int i = indexRemoved; i < this.count - 1; i++)
                {
                    this.innerArray[i] = this.innerArray[i + 1];
                }
                this.innerArray[this.count - 1] = default(T);
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            foreach (T element in this)
                builder.Append(element + " ");

            return builder.ToString();
        }

        public IEnumerator<T> GetEnumerator() 
        {
            for (int i = 0; i < this.count; i++)
            {
                 yield return innerArray[i];
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
