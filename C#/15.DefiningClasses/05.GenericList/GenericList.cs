using System;
using System.Collections.Generic;
using System.Text;

namespace GenericList
{
    public class GenericList<T>
    {
        private T[] list;
        //we will keep the initial length for clearing the list
        private int initialLength;
        private int firstFreeSpot;

        //the constructors of the class
        public GenericList()
            :this(10)
        {
        }

        public GenericList(int initialLength) 
        {
            this.list = new T[initialLength];
            this.initialLength = initialLength;
            this.firstFreeSpot = 0;
        }

        //define properties
        public int Length
        {
            get { return this.firstFreeSpot; }
        }

        public int Capacity
        {
            get { return this.list.Length; }
        }

        public T this[int index]
        {
            get { return this.list[index]; }
        }

        //method to add elements
        public void AddElement(T element)
        {
            if (firstFreeSpot == this.list.Length)
            {
                //resize the list
                GenericList<T>.ResizeArray(ref this.list);
            }
            
            list[firstFreeSpot] = element;
            this.firstFreeSpot++;
        }

        //method to remove element at index
        public T RemoveAt(int index)
        {
            if (index < 0 || index == firstFreeSpot)
                throw new ApplicationException(string.Format("Error! The index {0} you are trying to remove at is out of the boundaries of the list with length {1}!", 
                    index, this.firstFreeSpot));

            T removedElement = this.list[index];
            
            Array.Copy(this.list, index + 1, this.list, index, this.firstFreeSpot - index - 1);
            this.list[firstFreeSpot - 1] = default(T);
            this.firstFreeSpot--;

            return removedElement;
        }

        //method to insert element on index
        public void InsertAt( int index, T element) 
        {
            if (index < 0 || index > this.firstFreeSpot)
                throw new ApplicationException(string.Format("Error! You are trying to insert at index {0} and the last element is at index {1}", 
                    index, firstFreeSpot -1));

            //if the list is full to its capacity we have to resize it
            if (this.firstFreeSpot == this.list.Length)
            {
                //resize the list
                GenericList<T>.ResizeArray(ref this.list);
            }

            this.firstFreeSpot++;
            Array.Copy(this.list, index, this.list, index + 1, this.firstFreeSpot - index - 1);

            //put the new element at its position
            this.list[index] = element;
            
        }

        //method to clear the list 
        public void ClearList()
        {
            this.list = new T[this.initialLength];
            this.firstFreeSpot = 0;
        }

        //return an element by its value
        public int FindElement(T element) 
        {
            if (Array.IndexOf(this.list, element) == -1)
                throw new ApplicationException(string.Format("Error! The element {0} you are trying to find is not in the list.",
                    element));

            return Array.IndexOf(this.list, element);
        }

        //predefine the toString method
        public override string ToString() 
        {
            StringBuilder strBuild = new StringBuilder();
            for (int i = 0; i < this.firstFreeSpot - 1; i++)
            {
                strBuild.Append(this.list[i].ToString());
                strBuild.Append(',');
            }
            strBuild.Append(this.list[firstFreeSpot - 1]);

            return strBuild.ToString();
        }

        //a static method for resizing array that can be called outside the class
        public static void ResizeArray(ref T[] oldArray)
        {
            T[] newArray = new T[oldArray.Length * 2];

            for (int i = 0; i < oldArray.Length; i++)
            {
                newArray[i] = oldArray[i];
            }

            oldArray = newArray;
        }
    }
}
