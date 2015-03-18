namespace BinarySearchTree
{
    using System;
    using System.Collections.Generic;

    class BinarySearchTreeMain
    {
        static void Main()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>(5);
            tree.AddElement(3);
            tree.AddElement(6);
            tree.AddElement(8);
            tree.AddElement(-5);
            tree.AddElement(9);
            tree.AddElement(7);
            tree.AddElement(4);
            tree.AddElement(10);

            foreach(int element in tree)
                Console.WriteLine(element);

            BinarySearchTree<int> cloning = tree.Clone() as BinarySearchTree<int>;
            tree.AddElement(90);

            Console.WriteLine(tree);
            Console.WriteLine(cloning);

            Console.WriteLine(tree.Equals(cloning));
            Console.WriteLine(tree.GetHashCode());
            Console.WriteLine(cloning.GetHashCode());

            Console.WriteLine(tree == cloning);
            Console.WriteLine(tree != cloning);

            tree.RemoveElement(5);
            cloning.RemoveElement(5);
            Console.WriteLine(tree);
            tree.RemoveElement(9);
            cloning.RemoveElement(9);
            Console.WriteLine(tree);
            tree.RemoveElement(4);
            cloning.RemoveElement(4);
            Console.WriteLine(tree);
            tree.RemoveElement(6);
            cloning.RemoveElement(6);
            tree.RemoveElement(3);
            cloning.RemoveElement(3);
            tree.RemoveElement(-5);
            cloning.RemoveElement(-5);
            Console.WriteLine(tree);
            Console.WriteLine(cloning);
            tree.RemoveElement(7);
            cloning.RemoveElement(7);
            tree.RemoveElement(8);
            cloning.RemoveElement(8);
            tree.RemoveElement(10);
            cloning.RemoveElement(10);
            tree.RemoveElement(90);
            Console.WriteLine(cloning.Equals(tree));
            tree.AddElement(3);
            cloning.AddElement(1);
            tree.AddElement(8);
            cloning.AddElement(8);
            tree.AddElement(2);
            cloning.AddElement(2);
            Console.WriteLine(tree.Equals(cloning));
            Console.WriteLine(tree == cloning);
            Console.WriteLine(tree != cloning);
            Console.WriteLine(tree);
            Console.WriteLine(cloning);
        }
    }
}
