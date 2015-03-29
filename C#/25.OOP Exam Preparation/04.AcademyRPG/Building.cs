using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public abstract class Building : WorldObject
    {
        public Building(Point position, int owner)
            : base(position, owner)
        {
        }
    }
}
