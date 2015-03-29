using MusicShopManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShopManager.Models
{
    internal class Microphone :Article, IMicrophone
    {
        private bool hasCable;

        public bool HasCable
        {
            get { return this.hasCable; }
            private set { this.hasCable = value; }
        }

        internal Microphone(string make, string model, decimal price, bool hasCable)
            :base(make, model, price)
        {
            this.HasCable = hasCable;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());

            result.AppendLine(string.Format("Cable: {0}", this.HasCable ? "yes" : "no"));

            return result.ToString();
        }
    }
}
