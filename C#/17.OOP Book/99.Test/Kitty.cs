using System;
using System.Collections.Generic;

namespace Test
{
    public class Kitty
    {
        private int legs;
        private bool isMale;

        public Kitty()
            :this(4, true)
        {
        }

        public Kitty(int legs, bool isMale)
        {
            this.legs = legs;
            this.isMale = isMale;
        }

        public int Legs 
        {
            get { return this.legs; }
        }

        public bool IsMale
        {
            get { return this.isMale; }
        }
    }
}
