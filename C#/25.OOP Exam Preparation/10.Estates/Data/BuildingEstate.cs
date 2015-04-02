using Estates.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estates.Data
{
    public abstract class BuildingEstate : Estate, IBuildingEstate
    {
        public int Rooms { get; set; }

        public bool HasElevator { get; set; }

        public BuildingEstate(EstateType type)
            :base(type)
        {

        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());
            result.AppendFormat(", Rooms: {0},", this.Rooms);
            result.AppendFormat(" Elevator: {0}", this.HasElevator ? "Yes" : "No");

            return result.ToString();
        }
    }
}
