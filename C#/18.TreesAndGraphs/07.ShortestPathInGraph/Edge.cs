using System;
using System.Collections.Generic;

namespace ShortestPathInGraph
{
    public class Edge
    {
        private int firstNode;
        private int secondNode;
        private Edge previous;

        public Edge(int firstNode, int secondNode)
            :this(firstNode, secondNode, null)
        {
        }

        public Edge(int firstNode, int secondNode, Edge previous)
        {
            this.firstNode = firstNode;
            this.secondNode = secondNode;
            this.previous = previous;
        }

        public int FirstNode
        {
            get { return this.firstNode; }
        }

        public int SecondNode
        {
            get { return this.secondNode; }
        }

        public Edge Previous
        {
            get { return this.previous; }
        }
    }
}
