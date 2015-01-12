using System;

namespace AbstractFactoryExample
{
    class Client
    {
        private Bike bike;
        private Car car;

        public Client(VehicleFactory factory, string type)
        {
            this.bike = factory.CreateBike(type);
            this.car = factory.CreateCar(type);
        }

        public string BikeInfo
        {
            get { return this.bike.GetType() + " bike " + this.bike.GetMake(); }
        }

        public string CarInfo
        {
            get { return this.car.GetType() + " car " + this.car.GetMake(); }
        }
    }
}
