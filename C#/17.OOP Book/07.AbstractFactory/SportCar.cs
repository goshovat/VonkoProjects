using System;
using System.Collections.Generic;

namespace AbstractFactory
{
    class SportCar : Car
    {
        private string type;
        private string model;

        public SportCar(string model)
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
