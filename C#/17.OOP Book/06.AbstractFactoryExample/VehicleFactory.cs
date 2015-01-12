using System;

namespace AbstractFactoryExample
{
    public interface VehicleFactory
    {
        Bike CreateBike(string type);
        Car CreateCar(string type);
    }
}
