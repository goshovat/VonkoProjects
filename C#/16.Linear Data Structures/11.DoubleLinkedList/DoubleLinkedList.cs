using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleLinkedList
{
    public class DoubleLinkedList<T>
    {
        //the private class node that will wrap the values in the list
        private class Node 
        {
            private T value;
            private Node previous;
            private Node next;

            //the constructors of the Node class
            public Node()
                :this(default(T))
            {
            }

            public Node(T value)
                :this(value, null, null)
            {
            }

            public Node(T value, Node previous, Node next) 
            {
                this.value = value;
                this.previous = previous;
                this.next = next;
            }

            //the properties of the node class
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

            public Node Next
            {
                get { return this.next; }
                set { this.next = value; }
            }
        }

        //fields of the double linked list
        private Node first;
        private Node last;
        private int count;

        //constructor of the list
        public DoubleLinkedList()
        {
            this.first = null;
            this.last = null;
            this.count = 0;
        }

        public DoubleLinkedList(IEnumerable<T> collection)
        {
            Node previousNode =null;

            foreach (T item in collection)
            {
                if (this.count == 0)
                {
                    this.first = new Node(item, null, null);
                    this.last = this.first;
                }
                else
                {
                    this.last = new Node(item, previousNode, null);
                    previousNode.Next = this.last;
                }
                this.count++;
                previousNode = this.last;
            }
        }

        //properties of DobleLinkedList
        public T First
        {
            get { return this.first.Value; }
        }

        public T Last
        {
            get { return this.last.Value; }
        }

        public int Count
        {
            get { return this.count; }
        }

        //methods of DoubleLinkedList
        public void Add(T element)
        {
            if (this.count == 0)
            {
                this.first = new Node(element, null, null);
                this.last = this.first;
            }
            else
            {
                this.last = new Node(element, this.last, null);
                this.last.Previous.Next = this.last;
            }
            this.count++;
        }

        public void InsertAt(T element, int index)
        {
            if (index < 0 || index > count)
                throw new ArgumentOutOfRangeException(string.Format("Cannot insert element at index {0} in list of length {1}", 
                    index, this.count));
            //if we have to add element to the end, we call the method for adding
            if (index == this.count)
            {
                this.Add(element);
            }
            else
            {
                Node currentElement = this.first;
                int currentIndex = 0;

                while (currentIndex != index)
                {
                    currentElement = currentElement.Next;
                    currentIndex++;
                }

                Node newElement = new Node(element, currentElement.Previous, currentElement);

                if (currentElement.Previous != null)
                {
                    currentElement.Previous.Next = newElement;
                }
                //if we will insert an element in the first position
                else
                {
                    this.first = newElement;
                }

                currentElement.Previous = newElement;
                this.count++;
            }         
        }

        public T RemoveAt(int index)
        {
            if (index < 0 || index >= this.count)
                throw new ArgumentOutOfRangeException(string.Format("Cannot remove element at index {0} in list of length {1}",
                   index, this.count));

            Node currentElement = this.first;
            int currentIndex = 0;

            for (int i = 0; i < index; i++)
            {
                currentElement = currentElement.Next;
                currentIndex++;
            }

            this.count--;
            if (this.count == 0)
            {
                this.first = null;
                this.last = this.first;
            }
            else if (currentElement.Previous == null)
            {
                this.first = currentElement.Next;
                currentElement.Next.Previous = null;
            }
            else if (currentElement.Next == null)
            {
                this.last = currentElement.Previous;
                currentElement.Previous.Next = null;
            }
            else
            {
                currentElement.Previous.Next = currentElement.Next;
                currentElement.Next.Previous = currentElement.Previous;
            }

            if (index == this.count && count != 0)
            {
                this.last = currentElement.Previous;
            }

            return currentElement.Value;
        }

        public int Remove(T element)
        {
            int index = this.IndexOf(element);

            if (index != -1)
            {
                this.RemoveAt(index);
                return index;
            }
            else
            {
                return -1;
            }
        }

        public int IndexOf(T element)
        {
            int currentIndex = 0;

            Node currentNode = this.first;
            while (currentNode != null)
            {
                if (currentNode.Value.Equals(element))
                    return currentIndex;

                currentNode = currentNode.Next;
                currentIndex++;
            }

            return -1;
        }

        public bool Contains(T element)
        {
            return this.IndexOf(element) != -1;
        }

        public void Clear()
        {
            this.first = null;
            this.last = null;
            this.count = 0;
        }

        public T[] ToArray()
        {
            T[] array = new T[this.count];

            Node currentElement = this.first;

            for (int i = 0; i < this.count; i++)
            {
                array[i] = currentElement.Value;
                currentElement = currentElement.Next;
            }

            return array;
        }

        public override string ToString()
        {
            StringBuilder strBuild = new StringBuilder();

            Node currentElement = this.first;
            while (currentElement != null)
            {
                strBuild.Append(currentElement.Value.ToString());
                strBuild.Append(" ");
                currentElement = currentElement.Next;
            }

            return strBuild.ToString();
        }
    }
}
