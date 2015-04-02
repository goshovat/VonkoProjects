using Estates.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estates.Data
{
    public class Apartment : BuildingEstate, IApartment
    {
        public Apartment()
            :base(EstateType.Apartment)
        {

        }
    }
}
