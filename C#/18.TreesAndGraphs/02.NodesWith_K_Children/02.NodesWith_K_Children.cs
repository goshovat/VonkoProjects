using System;
using System.Collections.Generic;
using EncountersInTree;

namespace NodesWith_K_Children
{
    class NodesWith_K_Children
    {
        static void Main()
        {
            try
            {
                Tree<int> theTree = new Tree<int>(8,
                                       new Tree<int>(5),
                                       new Tree<int>(6),
                                       new Tree<int>(7,
                                           new Tree<int>(9),
                                           new Tree<int>(10),
                                           new Tree<int>(11,
                                                new Tree<int>(14),
                                                new Tree<int>(15),
                                                new Tree<int>(16)))
                                                );

                theTree.PrintTree();
                int k = 3;

                PrintNodesWith_K_Children(k, theTree);
            }
            catch (ApplicationException applExc)
            {
                Console.WriteLine(applExc.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }

        private static void PrintNodesWith_K_Children(int k, Tree<int> tree)
        {
            if (tree == null)
                Console.WriteLine("Error! Cannot complete the task with a null tree!");

            Console.WriteLine("The nodes with {0} children are: ", k);

            PrintNodesWith_K_Children(k, tree.Root);

            Console.WriteLine();
        }

        private static void PrintNodesWith_K_Children(int k, TreeNode<int> node)
        {
            if (node.ChildrenCount == k)
                Console.Write(node.Value + " ");

            foreach (TreeNode<int> child in node.Children)
                PrintNodesWith_K_Children(k, child);
        }
    }
}
