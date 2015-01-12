using System;

namespace AbstractFactory
{
    class Client
    {
        private Car car;
        private Bike bike;

        public Client(VehicleFactory factory, string type)
        {
            this.car = factory.CreateCar(type);
            this.bike = factory.CreateBike(type);
        }

        public string CarInfo
        {
            get { return this.car.GetType() + " car " + this.car.GetModel(); }
        }

        public string BikeInfo
        {
            get { return this.bike.GetType() + " bike " + this.bike.GetModel(); }
        }
    }
}
