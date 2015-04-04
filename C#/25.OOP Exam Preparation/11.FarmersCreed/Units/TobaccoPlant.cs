using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmersCreed.Units
{
    public class TobaccoPlant : Plant
    {
         public TobaccoPlant(string id)
            : base(id, 12, 1, 4)
        {

        }

         public override void Grow()
         {
             if (this.GrowTime > 0)
             {
                 base.Grow();
                 base.Grow();
             }
             else
             {
                 throw new ApplicationException("Cannot grow grown plant");
             }
         }

         public override Product GetProduct()
         {
             if (this.IsAlive && this.HasGrown)
             {
                 return new Product(this.Id+ "Product", ProductType.Tobacco, 10);
             }
             else
             {
                 throw new ApplicationException("The TobaccoPlant cannot produce.");
             }
         }
    }
}
