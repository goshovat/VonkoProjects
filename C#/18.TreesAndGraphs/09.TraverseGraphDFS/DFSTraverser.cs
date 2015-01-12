using System;
using System.Collections.Generic;

namespace TraverseGraphDFS
{
    public static class DFSTraverser
    {
        public static int FindNumberNodes(int[,] graph, int startNode) 
        {
            if (graph == null)
                throw new ApplicationException("Error! The given graph has null value.");

            int numberNodes = 0;
            List<int> visitedNodes = new List<int>();

            GetNumberNodes(graph, startNode, ref numberNodes, visitedNodes);

            return numberNodes;
        }

        private static void GetNumberNodes(int[,] graph, int currentNode, 
            ref int numberNodes, List<int> visitedNodes)
        {
            if (!visitedNodes.Contains(currentNode))
            {
                numberNodes++;
                visitedNodes.Add(currentNode);
            }

            for (int i = 0; i < graph.GetLength(1); i++)
            {
                if (graph[currentNode, i] == 1)
                {
                    //mark the vertex as visited
                    graph[currentNode, i] = -1;
                    GetNumberNodes(graph, i, ref numberNodes, visitedNodes);
                }
            }
        }
    }
}
