namespace BinarySearchTree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BinarySearchTree<T> : IEnumerable<T>, ICloneable
        where T : IComparable<T>
    {
        public BinarySearchTree(T value)
        {
            this.Root = new TreeNode<T>(value);
        }

        public TreeNode<T> Root { get; private set; }

        public int Count
        {
            get { return this.GetTreeList().Count; }
        }

        #region operators

        public static bool operator == (BinarySearchTree<T> tree1, BinarySearchTree<T> tree2)
        {
            return Object.Equals(tree1, tree2);
        }

        public static bool operator != (BinarySearchTree<T> tree1, BinarySearchTree<T> tree2)
        {
            return !Object.Equals(tree1, tree2);
        }

        #endregion

        #region PublicMethods

        public void AddElement(T valueToAdd)
        {
            TreeNode<T> currentNode = this.Root;

            if (currentNode == null)
            {
                this.Root = new TreeNode<T>(valueToAdd);
                return;
            }

            while (currentNode != null)
            {
                if (valueToAdd.CompareTo(currentNode.Value) < 0)
                {
                    if (currentNode.LeftChild == null)
                    {
                        currentNode.LeftChild = new TreeNode<T>(valueToAdd);
                        currentNode.LeftChild.Parent = currentNode;
                    }
                    else
                    {
                        currentNode = currentNode.LeftChild;
                    }
                }
                else if (valueToAdd.CompareTo(currentNode.Value) > 0)
                {
                    if (currentNode.RightChild == null)
                    {
                        currentNode.RightChild = new TreeNode<T>(valueToAdd);
                        currentNode.RightChild.Parent = currentNode;
                    }
                    else
                    {
                        currentNode = currentNode.RightChild;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        public void RemoveElement(T value)
        {
            TreeNode<T> nodeToDelete = this.Find(value);

            if (nodeToDelete == null)
                return;

            this.Remove(nodeToDelete);
        }

        public bool Contains(T value)
        {
            return this.Find(value) != null;
        }

        public override bool Equals(object obj)
        {
            BinarySearchTree<T> other = obj as BinarySearchTree<T>;
            if (other == null)
                return false;

            bool areEqual = true;
            return CheckRecursiveEquality(this.Root, other.Root, areEqual);
        }

        public override int GetHashCode()
        {
            int hashCode = 0;
            hashCode = CalculateRecursiveHashCode(this.Root, hashCode);
            return hashCode;
        }

        public override string ToString()
        {
            string tabulation = "";
            StringBuilder result = new StringBuilder();
            result.Append(AppendMembers(this.Root, tabulation));

            return result.ToString();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.GetTreeList().GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public object Clone()
        {
            BinarySearchTree<T> cloning =
                new BinarySearchTree<T>(this.Root.Value);

            BuildRecursiveCloning(cloning, this.Root, null);

            return cloning;
        }

        #endregion

        #region PrivateMethods

        private TreeNode<T> Find(T value)
        {
            TreeNode<T> currentNode = this.Root;

            while (currentNode != null)
            {
                if (value.CompareTo(currentNode.Value) < 0)
                    currentNode = currentNode.LeftChild;
                else if (value.CompareTo(currentNode.Value) > 0)
                    currentNode = currentNode.RightChild;
                else
                    break;
            }
            return currentNode;
        }

        private void Remove(TreeNode<T> nodeToDelete)
        {
            //The case when the node has two children. After that the node will be
            //with at most one child
            if (nodeToDelete.LeftChild != null && nodeToDelete.RightChild != null)
            {
                TreeNode<T> replacement = nodeToDelete.RightChild;
                while (replacement.LeftChild != null)
                    replacement = replacement.LeftChild;

                nodeToDelete.Value = replacement.Value;
                nodeToDelete = replacement;
            }
            //The case when the node has at most one child
            TreeNode<T> theChild = nodeToDelete.LeftChild != null
                ? nodeToDelete.LeftChild : nodeToDelete.RightChild;

            //if the element to be deleted has one child
            if (theChild != null)
            {
                theChild.Parent = nodeToDelete.Parent;
                //if the element is the root
                if (nodeToDelete.Parent == null)
                {
                    this.Root = theChild;
                }
                else
                {
                    if (nodeToDelete.Parent.LeftChild == nodeToDelete)
                        nodeToDelete.Parent.LeftChild = theChild;
                    else
                        nodeToDelete.Parent.RightChild = theChild;
                }
            }
            else
            {
                //handle the case when the element is the root
                if (nodeToDelete.Parent == null)
                {
                    this.Root = null;
                }
                else
                {
                    //remove the element - it is leaf
                    if (nodeToDelete.Parent.LeftChild == nodeToDelete)
                        nodeToDelete.Parent.LeftChild = null;
                    else
                        nodeToDelete.Parent.RightChild = null;
                }
            }
        }
        private StringBuilder AppendMembers(TreeNode<T> currentNode, string tabulation)
        {
            StringBuilder result = new StringBuilder();

            if (currentNode != null)
            {
                result.Append(tabulation + currentNode.Value + '\n');

                if (currentNode.LeftChild != null)
                    result.Append(
                        AppendMembers(currentNode.LeftChild, tabulation + "  "));
                if (currentNode.RightChild != null)
                    result.Append(
                        AppendMembers(currentNode.RightChild, tabulation + "  "));
            }
            return result;
        }

        private List<T> GetTreeList()
        {
            List<T> list = new List<T>();
            BuildRecursiveList(this.Root, list);
            return list;
        }

        private void BuildRecursiveList(TreeNode<T> currentNode, List<T> list)
        {
            if (currentNode != null)
            {
                if (currentNode.LeftChild != null)
                    BuildRecursiveList(currentNode.LeftChild, list);

                list.Add(currentNode.Value);

                if (currentNode.RightChild != null)
                    BuildRecursiveList(currentNode.RightChild, list);
            }
        }

        private void BuildRecursiveCloning(
            BinarySearchTree<T> cloning, TreeNode<T> baseElement, TreeNode<T> newParent)
        {
            if (baseElement != null)
            {
                TreeNode<T> newElement = new TreeNode<T>(baseElement.Value);
                if (newParent == null)
                    cloning.Root = newElement;

                newElement.Parent = newParent;

                if (newParent != null)
                {
                    if (baseElement.Parent.LeftChild == baseElement)
                        newParent.LeftChild = newElement;
                    if (baseElement.Parent.RightChild == baseElement)
                        newParent.RightChild = newElement;
                }

                BuildRecursiveCloning(cloning, baseElement.LeftChild, newElement);
                BuildRecursiveCloning(cloning, baseElement.RightChild, newElement);
            }
        }
        private bool CheckRecursiveEquality(TreeNode<T> treeNode1, TreeNode<T> treeNode2, bool areEqual)
        {
            if (areEqual == true)
            {
                //first check if some of the elements is null ant the other is not
                if (treeNode1 == null && treeNode2 != null || treeNode1 != null && treeNode2 == null)
                {
                    areEqual = false;
                }
                else if (treeNode1 == null && treeNode2 == null)
                {
                    return true;
                }
                else if (treeNode1 != null && treeNode2 != null)
                {
                    if (!treeNode1.Value.Equals(treeNode2.Value))
                        areEqual = false;

                    //now check if some ot their children is null
                    if (treeNode1.LeftChild == null && treeNode2.LeftChild != null ||
                        treeNode1.LeftChild != null && treeNode2.LeftChild == null ||
                        treeNode1.RightChild == null && treeNode2.RightChild != null ||
                        treeNode1.RightChild != null && treeNode2.RightChild == null)
                        areEqual = false;
                    //none of the elements is null, and none of the children is null 
                    if (treeNode1.LeftChild != null && treeNode2.LeftChild != null)
                        areEqual = CheckRecursiveEquality(treeNode1.LeftChild, treeNode2.LeftChild, areEqual);
                    if (treeNode1.RightChild != null && treeNode2.RightChild != null)
                        areEqual = CheckRecursiveEquality(treeNode2.RightChild, treeNode1.RightChild, areEqual);
                }
            }
            return areEqual;
        }
        private int CalculateRecursiveHashCode(TreeNode<T> treeNode, int hashCode)
        {
            if (treeNode != null)
            {
                hashCode += treeNode.Value.GetHashCode();
                int leftComponent = 0;
                int rightComponent = 0;

                if (treeNode.LeftChild != null)
                    leftComponent = CalculateRecursiveHashCode(treeNode.LeftChild, 0);

                if (treeNode.RightChild != null)
                    rightComponent = CalculateRecursiveHashCode(treeNode.RightChild, 0);

                hashCode += leftComponent;
                hashCode += rightComponent;
            }
            if (hashCode > 1000000)
                hashCode = hashCode / 100000;

            return hashCode;
        }
        #endregion
    }
}
