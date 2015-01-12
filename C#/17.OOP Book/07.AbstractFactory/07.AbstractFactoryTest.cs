using System;

namespace AbstractFactory
{
    class AbstractFactoryTest
    {
        static void Main()
        {
            BMWFactory kaliningradFactory = new BMWFactory();
            MercedesFactory stutgardFactory = new MercedesFactory();

            Client vonko = new Client(kaliningradFactory, "Sport");
            Console.WriteLine("The purchases of Vonko client are: ");
            Console.WriteLine(vonko.CarInfo);
            Console.WriteLine(vonko.BikeInfo);
        }
    }
}
