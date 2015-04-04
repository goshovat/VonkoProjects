using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmersCreed.Units
{
    public abstract class FoodPlant : Plant
    {
        public FoodPlant(string id, int health, int productionQuantity, int growTime)
            :base(id, health, productionQuantity, growTime)
        {

        }

        public override void Water()
        {
            this.Health++;
        }

        public override void Wither()
        {
            base.Wither();
            base.Wither();
        }

        public override abstract Product GetProduct();
    }
}
