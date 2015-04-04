using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infestation
{
    public class Queen : InfestableUnit
    {
        public Queen(string id)
            : base(id, UnitClassification.Psionic, 30 , 1, 1)
        {

        }

        protected override UnitInfo GetOptimalInfestableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            //this method finds the best target to infest
            UnitInfo optimalInfestableUnit = new UnitInfo(null, UnitClassification.Unknown, 0 , 0, 0);

            foreach (var unit in attackableUnits)
            {
                if (unit.Health > optimalInfestableUnit.Health && unit.Id != this.Id)
                {
                    optimalInfestableUnit = unit;
                }
            }

            return optimalInfestableUnit;
        }
    }
}
