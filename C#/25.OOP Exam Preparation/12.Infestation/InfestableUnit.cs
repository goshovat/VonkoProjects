using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infestation
{
    public class InfestableUnit : Unit
    {
        public InfestableUnit(string id, UnitClassification unitType, int health, int power, int aggression)
            : base(id, unitType, health, power, aggression)
        {
            
        }

        public override Interaction DecideInteraction(IEnumerable<UnitInfo> units)
        {
            UnitInfo optimalTarget = GetOptimalInfestableUnit(units);

            if (optimalTarget.Id != null)
            {
                return new Interaction(new UnitInfo(this), optimalTarget, InteractionType.Infest);
            }

            return Interaction.PassiveInteraction;
        }

        protected virtual UnitInfo GetOptimalInfestableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            //this method finds the best target to infest
            UnitInfo optimalInfestableUnit = new UnitInfo(null, UnitClassification.Unknown, int.MaxValue, 0, 0);

            foreach (var unit in attackableUnits)
            {
                if (unit.Health < optimalInfestableUnit.Health && unit.Id != this.Id)
                {
                    optimalInfestableUnit = unit;
                }
            }

            return optimalInfestableUnit;
        }
    }
}
