using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodesWithLeafChilds
{
    public class BinaryTreeNode<T> : IComparable<BinaryTreeNode<T>>
        where T: IComparable<T>
    {
        private T value;
        private BinaryTreeNode<T> parent;
        private BinaryTreeNode<T> leftChild;
        private BinaryTreeNode<T> rightChild;

        public BinaryTreeNode(T value)
            : this(value, null, null)
        {
        }

        public BinaryTreeNode(T value, BinaryTreeNode<T> leftChild, BinaryTreeNode<T> rightChild)
        {
            if (value == null)
                throw new ApplicationException("Error! Cannot create a Node with null value");

            this.value = value;
            this.leftChild = leftChild;
            this.rightChild = rightChild;
        }

        public T Value 
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public BinaryTreeNode<T> Parent
        {
            get { return this.parent; }
            set { this.parent = value; }
        }

        public BinaryTreeNode<T> LeftChild
        {
            get 
            { 
                return this.leftChild; 
            }
            set
            {
                if (value == null)
                    return;

                if (value.Parent != null)
                    throw new ApplicationException(string.Format("The node {0} already has a parent", value.Value));

                this.leftChild = value;
                value.Parent = this;
            }
        }

        public BinaryTreeNode<T> RightChild
        {
            get
            {
                return this.rightChild;
            }
            set
            {
                if (value == null)
                    return;

                if (value.Parent != null)
                    throw new ApplicationException(string.Format("The node {0} already has a parent", value.Value));

                this.rightChild = value;
                value.Parent = this;
            }
        } 

        public int CompareTo(BinaryTreeNode<T> otherNode)
        {
            if (otherNode == null)
                throw new ApplicationException("Error! Cannot compare with null node!");

            return this.value.CompareTo(otherNode.Value);
        }

        public bool Equals(BinaryTreeNode<T> otherNode)
        {
            return this.CompareTo(otherNode) == 0;
        }
    }
}
