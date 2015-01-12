using System;
using System.Collections.Generic;

namespace MinPaths_Dijkstra
{
    public class Node : IComparable<Node>
    {
        private int value;
        private int dijkstraDistance;
        private bool isVisited;

        public Node(int value)
        {
            this.value = value;
            this.dijkstraDistance = int.MaxValue;
            this.isVisited = false;
        }

        public int Value
        {
            get { return this.value; }
        }

        public int DijkstraDistance
        {
            get { return this.dijkstraDistance; }
            set { this.dijkstraDistance = value; }
        }

        public bool IsVisited
        {
            get { return this.isVisited; }
            set { this.isVisited = value; }
        }

        public int CompareTo(Node other)
        {
            return this.dijkstraDistance.CompareTo(other.DijkstraDistance);
        }

        public override bool Equals(object obj)
        {
            Node other = (Node)obj;

            if (this.CompareTo(other) == 0)
                return true;
            else
                return false;
        }

        public override int GetHashCode()
        {
            return this.value;
        }

        public override string ToString()
        {
            return this.value.ToString();
        }
    }
}
