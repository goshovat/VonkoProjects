using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTunesShop
{
    public class Band :Performer, IBand
    {
        private IList<string> members;

        public IList<string> Members
        {
            get { return new List<string>(this.members); }
            private set
            {
                this.members = value;
            }
        }

        public override PerformerType Type
        {
            get
            {
                return PerformerType.Band;
            }
        }

        public Band(string name)
            : base(name)
        {
            this.members = new List<string>();
        }

        public void AddMember(string memberName)
        {
            this.members.Add(memberName);
        }
    }
}
