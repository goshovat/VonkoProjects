using System;
using System.Collections.Generic;

namespace NodesWithLeafChilds
{
    public class BinaryTree<T>
        where T : IComparable<T>
    {
        private BinaryTreeNode<T> root;

        public BinaryTree(T rootValue)
            :this(rootValue, null, null)
        {
           
        }

        public BinaryTree(T rootValue, BinaryTree<T> leftChildTree, 
            BinaryTree<T> rightChildTree)
        {
             if (rootValue == null)
                    throw new ApplicationException("Error! Cannot create a tree with a null sub tree!");

             BinaryTreeNode<T> leftChild =
                 leftChildTree != null ? leftChildTree.root : null;

             BinaryTreeNode<T> rightChild =
                 rightChildTree != null ? rightChildTree.root : null;

             this.root = new BinaryTreeNode<T>(rootValue, leftChild, rightChild);
        }

        public BinaryTreeNode<T> Root
        {
            get { return this.root; }
        }

        public void PrintTree()
        {
            if (this.root == null)
            {
                return;
            }

            Print(this.root, String.Empty);
            Console.WriteLine();
        }

        private void Print(BinaryTreeNode<T> element, string spaces)
        {
            Console.WriteLine(spaces + element.Value);

            if(element.LeftChild != null)
                 Print(element.LeftChild, spaces + "  ");

            if (element.RightChild != null)
                 Print(element.RightChild, spaces + "  ");
        }
    }
}
