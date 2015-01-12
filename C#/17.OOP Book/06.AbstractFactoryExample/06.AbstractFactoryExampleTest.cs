using System;
using System.Collections.Generic;

namespace AbstractFactoryExample
{
    class AbstractFactoryExampleTest
    {
        static void Main()
        {
            try
            {
                VehicleFactory hondaFactory = new HondaFactory();
                Client hondaClient = new Client(hondaFactory, "Sport");

                Console.WriteLine("The products bought by the honda client: ");
                Console.WriteLine(hondaClient.BikeInfo);
                Console.WriteLine(hondaClient.CarInfo);
                Console.WriteLine();

                VehicleFactory mitsubishiFactory = new MitsubishiFactory();
                Client mitsubishiClient = new Client(mitsubishiFactory, "Regular");

                Console.WriteLine("The products bought by the mitsubishi client: ");
                Console.WriteLine(mitsubishiClient.BikeInfo);
                Console.WriteLine(mitsubishiClient.CarInfo);
            }
            catch (ApplicationException applExc)
            {
                Console.WriteLine(applExc.Message);
            }
        }
    }
}
