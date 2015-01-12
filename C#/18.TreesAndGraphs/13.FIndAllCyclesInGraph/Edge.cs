using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FindAllCyclesInGraph
{
    public sealed class Edge
    {
        public static readonly ReadOnlyCollection<Edge> AllEdges;
        static readonly List<Edge> allEdges;

        static Edge()
        {
            allEdges = new List<Edge>();
            AllEdges = new ReadOnlyCollection<Edge>(allEdges);
        }

        public int Index { get; private set; }
        public Node A { get; private set; }
        public Node B { get { return Node.allNodes[this.bIndex]; } }
        private readonly int bIndex;

        internal Edge(Node a, int bIndex)
        {
            this.Index = allEdges.Count;
            this.A = a;
            this.bIndex = bIndex;
            allEdges.Add(this);
        }

        public override string ToString()
        {
            return this.Index.ToString();
        }
    }
}
