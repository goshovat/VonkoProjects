using Estates.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estates.Data
{
    public class Office : BuildingEstate, IOffice
    {
        public Office()
            : base(EstateType.Office)
        {

        }
    }
}

