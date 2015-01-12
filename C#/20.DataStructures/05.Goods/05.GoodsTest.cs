using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

namespace Goods
{
    class GoodsTest
    {
        static void Main()
        {
            Commodity good1 = new Commodity("Cheese", "Elena", 8.7);
            Commodity good2 = new Commodity("Yellow Cheese", "Balkan", 14.7);
            Commodity good3 = new Commodity("Salam", "Prilep", 5.3);
            Commodity good4 = new Commodity("Lukanka", "Smqrovska", 10);
            Commodity good5 = new Commodity("Tomatoes", "Izvor", 3.4);

            OrderedSet<Commodity> commodities = new OrderedSet<Commodity>(
                new Commodity[] { good1, good2, good3, good4, good5 });

            ICollection<Commodity> selectedGoods = commodities.Range(
                new Commodity("uknown", "unknown", 5), false, new Commodity("unknown", "unknown", 10), true);

            foreach (Commodity good in selectedGoods)
            {
                Console.WriteLine(good);
            }
        }
    }
}
