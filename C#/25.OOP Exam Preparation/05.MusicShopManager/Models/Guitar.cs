using MusicShopManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShopManager.Models
{
    internal abstract class Guitar : Instrument, IGuitar
    {
        private string bodyWood;
        private string fingerBoardWood;
        private int numberOfStrings;

        public string BodyWood
        {
            get { return this.bodyWood; }
            protected set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The BodyWood is required.");
                }
                this.bodyWood = value;
            }
        }

        public string FingerboardWood
        {
            get { return this.fingerBoardWood; }
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The FingerboardWood is required.");
                }
                this.fingerBoardWood = value;
            }
        }

        public int NumberOfStrings
        {
            get { return this.numberOfStrings; }
            protected set { this.numberOfStrings = value; }
        }

        internal Guitar(string make, string model, decimal price, 
            string color, bool isElectronic, string bodyWood, string fingerBoardWood, int numberOfStrings)
            : base(make, model, price, color, isElectronic)
        {
            this.BodyWood = bodyWood;
            this.FingerboardWood = fingerBoardWood;
            this.NumberOfStrings = numberOfStrings;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());

            result.AppendLine(string.Format("Strings: {0}", this.NumberOfStrings));
            result.AppendLine(string.Format("Body wood: {0}", this.BodyWood));
            result.AppendLine(string.Format("Fingerboard wood: {0}", this.FingerboardWood));

            return result.ToString();
        }
    }
}
