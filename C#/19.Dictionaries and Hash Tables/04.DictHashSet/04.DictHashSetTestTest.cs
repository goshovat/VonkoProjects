using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictHashSet
{
    class DictHashSetTestTest
    {
        static void Main()
        {
            DictHashSet<string> carsVonkoLike =
                new DictHashSet<string>(new List<string>(){"X5", "X6", "CLS", "CLA"});

            DictHashSet<string> carsGoshkoLike =
                new DictHashSet<string>(new List<string>() { "X5", "CLA", "Civic", "Accord" });

            DictHashSet<string> allCarsVGLike = new DictHashSet<string>();
            allCarsVGLike.UnionWith(carsVonkoLike);
            allCarsVGLike.UnionWith(carsGoshkoLike);

            DictHashSet<string> carsBothLike = new DictHashSet<string>();
            carsBothLike.UnionWith(carsVonkoLike);
            carsBothLike.IntersectWith(carsGoshkoLike);

            Console.WriteLine("Vonko likes: ");
            PrintCars(carsVonkoLike);

            Console.WriteLine("Goshko likes: ");
            PrintCars(carsGoshkoLike);

            Console.WriteLine("Both of them like: ");
            PrintCars(carsBothLike);

            Console.WriteLine("All cars any of them likes: ");
            PrintCars(allCarsVGLike);

            Console.WriteLine("Goshko is a good friend of Vonko: {0}",
                carsBothLike.Count > 2 ? "Yes" : "No");
        }

        private static void PrintCars(DictHashSet<string> cars)
        {
            foreach (string car in cars)
                Console.Write(car + " ");

            Console.WriteLine();
            Console.WriteLine(new string('-', 50));
        }
    }
}
