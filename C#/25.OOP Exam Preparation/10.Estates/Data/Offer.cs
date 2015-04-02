using Estates.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estates.Data
{
    public abstract class Offer : IOffer
    {
        public OfferType Type { get; set; }

        public IEstate Estate { get; set; }

        public Offer(OfferType type)
        {
            this.Type = type;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("{0}: ", this.Type);
            result.AppendFormat("Estate = {0}, ", this.Estate.Name);
            result.AppendFormat("Location = {0}", this.Estate.Location);

            return result.ToString();
        }
    }
}
