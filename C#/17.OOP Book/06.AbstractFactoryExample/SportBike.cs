using System;
using System.Collections.Generic;

namespace AbstractFactoryExample
{
    public class SportBike : Bike
    {
        private string type;
        private string make;

        public SportBike(string type, string make)
        {
            this.type = type;
            this.make = make;
        }

        public string GetType()
        {
            return this.type;
        }

        public string GetMake()
        {
            return this.make;
        }
    }
}
