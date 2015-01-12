using System;
using System.Collections.Generic;
using ShortestPathInGraph;

namespace IsGraphCyclic
{
    class IsGraphCyclic
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
                                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1},
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

            Vertex repeatedVertex = GetGraphCycle(startNode, endNode);

            PrintPath(startNode, repeatedVertex);
        }

        public static Vertex GetGraphCycle(int startNode, int endNode)
        {
            Queue<Vertex> vertexQueue = new Queue<Vertex>();

            //add the vertexes from the first node
            for (int i = 0; i < graph.GetLength(1); i++)
            {
                if (graph[startNode, i] == 1)
                {
                    vertexQueue.Enqueue(new Vertex(startNode, i));
                    graph[startNode, i] = -1;
                }
            }

            while (vertexQueue.Count > 0)
            {
                Vertex currentVertex = vertexQueue.Dequeue();

                for (int i = 0; i < graph.GetLength(1); i++)
                {
                    if (graph[currentVertex.SecondNode, i] == 1)
                    {
                        vertexQueue.Enqueue(new Vertex(currentVertex.SecondNode, i, currentVertex));
                        graph[currentVertex.SecondNode, i] = -1;
                    }
                    else if (graph[currentVertex.SecondNode, i] == -1)
                    {
                        return currentVertex;
                    }
                }
            }

            //if the target node is not found in the graph, then there is no vertex leading to it
            return null;
        }

        //this method will rteriev the shortest path, once we have the final vertex
        private static void PrintPath(int startNode, Vertex lastVertex)
        {
            if (lastVertex == null)
            {
                Console.WriteLine("The graph is not cyclic!");
                return;
            }

            Vertex currentVertex = lastVertex;
            Stack<int> nodes = new Stack<int>();
            while (currentVertex != null)
            {
                nodes.Push(currentVertex.SecondNode);
                currentVertex = currentVertex.Previous;
            }

            Console.WriteLine("The graph is cyclic: ");
            Console.Write(startNode + " ");
            while (nodes.Count > 0)
                Console.Write(nodes.Pop() + " ");

            Console.WriteLine();
        }
    }
}
