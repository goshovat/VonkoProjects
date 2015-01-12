using System;
using System.Collections.Generic;
using BinaryHeap;

namespace BiDictionary
{
    class BiDictionaryTest
    {
        static void Main()
        {
            BiDictionary<string, string, Car> carDict =
                new BiDictionary<string, string, Car>();

            carDict["дневна", "за гъзария"] = new Car("BMW", "X6", 160000);
            carDict["спортна", "за путки"] = new Car("Mercedes", "CLS", 15000);

            Console.WriteLine(carDict["дневна"]);
            carDict.Add("дърта", "пернишка", new Car("Golf", "тройка", 3000));
            carDict.Remove("дневна", "за гъзария");
        }
    }
}
