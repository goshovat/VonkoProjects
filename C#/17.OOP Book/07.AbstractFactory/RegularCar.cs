using System;
using System.Collections.Generic;

namespace AbstractFactory
{
    class RegularCar  : Car
    {
        private string type;
        private string model;

        public RegularCar(string model)
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
