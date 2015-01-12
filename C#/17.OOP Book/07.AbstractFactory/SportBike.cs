using System;
using System.Collections.Generic;

namespace AbstractFactory
{
    class SportBike : Bike
    {
        private string type;
        private string model;

        public SportBike(string model)
        {
            this.type = "Sport";
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
