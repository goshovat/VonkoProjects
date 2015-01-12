using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicStack
{
    public class DynamicStack<T>
    {
        //the private class Node that will wrap the values in the stack
        private class Node
        {
            private T value;
            private Node previous;

            public Node()
                : this(default(T))
            {
            }

            public Node(T value)
                : this(value, null)
            {
            }

            public Node(T value, Node previous)
            {
                this.value = value;
                this.previous = previous;
            }

            public T Value
            {
                get { return this.value; }
                set { this.value = value; }
            }

            public Node Previous
            {
                get { return this.previous; }
                set { this.previous = value; }
            }
        }

        //the fields of DynamicStack
        private Node head;
        private int count;

        //the constructors of dynamic stack
        public DynamicStack()
        {
            this.head = null;
            this.count = 0;
        }

        public DynamicStack(IEnumerable<T> collection)
        {
            Node previousNode =null;

            foreach (T item in collection)
            {
                if (this.count == 0)
                {
                    this.head = new Node(item, null);
                }
                else
                {
                    this.head = new Node(item, previousNode);
                }
                this.count++;
                previousNode = this.head;
            }
        }

        //properties of the DynamicStack
        public int Count
        {
            get { return this.count; }
        }

        public T Head
        {
            get { return this.head.Value; }
        }

        //methods of the DynamicStack
        public void Push(T element)
        {
            this.head = new Node(element, this.head);
            count++;
        }

        public T Pop()
        {
            if (this.count == 0)
                throw new ApplicationException("Error! You cannot pop a value from empty stack.");

            Node elementToPop = this.head;
            this.count--;

            if (this.count == 0)
                this.head = null;
            else
                this.head = this.head.Previous;

            return elementToPop.Value;
        }

        public T Peek()
        {
            if (this.count == 0)
                throw new ApplicationException("Error! You cannot pop a value from empty stack.");

            Node elementToPop = this.head;

            return elementToPop.Value;
        }

        public bool Contains(T element)
        {
            Node currentElement = this.head;
            while (currentElement != null)
            {
                if (currentElement.Value.Equals(element))
                    return true;

                currentElement = currentElement.Previous;
            }

            return false;
        }

        public T[] ToArray()
        {
            T[] array = new T[this.count];

            Node currentElement = this.head;

            for (int i = this.count - 1; i >= 0; i--)
            {
                array[i] = currentElement.Value;
                currentElement = currentElement.Previous;
            }

            return array;
        }

        public void Clear() 
        {
            this.head = null;
            this.count = 0;
        }
    }
}
