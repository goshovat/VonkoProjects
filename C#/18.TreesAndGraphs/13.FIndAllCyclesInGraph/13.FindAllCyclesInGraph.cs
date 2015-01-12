using System;
using System.Collections.Generic;

namespace FindAllCyclesInGraph
{
    class FindAllCyclesInGraph
    {
        static void Main()
        {
            InitializeGraph();
            Node.SetReferences();
            var allCycles = new List<Cycle> (FindAllCycles());
            PrintAllCycles(allCycles);
        }

        private static void InitializeGraph()
        {
            new Node(1, 2);
            new Node(0);
            new Node(1, 3);
            new Node(4, 5);
            new Node(2);
            new Node(6);
            new Node(5);
        }

        private static IEnumerable<Cycle> FindAllCycles()
        {
            HashSet<Node> alreadyVisited = new HashSet<Node>();
            alreadyVisited.Add(Node.AllNodes[0]);
            return FindAllCycles(alreadyVisited, Node.AllNodes[0]);
        }

        private static IEnumerable<Cycle> FindAllCycles(HashSet<Node> alreadyVisited, Node curNode)
        {
            for (int i = 0; i < curNode.Edges.Count; i++)
            {
                Edge curEdge = curNode.Edges[i];
                if (alreadyVisited.Contains(curEdge.B))
                {
                    yield return new Cycle(curEdge);
                }
                else
                {
                    HashSet<Node> newSet = i == curNode.Edges.Count - 1 ? alreadyVisited : new HashSet<Node>(alreadyVisited);
                    newSet.Add(curEdge.B);

                    foreach (Cycle cycle in FindAllCycles(newSet, curEdge.B))
                    {
                        cycle.Build(curEdge);
                        yield return cycle;
                    }
                }
            }
        }

        private static void PrintAllCycles(List<Cycle> allCycles)
        {
            foreach (Cycle cycle in allCycles)
            {
                foreach(Edge edge in cycle.Members) 
                {
                    Console.Write(edge.A + ", " + edge.B + ", ");
                }
                Console.WriteLine();
            }        
        }
    }
}
