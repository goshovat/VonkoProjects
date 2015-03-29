using MusicShopManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShopManager.Models
{
    internal abstract class Instrument : Article, IInstrument
    {
        private string color;
        private bool isElectronic;

        public string Color
        {
            get { return this.color; }
            protected set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The Color is required.");
                }
                this.color = value;
            }
        }

        public bool IsElectronic
        {
            get { return this.isElectronic; }
            protected set { this.isElectronic = value; }
        }

        internal Instrument(string make, string model, decimal price, string color, bool isElectronic)
            : base(make, model, price)
        {
            this.Color = color;
            this.IsElectronic = isElectronic;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());

            result.AppendLine(string.Format("Color: {0}", this.Color));
            result.AppendLine(string.Format("Electronic: {0}", this.IsElectronic ? "yes" : "no"));

            return result.ToString();
        }
    }
}
