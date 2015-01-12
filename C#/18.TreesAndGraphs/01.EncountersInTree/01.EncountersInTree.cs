using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncountersInTree
{
    class EncountersInTree
    {
        static void Main()
        {
            try
            {
                Tree<int> theTree = new Tree<int>(15,
                                        new Tree<int>(6,
                                            new Tree<int>(3),
                                            new Tree<int>(6)),
                                        new Tree<int>(3,
                                            new Tree<int>(4)),
                                        new Tree<int>(2,
                                            new Tree<int>(6,
                                                new Tree<int>(5)),
                                            new Tree<int>(6)),
                                        new Tree<int>(8,
                                            new Tree<int>(6),
                                            new Tree<int>(6))
                                            );

                theTree.PrintTree();

                int numberToFind = 6;
                int encounters = FindEncounters(numberToFind, theTree);

                Console.WriteLine("The number of encounters of {0} is {1}",
                    numberToFind, encounters);
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

        private static int FindEncounters(int numberToFind, Tree<int> tree)
        {
            if (tree == null)
                Console.WriteLine("Error! Cannot find encounters in a null tree!");

            int encounters = 0;  
            FindEncounters(numberToFind, tree.Root, ref encounters);

            return encounters;
        }

        private static void FindEncounters(int numberToFind, TreeNode<int> node, ref int encounters)
        {
            if (node.Value == numberToFind)
                encounters++;

            foreach (TreeNode<int> child in node.Children)
                FindEncounters(numberToFind, child, ref encounters);
        }
    }
}
