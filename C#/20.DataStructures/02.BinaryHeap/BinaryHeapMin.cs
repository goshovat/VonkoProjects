using System;
using System.Collections.Generic;
using System.Text;

//the task requires that min-heap is implemented
namespace BinaryHeap
{
    public class BinaryHeapMin<T> where T: IComparable<T>
    {
        private const int START_INDEX = 1;

        private T[] innerArray;
        private int count;

        public BinaryHeapMin()
        {
            this.innerArray = new T[5];
        }

        public int Count
        {
            get { return this.count; }
        }

        public void Add(T element)
        {
            if (this.count == 0)
            {
                innerArray[1] = element;
                this.count++;
                return;
            }

            int elIndex = this.count + 1;
            innerArray[elIndex] = element;
            int parentIndex = GetParentIndex(elIndex);
            T parent = innerArray[parentIndex];

            //if necessary move the element to its right position
            while (parent.CompareTo(element) > 0)
            {
                T temp = parent;
                innerArray[parentIndex] = element;
                innerArray[elIndex] = temp;

                elIndex = parentIndex;
                parentIndex = GetParentIndex(elIndex);

                if (parentIndex == 0)
                    break;

                parent = innerArray[parentIndex];
            }

            this.count++;
            if (this.count >= innerArray.Length - 1)
                Expand();
        }

        //this method removes and returns the top element
        public T Pop()
        {
            if (this.count == 0)
                throw new ApplicationException("Error! Cannot pop element, the heap is empty");

            int elIndex = 1;
            T elementToPop = innerArray[elIndex];

            T element = innerArray[this.count];
            innerArray[elIndex] = element;
            innerArray[this.count] = default(T);
            this.count--;

            int leftChildInd = 2;
            int rightChildInd = 3;
            int smallerElInd = 0;
            T smallerEl = default(T);

            //if necessary move the element to its right position
            while (leftChildInd <= this.count && element.CompareTo(innerArray[leftChildInd]) > 0 ||
                 rightChildInd <= this.count && element.CompareTo(innerArray[rightChildInd]) > 0)
            {
                 smallerEl = innerArray[leftChildInd];
                 smallerElInd = leftChildInd;

                if (rightChildInd <= this.count &&
                    innerArray[rightChildInd].CompareTo(innerArray[leftChildInd]) < 0)
                {
                    smallerEl = innerArray[rightChildInd];
                    smallerElInd = rightChildInd;
                }

                T temp = element;
                innerArray[elIndex] = smallerEl;
                innerArray[smallerElInd] = temp;

                elIndex = smallerElInd;
                leftChildInd = GetLeftChildeIndex(elIndex);
                rightChildInd = GetRightCHildIndex(elIndex);
            }
         
            return elementToPop;
        }

        public T Peek()
        {
            if (this.count == 0)
                throw new ApplicationException("Error! Cannot peek element, the heap is empty");

            return this.innerArray[1];
        }

        public void Print()
        {
            if (this.count > 0)
            {
                int indentCounter = 0;
                int indentUpdate = 2;
                string indent = "  ";
                Console.WriteLine(innerArray[1]);

                for (int i = 2; i <= this.count; i++)
                {
                    indentCounter++;
                    Console.WriteLine(indent + innerArray[i]);

                    if (indentCounter == indentUpdate)
                    {
                        indent += "  ";
                        indentUpdate *= 2;
                        indentCounter = 0;
                    }
                }
            }

            Console.WriteLine(new string('-', 20));
        }

        public bool Contains(T element)
        {
            foreach (T eleToChek in innerArray)
            {
                if (element.Equals(eleToChek))
                    return true;
            }

            return false;
        }

        public void Clear()
        {
            this.innerArray = new T[5];
            this.count = 0;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("{");
            foreach (T element in innerArray)
            {
                builder.Append(element);
                builder.Append(" ");
            }
            builder.Append("}");

            return builder.ToString();
        }

        //private methods for internal use
        private int GetLeftChildeIndex(int index)
        {
            return index * 2;
        }

        private int GetRightCHildIndex(int index)
        {
            return index * 2 + 1;
        }

        private int GetParentIndex(int index)
        {
            return index / 2;
        }

        private void Expand()
        {
            int newLen = innerArray.Length * 2;
            T[] oldArray = innerArray;
            innerArray = new T[newLen];

            for (int i = 0; i < oldArray.Length; i++)
            {
                innerArray[i] = oldArray[i];
            }
        }
    }
}
