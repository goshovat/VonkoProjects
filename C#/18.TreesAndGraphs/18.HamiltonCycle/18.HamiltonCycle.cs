using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamiltonCycle
{
    class HamiltonCycle
    {
        static List<int> allNodes;

        static int[,] graph;

        static void Main()
        {
            allNodes = new List<int>() { 1, 2, 3, 4, 5, 6 };

            graph = new int[,]{
                               {0,0,0,0,0,0,0},
                               {0,0,1,0,0,0,0},
                               {0,0,0,1,1,0,0},
                               {0,0,0,0,1,0,0},
                               {0,0,0,0,0,1,0},
                               {0,0,0,0,0,0,1},
                               {0,1,0,0,0,0,0}
                           };

            FindHamiltonCycle();
        }

        private static void FindHamiltonCycle()
        {
            bool foundHamiltonCycle = false;

            for (int i = 0; i < allNodes.Count; i++)
            {
                List<int> currentSequence = new List<int>();

                TraverseGraph(allNodes[i], allNodes[i], currentSequence, ref foundHamiltonCycle);
            }

            if (!foundHamiltonCycle)
                Console.WriteLine("Hamilton cycle was not found!");
        }

        private static void TraverseGraph(int currentNode, int endNode,
            List<int> currentSequence, ref bool foundHamiltonCycle)
        {
            if (currentNode == endNode)
            {
                if (IsHamiltonCycle(currentSequence))
                {
                    foundHamiltonCycle = true;
                    PrintSequence(currentSequence);
                }
            }

            //add the node we stepped upon to the sequence
            currentSequence.Add(currentNode);

            //check the other vertexes going out from this node
            for (int i = 0; i < graph.GetLength(1); i++)
            {
                if (graph[currentNode, i] == 1)
                {
                    graph[currentNode, i] = -1;

                    TraverseGraph(i, endNode, currentSequence, ref foundHamiltonCycle);

                    graph[currentNode, i] = 1;
                }
            }
        }

        private static bool IsHamiltonCycle(List<int> currentSequence)
        {
            if (currentSequence.Count != allNodes.Count)
                return false;

            List<int> sortedList = new List<int>(currentSequence);
            sortedList.Sort();

            for (int i = 0; i < sortedList.Count; i++)
            {
                if (sortedList[i] != allNodes[i])
                    return false;
            }

            return true;
        }

        private static void PrintSequence(List<int> currentSequence)
        {
            Console.WriteLine("Hamilton Cycle: ");
            for (int i = 0; i < currentSequence.Count; i++)
            {
                Console.Write(currentSequence[i] + " ");
            }
            Console.WriteLine(currentSequence[0]);
            Console.WriteLine(new String('-', 30));
        }
    }
}
