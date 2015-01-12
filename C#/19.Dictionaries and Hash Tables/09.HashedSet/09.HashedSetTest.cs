using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashedSet
{
    class HashedSetTest
    {
        static void Main()
        {
            HashedSet<string> carsVonkoLike =
               new HashedSet<string>(new List<string>() { "X5", "X6", "CLS", "CLA" });

            HashedSet<string> carsGoshkoLike =
                new HashedSet<string>(new List<string>() { "X5", "CLA", "Civic", "Accord" });

            HashedSet<string> carsBothLike = new HashedSet<string>();
            carsBothLike.UnionWith(carsVonkoLike);
            carsBothLike.IntersectWith(carsGoshkoLike);

            HashedSet<string> allCarsTheyLike = new HashedSet<string>();
            allCarsTheyLike.UnionWith(carsVonkoLike);
            allCarsTheyLike.UnionWith(carsGoshkoLike);


            Console.WriteLine("Vonko likes: ");
            PrintCars(carsVonkoLike);

            Console.WriteLine("Goshko likes: ");
            PrintCars(carsGoshkoLike);

            Console.WriteLine("Both of them like: ");
            PrintCars(carsBothLike);

            Console.WriteLine("All cars any of them likes: ");
            PrintCars(allCarsTheyLike);

            Console.WriteLine("Goshko is a good friend of Vonko: {0}",
                carsBothLike.Count > 2 ? "Yes" : "No");
        }

        private static void PrintCars(HashedSet<string> cars)
        {
            foreach (string car in cars)
                Console.Write(car + " ");

            Console.WriteLine();
            Console.WriteLine(new string('-', 50));
        }
    }
}
