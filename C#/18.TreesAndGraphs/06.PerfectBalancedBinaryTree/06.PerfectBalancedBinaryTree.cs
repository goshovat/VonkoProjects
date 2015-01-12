using System;
using System.Collections.Generic;
using NodesWithLeafChilds;

namespace PerfectBalancedBinaryTree
{
    class Program
    {
        static void Main()
        {
            try
            {
                BinaryTree<int> theThree = new BinaryTree<int>(6,
                                               new BinaryTree<int>(5,
                                                   new BinaryTree<int>(7,
                                                       new BinaryTree<int>(0),
                                                       new BinaryTree<int>(10)),
                                                   new BinaryTree<int>(8,
                                                       new BinaryTree<int>(33),
                                                       null)),
                                               new BinaryTree<int>(4,
                                                   new BinaryTree<int>(13,
                                                       new BinaryTree<int>(17),
                                                       null),
                                                   new BinaryTree<int>(18,
                                                       new BinaryTree<int>(19),
                                                       new BinaryTree<int>(25)))
                                                       );

                theThree.PrintTree();

                PrintIsTreePerfectBalanced(theThree);

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

        private static void PrintIsTreePerfectBalanced(BinaryTree<int> theThree)
        {
            bool isPerfectBalanced = true;
            int currentDepth = 0;
            int maxDepth = 0;
            int minDepth = int.MaxValue;

            Console.WriteLine("The total number of nodes in the tree is: {0}", IterateTree(ref isPerfectBalanced, 
                ref currentDepth, ref maxDepth, ref minDepth, theThree.Root));
            Console.WriteLine("Min depth in the tree is: {0}", minDepth);
            Console.WriteLine("Max depth in the tree is: {0}", maxDepth);

            //make the final check if the tree is perfect balanced
            if (isPerfectBalanced)
                Console.WriteLine("The tree is perfect balanced.");
            else
                Console.WriteLine("The tree is NOT perfect balanced.");
        }

        //not the best example of a tight coupling for a method!!!
        private static int IterateTree(ref bool isPerfectBalanced, 
            ref int currentDepth, ref int maxDepth, ref int minDepth, BinaryTreeNode<int> node)
        {
            int countLeft = 0;
            int countRight = 0;

            if (node.LeftChild != null)
            {
                currentDepth++;

                countLeft = IterateTree(ref isPerfectBalanced, ref currentDepth, 
                    ref maxDepth, ref minDepth, node.LeftChild);

                currentDepth--;
            }

            if (node.RightChild != null)
            {
                currentDepth++;

                countRight = IterateTree(ref isPerfectBalanced, ref currentDepth, 
                    ref maxDepth, ref minDepth, node.RightChild);

                currentDepth--;
            }

            //we need the min depth of the leafs, not of any node
            if (IsALeaf(node))
            {
                if (currentDepth < minDepth)
                    minDepth = currentDepth;
            }

            //the leafs will always get the max depth, no need to check if the element is a leaf
            if (currentDepth > maxDepth)
                maxDepth = currentDepth;

            //we will compare the number of nodes in the left and right childs in the root,
            //in order to make it only once
            if (currentDepth == 0) 
            { 
               if (countLeft - countRight > 1 || countLeft - countRight < -1)
                    isPerfectBalanced = false;
               if (maxDepth - minDepth >= 1)
                   isPerfectBalanced = false;
            }

            return countLeft + countRight + 1;
        }

        private static bool IsALeaf(BinaryTreeNode<int> node)
        {
            if (node.LeftChild == null && node.RightChild == null)
                return true;
            else
                return false;
        }
    }
}