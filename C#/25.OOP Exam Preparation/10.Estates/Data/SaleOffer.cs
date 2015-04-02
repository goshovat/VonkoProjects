using Estates.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estates.Data
{
    public class SaleOffer : Offer, ISaleOffer
    {
        public decimal Price { get; set; }

        public SaleOffer()
            :base(OfferType.Sale)
        {

        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());
            result.AppendFormat(", Price = {0}", this.Price);

            return result.ToString();
        }
    }
}
