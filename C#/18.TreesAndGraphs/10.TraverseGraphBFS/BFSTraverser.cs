using System;
using System.Collections.Generic;

namespace TraverseGraphBFS
{
    public static class BFSTraverser
    {
        public static int FindNumberNodes(int[,] graph, int startNode)
        {
            //add the first node to the list of nodes we have stepped upon
            List<int> visitedNodes = new List<int>();
            int numberOfNodes = 1;
            visitedNodes.Add(startNode);

            Queue<int> exploredNodes = new Queue<int>();

            //explore all paths leading from the startNode
            for (int i = 0; i < graph.GetLength(1); i++)
            {
                if (graph[startNode, i] == 1)
                {
                    //if we find a path to explore, first mark it as explored
                    graph[startNode, i] = -1;
                    //explore the node on the other side
                    exploredNodes.Enqueue(i);
                }
            }

            while (exploredNodes.Count > 0)
            {
                //in this moment we step on the next node
                int currentNode = exploredNodes.Dequeue();

                if (!visitedNodes.Contains(currentNode))
                {
                    visitedNodes.Add(currentNode);
                    numberOfNodes++;
                }

                for (int i = 0; i < graph.GetLength(1); i++)
                {
                    if (graph[currentNode, i] == 1)
                    {
                        graph[currentNode, i] = -1;
                        exploredNodes.Enqueue(i);
                    }
                }
            }

            return numberOfNodes;
        }
    }
}
