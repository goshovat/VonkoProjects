using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPathInGraph
{
    class ShortestPathInGraph
    {
        static int[,] graph = new int[16, 16];

        static void Main()
        {
            graph = new int[16, 16] {
                                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                   {0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0},
                                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
                                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
                                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                   {0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0},
                                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
                                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                };

            int startNode = 1;
            int endNode = 15;

            Edge lastEdge = FindLastEdge(startNode, endNode);

            PrintShortestPath(startNode, lastEdge);
        }

        public static Edge FindLastEdge(int startNode, int endNode)
        {
            Queue<Edge> edgeQueue = new Queue<Edge>();

            //add the Edgees from the first node
            for (int i = 0; i < graph.GetLength(1); i++)
            {
                if (graph[startNode, i] == 1)
                {
                    edgeQueue.Enqueue(new Edge(startNode, i));
                    graph[startNode, i] = 0;
                }
            }

            while (edgeQueue.Count > 0)
            {
                Edge currentEdge = edgeQueue.Dequeue();

                if (currentEdge.SecondNode == endNode)
                {
                    return currentEdge;
                }

                for (int i = 0; i < graph.GetLength(1); i++)
                {
                    if (graph[currentEdge.SecondNode, i] == 1)
                    {
                        edgeQueue.Enqueue(new Edge(currentEdge.SecondNode, i, currentEdge));
                        graph[currentEdge.SecondNode, i] = 0;
                    }
                }
            }

            //if the target node is not found in the graph, then there is no Edge leading to it
            return null;
        }

        //this method will rteriev the shortest path, once we have the final Edge
        private static void PrintShortestPath(int startNode, Edge lastEdge)
        {
            if (lastEdge == null)
            {
                Console.WriteLine("The target node was not found!");
                return;
            }

            Edge currentEdge = lastEdge;
            Stack<int> nodes = new Stack<int>();
            while (currentEdge != null)
            {
                nodes.Push(currentEdge.SecondNode);
                currentEdge = currentEdge.Previous;
            }

            Console.WriteLine("The shortes path to the target node is: ");
            Console.Write(startNode + " ");
            while (nodes.Count > 0)
                Console.Write(nodes.Pop() + " ");

            Console.WriteLine();
        }
    }
}
