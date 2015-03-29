using MusicShopManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShopManager.Models
{
    internal abstract class Article :IArticle
    {
        private string make;
        private string model;
        private decimal price;

        public string Make
        {
            get { return this.make; }
            protected set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The Make is required.");
                }
                this.make = value;
            }
        }

        public string Model
        {
            get { return this.model; }
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The Model is required.");
                }
                this.model = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The Price must be positive.");
                }
                this.price = value;
            }
        }

        internal Article(string make, string model, decimal price)
        {
            this.Make = make;
            this.Model = model;
            this.Price = price;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(string.Format("= {0} {1} =", this.Make, this.Model));
            result.AppendLine(string.Format("Price: ${0:F2}", this.Price));

            return result.ToString();
        }
    }
}
