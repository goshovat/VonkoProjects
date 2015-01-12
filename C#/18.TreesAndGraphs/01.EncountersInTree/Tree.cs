using System;
using System.Collections.Generic;

namespace EncountersInTree
{
    public class Tree<T>
        where T:IComparable<T>
    {
        private TreeNode<T> root;

        public Tree(T rootValue)
        {
            if (rootValue == null)
                throw new ApplicationException("Cannot create a true with a value for the root null!");

            this.root = new TreeNode<T>(rootValue);
        }

        public Tree(T rootValue, params Tree<T>[] childTrees)
            :this(rootValue)
        {
            foreach (Tree<T> childTree in childTrees)
            {
                if (childTree == null)
                    throw new ApplicationException("Error! Cannot create a tree with a null sub tree!");

                this.root.AddChild(childTree.root);
            }
        }

        public TreeNode<T> Root 
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

        private void Print(TreeNode<T> element, string spaces)
        {
            Console.WriteLine(spaces+ element.Value);

            foreach (TreeNode<T> child in element.Children)
            {
                Print(child, spaces + "  ");
            }
        }
    }
}
