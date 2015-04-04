using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infestation
{
    public class Parasite : InfestableUnit
    {
        public Parasite(string id)
            :base(id, UnitClassification.Biological, 1, 1, 1) 
        {

        }
    }
}
