namespace BinarySearchTree
{
    using System;

    public class TreeNode<T>
    {
        public TreeNode(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }
        public TreeNode<T> Parent { get; set; }
        public TreeNode<T> LeftChild { get; set; }
        public TreeNode<T> RightChild { get; set; }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
