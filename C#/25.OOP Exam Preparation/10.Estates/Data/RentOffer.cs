using Estates.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estates.Data
{
    public class RentOffer : Offer, IRentOffer
    {
        public decimal PricePerMonth { get; set; }

        public RentOffer()
            : base(OfferType.Rent)
        {
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());
            result.AppendFormat(", Price = {0}", this.PricePerMonth);

            return result.ToString();
        }
    }
}
