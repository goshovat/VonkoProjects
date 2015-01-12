using System;
using System.Collections.Generic;

namespace NodesWithLeafChilds
{
    class NodesWithLeafChilds
    {
        static void Main()
        {
            try
            {
                BinaryTree<int> theTree = new BinaryTree<int>(8,
                                           new BinaryTree<int>(5,
                                               new BinaryTree<int>(7,
                                                   new BinaryTree<int>(4),
                                                   new BinaryTree<int>(13)),
                                               new BinaryTree<int>(9)),
                                           new BinaryTree<int>(7,
                                               new BinaryTree<int>(9),
                                               new BinaryTree<int>(11,
                                                    new BinaryTree<int>(14),
                                                    new BinaryTree<int>(15))
                                                    ));

                theTree.PrintTree();

                PrintNodesWithLeafChilds(theTree);

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

        private static void PrintNodesWithLeafChilds(BinaryTree<int> tree)
        {
            if (tree == null)
                Console.WriteLine("Error! Cannot complete the task with a null tree!");

            Console.WriteLine("The nodes which have only leaf children are: ");
            PrintNodesWithLeafChilds(tree.Root);
            Console.WriteLine();
        }

        private static void PrintNodesWithLeafChilds(BinaryTreeNode<int> node)
        {
            if (node == null)
                return;

            if (node.LeftChild != null || node.RightChild != null)
            {
                bool isLeaf = true;

                if (node.LeftChild != null)
                {
                    if (node.LeftChild.LeftChild != null ||
                        node.LeftChild.RightChild != null)
                    {
                        isLeaf = false;
                    }

                    PrintNodesWithLeafChilds(node.LeftChild);

                }

                if (node.RightChild != null)
                {
                    if (node.RightChild.LeftChild != null ||
                        node.RightChild.RightChild != null)
                    {
                        isLeaf = false;
                    }

                    PrintNodesWithLeafChilds(node.RightChild);
                }

                if (isLeaf)
                    Console.Write(node.Value + " ");
            }         
        }
    }
}
