using System;
using System.Collections.Generic;

namespace OilerCycle
{
    class OilerCycle
    {
        static List<int> allNodes;

        static int[,] graph;

        static void Main()
        {
            allNodes = new List<int>() { 1, 2, 3, 4, 5, 6 };

            graph = new int[,]{
                               {0,0,0,0,0,0,0},
                               {0,0,1,0,0,0,0},
                               {0,0,0,1,0,0,0},
                               {0,0,0,0,1,0,0},
                               {0,0,0,0,0,1,0},
                               {0,0,0,0,0,0,1},
                               {0,1,0,0,0,0,0}
                           };

            FindOilerCycle();
        }

        private static void FindOilerCycle()
        {
            bool oilerCycleFound = false;

            for (int i = 0; i < allNodes.Count; i++)
            {
                List<int> currentSequence = new List<int>();

                //try to find an oiler cycle starting from every node
                TraverseGraph(allNodes[i], allNodes[i], 
                    currentSequence, ref oilerCycleFound);
            }

            if (!oilerCycleFound)
                Console.WriteLine("Oiler cycle was not found!");
        }

        private static void TraverseGraph(int currentNode, int lastNode, 
            List<int> currentSequence, ref bool oilerCycleFound)
        {
            if (!currentSequence.Contains(currentNode))
                currentSequence.Add(currentNode);

            //the cycle is closed
            if (currentNode == lastNode)
            {
                if (IsOilerCycle(currentSequence))
                {
                    oilerCycleFound = true; 
                    PrintOilerCycle(currentSequence);
                }
            }

            for (int i = 0; i < graph.GetLength(0); i++)
            {
                //find the closest connection to other node
                if (graph[currentNode, i] == 1)
                {
                    graph[currentNode, i] = -1;

                    TraverseGraph(i, lastNode, new List<int>(currentSequence), 
                        ref oilerCycleFound);

                    graph[currentNode, i] = 1;
                }
            }
        }

        private static bool IsOilerCycle(List<int> currentSequence)
        {
            for (int row = 0; row < graph.GetLength(0); row++)
            {
                for (int col = 0; col < graph.GetLength(1); col++)
                {
                    if (graph[row, col] == 1)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static void PrintOilerCycle(List<int> currentSequence)
        {
            Console.WriteLine("Oiler Cycle: ");
            for (int i = 0; i < currentSequence.Count; i++)
            {
                Console.Write(currentSequence[i] + " ");
            }
            Console.WriteLine(currentSequence[0]);
            Console.WriteLine(new String('-', 30));
        }
    }
}
