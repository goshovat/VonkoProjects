using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmersCreed.Units
{
    public class CherryTree : FoodPlant
    {
        public CherryTree(string id)
            : base(id, 14, 1, 3)
        {

        }

        public override Product GetProduct()
        {
            if (this.IsAlive)
            {
                return new Food(this.Id + "Product", ProductType.Cherry, FoodType.Organic, 4, 2);
            }
            else
            {
                throw new ApplicationException("The CherryTree cannot produce.");
            }
        }
    }
}
