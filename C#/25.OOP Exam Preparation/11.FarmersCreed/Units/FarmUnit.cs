using FarmersCreed.Interfaces;

namespace FarmersCreed.Units
{
    using System;

    public abstract class FarmUnit : GameObject, IProductProduceable 
    {
        private int health;

        public FarmUnit(string id, int health, int productionQuantity)
            : base(id)
        {
            this.Health = health;
            this.ProductionQuantity = productionQuantity;
            this.IsAlive = true;
        }

        public int Health
        {
            get { return this.health; }
            set
            {
                //if (value < 0)
                //{
                //    throw new ArgumentException("Cannot set negative health");
                //}

                this.health = value;

                if (this.health <= 0)
                {
                    this.IsAlive = false;
                }
            }
        }

        public bool IsAlive { get; protected set; }

        public int ProductionQuantity { get; set; }

        public abstract Product GetProduct();
    }
}
