using System;

namespace AbstractFactoryExample
{
    class RegularBike : Bike
    {
        private string type;
        private string make;

        public RegularBike(string type, string make)
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
