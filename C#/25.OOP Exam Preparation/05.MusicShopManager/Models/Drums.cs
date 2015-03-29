using MusicShopManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShopManager.Models
{
    internal class Drums : Instrument, IDrums
    {
        private int width;
        private int height;

        public int Width
        {
            get { return this.width; }
            protected set //make it protected in case one day decide to inherit drums
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The Width must be positive.");
                }
                this.width = value;
            }
        }

        public int Height
        {
            get { return this.height; }
            protected set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The height must be positive.");
                }
                this.height = value;
            }
        }

        internal Drums(string make, string model, decimal price, 
            string color, int width, int height)
            : base(make, model, price, color, false)
        {
            this.Width = width;
            this.Height = height;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());

            result.AppendLine(string.Format("Size: {0}cm x {1}cm", this.Width, this.Height));

            return result.ToString();
        }
    }
}
