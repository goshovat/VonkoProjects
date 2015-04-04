using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infestation
{
    public class InfestationSpores : Supplement
    {
        public InfestationSpores()
            : base(-1, 0, 20)
        {

        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            InfestationSpores supAsInf = otherSupplement as InfestationSpores;

            if (supAsInf != null)
            {
                this.PowerEffect = 0;
                this.HealthEffect = 0;
                this.AggressionEffect = 0;
            }

            base.ReactTo(otherSupplement);
        }
    }
}
