namespace FarmersCreed.Units
{
    using System;
    using System.Text;

    public abstract class Plant : FarmUnit
    {
        public Plant(string id, int health, int productionQuantity, int growTime)
            : base(id, health, productionQuantity)
        {
            this.GrowTime = growTime;
        }

        public bool HasGrown
        {
            get { return this.GrowTime == 0; }
        }

        public int GrowTime { get; set; }

        public virtual void Water()
        {
            this.Health++;
            this.Health++;
        }

        public virtual void Wither()
        {
            this.Health--;
        }

        public virtual void Grow()
        {
            if (this.GrowTime > 0)
            {
                this.GrowTime--;
            }
            else
            {
                throw new ApplicationException("Cannot grow grown plant");
            }
        }

        public override abstract Product GetProduct();

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(base.ToString());

            if (this.Health <= 0)
            {
                result.AppendFormat(", DEAD");
            }
            else
            {
                result.AppendFormat(", Health: {0}, ", this.Health);
                if (this.GrowTime > 0)
                {
                    result.AppendFormat("Grown: {0}", "No");
                }
                else
                {
                    result.AppendFormat("Grown: {0}", "Yes");
                }
            }

            return result.ToString();
        }
    }
}
