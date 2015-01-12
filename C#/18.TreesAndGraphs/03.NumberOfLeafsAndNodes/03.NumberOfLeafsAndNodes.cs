using System;
using System.Collections.Generic;
using EncountersInTree;

namespace NumberOfLeafsAndNodes
{
    class NumberOfLeafsAndNodes
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
                
                PrintLeafsInnerNodes(theTree);
                
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

        private static void PrintLeafsInnerNodes(Tree<int> tree)
        {
            if (tree == null)
                Console.WriteLine("Error! Cannot complete the task with a null tree!");

            int numberLeafs = 0;
            int numberInnerNodes = 0;

            FindLeafsInnerNodes(ref numberLeafs, ref numberInnerNodes, tree.Root);

            Console.WriteLine("The number of leafs in the tree is {0}.", numberLeafs);
            Console.WriteLine("The number of inner nodes in the tree is {0}", numberInnerNodes);
        }

        private static void FindLeafsInnerNodes(ref int numberLeafs, ref int numberInnerNodes, TreeNode<int> node)
        {
            if (node.ChildrenCount == 0)
                numberLeafs++;

            if (node.ChildrenCount != 0 && node.Parent != null)
                numberInnerNodes++;

            foreach (TreeNode<int> child in node.Children)
                FindLeafsInnerNodes(ref numberLeafs, ref numberInnerNodes, child);
        }
    }
}
