using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

namespace MinPaths_Dijkstra
{
    class MinPaths_Dijkstra
    {
        static Dictionary<Node, List<Edge>> graph =
                new Dictionary<Node, List<Edge>>();
        static OrderedBag<Node> bag = new OrderedBag<Node>();   

        static void Main()
        {
            //initialize the graph nodes and edges
            
            Node node0 = new Node(0);
            Node node1 =  new Node(1);
            Node node3 = new Node(3);
            Node node4 = new Node(4);
            Node node7 = new Node(7);
            Node node12 = new Node(12);
            Node node13 = new Node(13);
            Node node14 = new Node(14);
            Node node15 = new Node(15);

            graph[node0] = new List<Edge>()
            {
                new Edge(5, node1),
                new Edge(7, node3)
            };
            graph[node1] = new List<Edge>()
            {
                new Edge(3, node4)
            };
            graph[node3] = new List<Edge>() 
            {
                new Edge(8, node1),
                new Edge(6, node7)
            };
            graph[node4] = new List<Edge>() 
            {
                new Edge(2, node7),
                new Edge(9, node12),
                new Edge(11, node14)
            };
            graph[node7] = new List<Edge>() 
            {
                new Edge(4, node12)
            };
            graph[node12] = new List<Edge>() 
            {
                new Edge(3, node13)
            };
            graph[node13] = new List<Edge>() 
            {
                new Edge(1, node14),
                new Edge(2, node15)
            };
            graph[node14] = new List<Edge>() 
            {
                new Edge(3, node15)
            };
            graph[node15] = new List<Edge>();

            int prevLen = 0;

            foreach (Node key in graph.Keys)
            {
                bag.Add(key);

                //find the necessary length of previous array
                if (key.Value > prevLen)
                    prevLen = key.Value;
            }

            //by this array we will recover the traveled path
            int[] previous = new int[prevLen + 1];

            foreach (Node endNode in graph.Keys)
                PrintShortestPaths(node0, endNode, previous);
        }

        private static void PrintShortestPaths
            (Node startNode, Node endNode, int[] previous)
        {
            startNode.DijkstraDistance = 0;

            while (bag.Count > 0)
            {
                Node currentNode = bag.GetFirst();

                if (currentNode.Value == int.MaxValue)
                    break;

                foreach (Edge edge in graph[currentNode])
                {
                    Node destNode = edge.Destination;
                    int potDistance = currentNode.DijkstraDistance + edge.Distance;

                    if (potDistance < destNode.DijkstraDistance)
                    {
                        destNode.DijkstraDistance = potDistance;
                        previous[destNode.Value] = currentNode.Value;
                    }
                }

                bag.RemoveFirst();
            }

            PrintPath(startNode, endNode, previous);
        }

        private static void PrintPath
            (Node startNode, Node endNode, int[] previous)
        {
            Console.Write("StartNode: {0}, EndNode: {1}; ", startNode.Value, endNode.Value);
            Console.WriteLine("Total Distance: {0}", endNode.DijkstraDistance);
            List<int> finalPath = new List<int>();

            int index = endNode.Value;
            finalPath.Add(endNode.Value);

            while (index != startNode.Value)
            {
                finalPath.Add(previous[index]);
                index = previous[index];
            }

            finalPath.Reverse();
            Console.WriteLine("Path -> " + string.Join(",", finalPath));
            Console.WriteLine(new String('-', 20) + "\n");
        }
    }
}
