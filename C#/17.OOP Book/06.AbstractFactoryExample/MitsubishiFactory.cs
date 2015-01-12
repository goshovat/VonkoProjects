using System;

namespace AbstractFactoryExample
{
    class MitsubishiFactory : VehicleFactory
    {
        public Bike CreateBike(string type)
        {
            switch (type)
            {
                case "Sport":
                    return new SportBike("Sport", "Mitsubishi");

                case "Regular":
                    return new RegularBike("Regular", "Mitsubishi");

                default:
                    throw new ApplicationException(string.Format("Error! Factory {0} cannot produce a bike of type '{1}'.",
                        "Mitsubishi", type));
            }
        }

        public Car CreateCar(string type)
        {
            switch (type)
            {
                case "Sport":
                    return new SportCar("Sport", "Mitsubishi");

                case "Regular":
                    return new RegularCar("Regular", "Mitsubishi");

                default:
                    throw new ApplicationException(string.Format("Error! Factory {0} cannot produce a car of type '{1}'.",
                        "Mitsubishi", type));
            }
        }
    }
}
