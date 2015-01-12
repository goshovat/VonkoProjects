using System;
using System.Collections.Generic;

namespace DeckStructure
{
    public class Deck<T>
    {
        //the private classes LeftNode and RightNode that will wrap the values in the stack
        Stack<T> leftStack;
        Stack<T> rightStack;

        //the constructor of the deck class
        public Deck()
        {
            this.leftStack = new Stack<T>();
            this.rightStack = new Stack<T>();
        }

        //the properties of the deck class
        public int Count
        {
            get { return this.leftStack.Count + this.rightStack.Count; }
        }

        public T LeftHead
        {
            get { return this.leftStack.Peek(); }
        }

        public T RightHead
        {
            get { return this.rightStack.Peek(); }
        }

        //methods of the Deck
        public void PushLeft(T element)
        {
            this.leftStack.Push(element);
        }

        public void PushRight(T element)
        {
            this.rightStack.Push(element);
        }

        public T PopLeft()
        {
            if (this.leftStack.Count == 0)
                throw new ApplicationException("Error! No elements on the left side, cannot pop from there.");

            T element = this.leftStack.Pop();

            return element;
        }

        public T PopRight()
        {
            if (this.rightStack.Count == 0)
                throw new ApplicationException("Error! No elements on the right side, cannot pop from there.");

            T element = this.rightStack.Pop();

            return element;
        }

        public bool Contains(T element)
        {
            return this.leftStack.Contains(element) || 
                this.rightStack.Contains(element);
        }

        public void Clear()
        {
            this.leftStack = new Stack<T>();
            this.rightStack = new Stack<T>();
        }
    }
}
