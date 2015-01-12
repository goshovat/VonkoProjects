using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public interface VehicleFactory
    {
        Bike CreateBike(string type);
        Car CreateCar(string type);
    }
}
