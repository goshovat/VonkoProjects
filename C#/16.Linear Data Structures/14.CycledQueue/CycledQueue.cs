using System;
using System.Collections.Generic;

namespace CycledQueue
{
    class CycledQueue<T>
    {
        //the fields of the class
        static readonly int DEFAULT_CAPACITY = 4;

        private T[] array;
        private int count;
        private int headIndex;
        private int tailIndex;
        private int firstFreeSpot;

        //constructor of the class
        public CycledQueue()
        {
            this.array = new T[CycledQueue<T>.DEFAULT_CAPACITY];
            this.count = 0;
            this.headIndex = 0;
            this.tailIndex = 0;
            this.firstFreeSpot = 0;
        }

        //properties of the calss
        public int Count
        {
            get { return this.count; }
        }

        public int Capacity
        {
            get { return this.array.Length; }
        }

        //methods of the queue
        public void Enqueue(T element)
        {
            if (this.count >= this.array.Length - 1)
                ResizeArray(this.array, this.headIndex, this.tailIndex);

            this.array[firstFreeSpot] = element;
            this.tailIndex = firstFreeSpot;

            if (this.firstFreeSpot == this.array.Length - 1)
            {       
                firstFreeSpot = 0;
            }
            else
            {
                firstFreeSpot = this.tailIndex + 1;
            }
            this.count++;
        }

        public T Dequeue() 
        {
            if (this.count == 0)
                throw new ApplicationException("Error! Cannot remove elements, the queue is empty.");

            T element = this.array[this.headIndex];
            this.array[this.headIndex] = default(T);

            if (this.headIndex == this.array.Length - 1)
            {
                this.headIndex = 0;
            }
            else
            {
                this.headIndex = this.headIndex + 1;
            }
            this.count--;

            return element;
        }

        public T Peek()
        {
            if (this.count == 0)
                throw new ApplicationException("Error! Cannot remove elements, the queue is empty.");

            T element = this.array[this.headIndex];

            return element;
        }

        private void ResizeArray(T[] t, int p1, int p2)
        {
            T[] newArray = new T[2* this.array.Length];

            if (this.tailIndex > this.headIndex)
            {
                int differenceHeadTail = this.tailIndex - this.headIndex;

                Array.Copy(this.array, this.headIndex, newArray, 0, differenceHeadTail + 1);
                
                this.headIndex = 0;
                this.tailIndex = this.headIndex + differenceHeadTail;
            }
            else
            {
                //copy the first part, from index 0 to tailIndex
                Array.Copy(this.array, 0, newArray, 0, this.tailIndex + 1);

                //copy the second part, from headIndex to the end 
                int differenceHeadToEnd = this.array.Length - this.headIndex;
                int newHeadIndex = newArray.Length - differenceHeadToEnd;
                Array.Copy(this.array, this.headIndex, newArray, newHeadIndex, differenceHeadToEnd);

                this.headIndex = newHeadIndex;
            }
            this.array = newArray;
            this.firstFreeSpot = this.tailIndex + 1;
        }
    }
}
