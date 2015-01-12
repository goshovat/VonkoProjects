using System;
using System.Collections.Generic;

namespace AbstractFactory
{
    class BMWFactory : VehicleFactory
    {
        private string brandName = "BMW";

        public string BrandName
        {
            get { return this.brandName; }
        }

        public Car CreateCar(string type)
        {
            switch (type)
            {
                case "Regular":
                    return new RegularCar("BMW X5");

                case "Sport":
                    return new SportCar("BMW 6 M6");

                default:
                    throw new ApplicationException(string.Format("Error!The factory {0} does not produce cars of type '{1}''.",
                        this.brandName, type));
            }
        }

        public Bike CreateBike(string type)
        {
            switch (type)
            {
                case "Regular":
                    return new RegularBike("BMW");

                case "Sport":
                    return new SportBike("BMW");

                default:
                    throw new ApplicationException(string.Format("Error!The factory {0} does not produce bikes of type '{1}''.",
                        this.brandName, type));
            }
        }
    }
}
