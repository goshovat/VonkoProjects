using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncountersInTree
{
    public class TreeNode<T>:IComparable<TreeNode<T>>
        where T: IComparable<T>
    {
        private T value;
        private TreeNode<T> parent;
        private List<TreeNode<T>> children;

        public TreeNode(T value)
            : this(value, null)
        {
        }

        public TreeNode(T value, TreeNode<T> parent)
        {
            if (value == null)
                throw new ApplicationException("Error! Cannot create a Node with null value");

            this.value = value;
            this.parent = parent;
            this.children = new List<TreeNode<T>>();
        }

        public T Value 
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public TreeNode<T> Parent
        {
            get { return this.parent; }
        }

        public List<TreeNode<T>> Children
        {
            get { return this.children; }
        } 

        public int ChildrenCount
        {
            get { return this.children.Count; }
        }

        public void AddChild(TreeNode<T> childToAdd)
        {
            if (childToAdd == null)
                throw new ApplicationException("Error! Cannot add a child with null value");

            if (childToAdd.Parent != null)
                throw new ApplicationException(string.Format("Error! The child you are trying to add {0} already has a parent!",
                    childToAdd.value));

            childToAdd.parent = this;
            children.Add(childToAdd);
        }

        public void RemoveChild(TreeNode<T> childToRemove)
        {
            for (int i = 0; i < children.Count; i++)
            {
                if (children[i].Equals(childToRemove))
                {
                    children.RemoveAt(i);
                    break;
                }
            }
        }

        public int CompareTo(TreeNode<T> otherNode)
        {
            if (otherNode == null)
                throw new ApplicationException("Error! Cannot compare with null node!");

            return this.value.CompareTo(otherNode.Value);
        }

        public bool Equals(TreeNode<T> otherNode)
        {
            return this.CompareTo(otherNode) == 0;
        }
    }
}
