using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FindAllCyclesInGraph
{
    public sealed class Node
    {
        public static readonly ReadOnlyCollection<Node> AllNodes;
        internal static readonly List<Node> allNodes;

        static Node()
        {
            allNodes = new List<Node>();
            AllNodes = new ReadOnlyCollection<Node>(allNodes);
        }

        //call this method after all nodes have been created
        public static void SetReferences()
        {
            foreach (Edge edge in Edge.AllEdges)
                edge.A.edges.Add(edge);
        }

        //All edges linking from this node, not to it
        public ReadOnlyCollection<Edge> Edges { get; private set; }
        internal List<Edge> edges;
        public int Index { get; private set; }

        public Node(params int[] nodeIndicesConnectedTo)
        {
            this.edges = new List<Edge>(nodeIndicesConnectedTo.Length);
            this.Edges = new ReadOnlyCollection<Edge>(edges);
            this.Index = allNodes.Count;
            allNodes.Add(this);
            foreach (int nodeIndex in nodeIndicesConnectedTo)
                new Edge(this, nodeIndex);
        }

        public override string ToString()
        {
            return this.Index.ToString();
        }
    }
}
