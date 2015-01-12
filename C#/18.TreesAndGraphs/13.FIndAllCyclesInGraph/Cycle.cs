using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FindAllCyclesInGraph
{
    public sealed class Cycle
    {
        public readonly ReadOnlyCollection<Edge> Members;
        private List<Edge> members;
        private bool IsComplete;

        internal void Build(Edge member)
        {
            if (!IsComplete)
            {
                if (member == members[0])
                    IsComplete = true;
                else
                    this.members.Add(member);
            }
        }

        internal Cycle(Edge firstMember)
        {
            this.members = new List<Edge>();
            this.members.Add(firstMember);
            this.Members = new ReadOnlyCollection<Edge>(this.members);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            foreach (var member in this.members)
            {
                result.Append(member.Index.ToString());
                if (member != members[members.Count - 1])
                    result.Append(", ");
            }

            return result.ToString();
        }
    }
}
