using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class HomeKitty: Kitty, IReproducible<HomeKitty>
    {
        private int weight;

        public HomeKitty()
            : this(3)
        {
        }

        public HomeKitty(int weight)
            : base()
        {
            this.weight = weight;
        }

        public int Weight
        {
            get { return this.weight; }
        }

        public void Merge() 
        {
        }

        public HomeKitty[] Reproduce(HomeKitty mate)
        {
            return new HomeKitty[] { new HomeKitty(4), new HomeKitty(5) };
        }
    }
}
