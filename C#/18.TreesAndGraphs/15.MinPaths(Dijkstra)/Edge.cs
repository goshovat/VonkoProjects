using System;
using System.Collections.Generic;

namespace MinPaths_Dijkstra
{
    public class Edge
    {
        private int distance;
        private Node destination;

        public Edge(int distance, Node destination)
        {
            this.distance = distance;
            this.destination = destination;
        }

        public int Distance
        {
            get { return this.distance; }
        }

        public Node Destination
        {
            get { return this.destination; }
        }
    }
}
