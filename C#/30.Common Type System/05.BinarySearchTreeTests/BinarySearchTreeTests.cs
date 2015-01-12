namespace BinarySearchTreeTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BinarySearchTree;
    using System.Text;
    using System.Collections.Generic;

    [TestClass]
    public class BinarySearchTreeTests
    {
        public static BinarySearchTree<int> tree;

        [TestMethod]
        [TestInitialize]
        public void TreeInitializationTest()
        {
            tree = new BinarySearchTree<int>(5);
            tree.AddElement(3);
            tree.AddElement(6);
            tree.AddElement(8);
            tree.AddElement(-5);
            tree.AddElement(9);
            tree.AddElement(7);
            tree.AddElement(4);
            tree.AddElement(10);

            Assert.AreEqual(5, tree.Root.Value);
        }
        [TestMethod]
        public void AddElementsTest()
        {
            Assert.AreEqual(9, tree.Count);
        }
        [TestMethod]
        public void ForeachTest()
        {
            StringBuilder treeResult = new StringBuilder();
            foreach (int number in tree)
                treeResult.Append(number + " ");

            List<int> treeList = new List<int>() { 5, 3, 6, 8, -5, 9, 7, 4, 10};
            treeList.Sort();
            StringBuilder listResult = new StringBuilder();
            foreach (int number in treeList)
                listResult.Append(number + " ");

            Assert.AreEqual(listResult.ToString(), treeResult.ToString());
        }
        [TestMethod]
        public void TreeCloningTest()
        {
            BinarySearchTree<int> cloning = tree.Clone() as BinarySearchTree<int>;
            Assert.AreEqual(tree, cloning);
            Assert.AreEqual(tree == cloning, true);
            Assert.AreEqual(tree != cloning, false);

            tree.AddElement(90);
            Assert.AreNotEqual(tree, cloning);
            Assert.AreEqual(tree == cloning, false);
            Assert.AreEqual(tree != cloning, true);
            tree.RemoveElement(90);

            tree.RemoveElement(5);
            cloning.RemoveElement(5);
            Assert.AreEqual(tree, cloning);
            tree.RemoveElement(9);
            cloning.RemoveElement(9);
            Assert.AreEqual(tree, cloning);
            tree.RemoveElement(4);
            cloning.RemoveElement(4);
            Assert.AreEqual(tree, cloning);
            tree.RemoveElement(6);
            cloning.RemoveElement(6);
            tree.RemoveElement(3);
            cloning.RemoveElement(3);
            tree.RemoveElement(-5);
            cloning.RemoveElement(-5);
            Assert.AreEqual(tree, cloning);
            tree.RemoveElement(7);
            cloning.RemoveElement(7);
            tree.RemoveElement(8);
            cloning.RemoveElement(8);
            tree.RemoveElement(10);
            cloning.RemoveElement(10);
            tree.AddElement(90);
            tree.RemoveElement(90);
            Assert.AreEqual(tree, cloning);
            tree.AddElement(3);
            cloning.AddElement(1);
            tree.AddElement(8);
            cloning.AddElement(8);
            tree.AddElement(2);
            cloning.AddElement(2);
            Assert.AreNotEqual(tree, cloning);
            Assert.AreEqual(tree == cloning, false);
            Assert.AreEqual(tree != cloning, true);
        }
        [TestMethod]
        public void GetHashCodeTest()
        {
            BinarySearchTree<int> cloning = tree.Clone() as BinarySearchTree<int>;
            Assert.AreEqual(tree.GetHashCode(), cloning.GetHashCode());
        }
        [TestMethod]
        public void ContainsTest()
        {
            Assert.AreEqual(tree.Contains(5), true);
            Assert.AreEqual(tree.Contains(99), false);
        }
        [TestMethod]
        public void ToStringTest()
        {
            BinarySearchTree<int> cloning = tree.Clone() as BinarySearchTree<int>;
            Assert.AreEqual(tree.ToString(), cloning.ToString());
        }
    }
}
