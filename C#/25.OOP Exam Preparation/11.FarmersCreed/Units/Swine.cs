using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmersCreed.Units
{
    public class Swine : Animal
    {
        public Swine(string id)
            : base(id, 20, 1)
        {

        }

        public override void Eat(Interfaces.IEdible food, int quantity)
        {
            if (food.FoodType == FoodType.Organic || food.FoodType == FoodType.Meat)
            {
                for (int i = 0; i < 2; i++)
                {
                    this.Health += (food.HealthEffect * quantity);
                }
            }
        }

        public override void Starve()
        {
            for (int i = 0; i < 3; i++)
            {
                base.Starve();
            }
        }

        public override Product GetProduct()
        {
            if (this.IsAlive)
            {
                this.Health = 0;
                return new Food(this.Id + "Product", ProductType.PorkMeat, FoodType.Meat, 1, 5);
            }
            else
            {
                throw new ApplicationException("The Swib=ne cannot produce.");
            }
        }
    }
}