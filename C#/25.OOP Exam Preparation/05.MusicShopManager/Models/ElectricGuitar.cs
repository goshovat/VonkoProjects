using MusicShopManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShopManager.Models
{
    internal class ElectricGuitar : Guitar, IElectricGuitar
    {
        private int adapters;
        private int frets;

        public int NumberOfAdapters
        {
            get { return this.adapters; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The NumberOfAdapters must be non-negative.");
                }
                this.adapters = value;
            }
        }

        public int NumberOfFrets
        {
            get { return this.frets; }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The NumberOfFrets must be positive.");
                }
                this.frets = value;
            }
        }

        internal ElectricGuitar(string make, string model, decimal price, string color,
            string body, string fingerboard, int adapters, int frets)
            : base(make, model, price, color, true, body, fingerboard, 6)
        {
            this.NumberOfAdapters = adapters;
            this.NumberOfFrets = frets;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());

            result.AppendLine(string.Format("Adapters: {0}", this.NumberOfAdapters));
            result.AppendLine(string.Format("Frets: {0}", this.NumberOfFrets));

            return result.ToString();
        }
    }
}
