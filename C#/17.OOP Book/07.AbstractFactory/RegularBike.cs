using System;
using System.Collections.Generic;

namespace AbstractFactory
{
    class RegularBike : Bike
    {
        private string type;
        private string model;

        public RegularBike( string model)
        {
            this.type = "Regular";
            this.model = model;
        }

        public string GetType()
        {
            return this.type;
        }

        public string GetModel()
        {
            return this.model;
        }
    }
}
