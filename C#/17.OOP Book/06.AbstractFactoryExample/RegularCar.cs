using System;

namespace AbstractFactoryExample
{
    public class RegularCar : Car
    {
        public string type;
        public string make;

        public RegularCar(string type, string make)
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
