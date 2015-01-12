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

                List<int> sumsAtEveryLevel = GetSumsAtEveryLevel(theTree);

                PrintSumsAtEveryLevel(sumsAtEveryLevel);

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

        private static List<int> GetSumsAtEveryLevel(Tree<int> tree)
        {
            if (tree == null)
                Console.WriteLine("Error! Cannot complete the task with a null tree!");

            List<int> sumsAtEveryLevel = new List<int>();
            int currentLevel = 0;

            FindSumsAtEveryLevel(ref sumsAtEveryLevel, ref currentLevel, tree.Root);

            return sumsAtEveryLevel;
        }

        private static void FindSumsAtEveryLevel(ref List<int> sumsAtEveryLevel, ref int currentLevel, TreeNode<int> node)
        {
            if (currentLevel >= sumsAtEveryLevel.Count)
                sumsAtEveryLevel.Add(0);

            sumsAtEveryLevel[currentLevel] += node.Value;

            currentLevel++;

            foreach (TreeNode<int> child in node.Children)
            {
                FindSumsAtEveryLevel(ref sumsAtEveryLevel, ref currentLevel, child);
            }

            currentLevel--;
        }

        private static void PrintSumsAtEveryLevel(List<int> sumsAtEveryLevel)
        {
            Console.WriteLine("The sums at the different levels are: ");

            for (int i = 0; i < sumsAtEveryLevel.Count; i++)
            {
                Console.WriteLine("Sum at level {0} -> {1}", i, sumsAtEveryLevel[i]);
            }
            Console.WriteLine();
        }
    }
}
