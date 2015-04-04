namespace FarmersCreed.Units
{
    using System;
    using FarmersCreed.Interfaces;
    using System.Text;

    public abstract class Animal : FarmUnit
    {
        public Animal(string id, int health, int productionQuantity)
            : base(id, health, productionQuantity)
        {
        }

        public abstract void Eat(IEdible food, int quantity);

        public abstract override Product GetProduct();

        public virtual void Starve()
        {
            this.Health--;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(base.ToString());

            if (this.IsAlive) 
            {
                result.AppendFormat(", Health: {0}", this.Health.ToString());
            }
            else 
            {
                result.Append(", DEAD");
            }

            return result.ToString();
        }
    }
}
