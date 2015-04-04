using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infestation
{
    public class Weapon : Supplement
    {
        public Weapon()
            : base(0, 0, 0)
        {

        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            WeaponrySkill skill = otherSupplement as WeaponrySkill;

            if (skill != null)
            {
                base.PowerEffect = 10;
                base.AggressionEffect = 3;
            }
        }
    }
}
