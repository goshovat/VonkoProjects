using System;

namespace AbstractFactoryExample
{
    class SportCar : Car
    {
        private string type;
        private string make;

        public SportCar(string type, string make)
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
