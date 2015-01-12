using System;
using System.Collections.Generic;

namespace AbstractFactory
{
    class MercedesFactory : VehicleFactory
    {
        private string brandName = "Mercedes";

        public string BrandName
        {
            get { return this.brandName; }
        }

        public Car CreateCar(string type)
        {
            switch (type)
            {
                case "Regular":
                    return new RegularCar("Mercedes ML");

                case "Sport":
                    return new SportCar("Mercedes CLS AMG");

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
                    return new RegularBike("Mercedes");

                case "Sport":
                    return new SportBike( "Mercedes");

                default:
                    throw new ApplicationException(string.Format("Error!The factory {0} does not produce bikes of type '{1}''.",
                        this.brandName, type));
            }
        }
    }
}
