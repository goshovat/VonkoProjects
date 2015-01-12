using System;
using System.Collections.Generic;
using MinPaths_Dijkstra;

namespace AllSubgraphs
{
    class AllSubgraphs
    {
        static Dictionary<Node, List<Edge>> graph =
            new Dictionary<Node, List<Edge>>();

        static void Main()
        {
            //initialize the graph, its nodes and edges
        
            Node node0 = new Node(0);
            Node node1 = new Node(1);
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
            graph[node1] = new List<Edge>();
            graph[node3] = new List<Edge>() 
            {
                new Edge(8, node1),
            };
            graph[node4] = new List<Edge>() 
            {
                new Edge(2, node7),
                new Edge(9, node12),
            };
            graph[node7] = new List<Edge>() 
            {
                new Edge(4, node12)
            };
            graph[node12] = new List<Edge>();
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

            int components = 0;

            if (graph.Count > 0)
            {
                foreach (Node node in graph.Keys)
                {
                    if (!node.IsVisited)
                    {
                        DFS(node);
                        Console.WriteLine(new String('-', 20));
                        components++;
                    }
                }

                Console.WriteLine("The total number of componentsi is: {0}", components);
            }
            else
            {
                Console.WriteLine("The number of connected subgraphs is 0.");
            }
        }

        private static void DFS(Node node)
        {
            if (node.IsVisited)
                return;

            node.IsVisited = true;
            Console.WriteLine(node.Value);

            foreach (Edge edge in graph[node])
                DFS(edge.Destination);
        }
    }
}
