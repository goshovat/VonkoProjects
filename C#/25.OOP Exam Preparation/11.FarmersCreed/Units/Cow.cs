using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmersCreed.Units
{
    public class Cow : Animal
    {
        public Cow(string id)
            : base(id, 15, 1)
        {

        }

        public override void Eat(Interfaces.IEdible food, int quantity)
        {
            if (food.FoodType == FoodType.Organic)
            {
                this.Health += (food.HealthEffect * quantity);
            }
            else if (food.FoodType == FoodType.Meat)
            {
                this.Health -= (food.HealthEffect * quantity);
            }
        }

        public override Product GetProduct()
        {
            if (this.IsAlive)
            {
                for (int i = 0; i < 2; i++)
                {
                    this.Health--;
                }
                return new Food(this.Id + "Product", ProductType.Milk, FoodType.Organic, 6, 4);
            }
            else
            {
                throw new ApplicationException("The Cow cannot produce.");
            }
        }
    }
}
