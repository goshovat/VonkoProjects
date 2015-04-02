using Estates.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estates.Engine
{
    class ExtendedEstateEngine : EstateEngine
    {
        public override string ExecuteCommand(string cmdName, string[] cmdArgs)
        {
            switch (cmdName)
            {
                case "find-rents-by-location":
                    return this.ExecuteFindRentsByLocationCommand(cmdArgs[0]);
                case "find-rents-by-price":
                    return this.FindRentsByPrice(decimal.Parse(cmdArgs[0]), decimal.Parse(cmdArgs[1]));
                default:
                    return base.ExecuteCommand(cmdName, cmdArgs);
            }
        }

        private string ExecuteFindRentsByLocationCommand(string location)
        {
            var offers = this.Offers
                .Where(o => o.Estate.Location == location && o.Type == OfferType.Rent)
                .OrderBy(o => o.Estate.Name);

            return FormatQueryResults(offers);
        }

        private string FindRentsByPrice(decimal minPrice, decimal maxPrice)
        {
            List<IRentOffer> rentOffers = new List<IRentOffer>();

            foreach (var offer in this.Offers)
            {
                IRentOffer offerAsRent = offer as IRentOffer;
                if (offerAsRent != null)
                {
                    rentOffers.Add(offerAsRent);
                }
            }

            var sortedOffers = rentOffers.Where(o => o.PricePerMonth >= minPrice && o.PricePerMonth <= maxPrice)
                .OrderBy(o => o.PricePerMonth).ThenBy(o => o.Estate.Name);

            return FormatQueryResults(sortedOffers);
        }
    }
}
