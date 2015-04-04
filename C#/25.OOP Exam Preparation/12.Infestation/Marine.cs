using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infestation
{
    public class Marine : Human
    {
        public Marine(string id)
            : base(id)
        {
            this.AddSupplement(new WeaponrySkill());
        }

        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            var sortedTargets = attackableUnits.Where(a => a.Power <= this.Aggression);

            UnitInfo optimalAttackableUnit = new UnitInfo(null, UnitClassification.Unknown, 0, int.MaxValue, 0);

            if (sortedTargets.Count() > 0)
            {
                optimalAttackableUnit = sortedTargets.First();

                foreach (var unit in attackableUnits)
                {
                    if (unit.Health > optimalAttackableUnit.Health)
                    {
                        optimalAttackableUnit = unit;
                    }
                }
            }

            return optimalAttackableUnit;
        }
    }
}
