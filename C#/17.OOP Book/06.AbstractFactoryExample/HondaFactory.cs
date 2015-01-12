using System;

namespace AbstractFactoryExample
{
    class HondaFactory : VehicleFactory
    {
        public Bike CreateBike(string type)
        {
            switch (type)
            {
                case "Sport":
                    return new SportBike("Sport", "Honda");

                case "Regular":
                    return new RegularBike("Regular", "Honda");

                default:
                    throw new ApplicationException(string.Format("Error! Factory {0} cannot produce a bike of type '{1}'.",
                        "Honda", type));
            }
        }

        public Car CreateCar(string type)
        {
            switch (type)
            {
                case "Sport":
                    return new SportCar("Sport", "Honda");

                case "Regular":
                    return new RegularCar("Regular", "Honda");

                default:
                    throw new ApplicationException(string.Format("Error! Factory {0} cannot produce a car of type '{1}'.",
                        "Honda", type));
            }
        }
    }
}
