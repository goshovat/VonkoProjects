using System;
using System.Collections.Generic;
using BinaryHeap;

namespace PriorityQueue
{
    public class PriorityQueue<T> where T : IComparable<T>
    {
        private BinaryHeapMin<T> innerHeap;

        public PriorityQueue()
        {
            innerHeap = new BinaryHeapMin<T>();
        }

        public int Count
        {
            get { return this.innerHeap.Count; }
        }

        public void Enqueue(T element)
        {
            innerHeap.Add(element);
        }

        public T Dequeue()
        {
            return innerHeap.Pop();
        }

        public T Peek()
        {
            return innerHeap.Peek();
        }

        public bool Contains(T element)
        {
            return innerHeap.Contains(element);
        }

        public void Clear()
        {
            innerHeap = new BinaryHeapMin<T>();
        }

        public override string ToString()
        {
            return innerHeap.ToString();
        }
    }
}
