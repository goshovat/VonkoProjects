namespace FarmersCreed.Units
{
    using System;
    using FarmersCreed.Interfaces;
    using System.Text;

    public class Food : Product, IEdible
    {
        private FoodType foodType;
        private int healthEffect;

        public Food(string id, ProductType productType, FoodType foodType, int quantity, int healthEffect)
            : base(id, productType, quantity)
        {
            this.HealthEffect = healthEffect;
            this.FoodType = foodType;
        }

        public FoodType FoodType
        {
            get { return this.foodType; }
            set { this.foodType = value;  }
        }

        public int HealthEffect
        {
            get { return this.healthEffect; }
            set { this.healthEffect = value; }
        }

          public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(base.ToString());
            result.AppendFormat(", Food Type: {2}, Health Effect: {3}",
                this.Quantity, this.ProductType, this.FoodType, this.HealthEffect);
            return result.ToString();
        }
    }
}
