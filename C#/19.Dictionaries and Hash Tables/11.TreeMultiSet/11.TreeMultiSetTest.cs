using System;
using System.Collections.Generic;

namespace TreeMultiSet
{
    class TreeMultiSet
    {
        static void Main()
        {
            StringComparer comparer = new StringComparer();

            TreeMultiSet<string> carsVonkoLike = new TreeMultiSet<string>(
                new string[] { "X5", "x5", "X6", "CLS", "CLK", "CLA" }, comparer);

            carsVonkoLike.Remove("X5");

            for (int i = 0; i < 3; i++ )
                carsVonkoLike.Add("X5");

            carsVonkoLike.Add("CLS");
            carsVonkoLike.RemoveBiggest();
            carsVonkoLike.RemoveBiggest();

            Console.WriteLine("Cars Vonko like: ");
            PrintMembers<string>(carsVonkoLike);

            TreeMultiSet<string> carsGoshkoLike = new TreeMultiSet<string>(
                new string[] { "6 Series", "x5", "x5", "X5", "X5", "X4", "S-klasse" });
            Console.WriteLine("Cars Goshko like: ");
            PrintMembers<string>(carsGoshkoLike);

            TreeMultiSet<string> carsBothLike = new TreeMultiSet<string>();
            carsBothLike.UnionWith(carsVonkoLike);
            carsBothLike.IntersectWith(carsGoshkoLike);

            Console.WriteLine("Cars both of them like: ");
            PrintMembers<string>(carsBothLike);

            TreeMultiSet<string> allCarsTheyLike = new TreeMultiSet<string>();
            allCarsTheyLike.UnionWith(carsVonkoLike);
            allCarsTheyLike.UnionWith(carsGoshkoLike);
            Console.WriteLine("All cars they like: ");
            PrintMembers<string>(allCarsTheyLike);

            for (int i = 0; i < 10; i++)
                allCarsTheyLike.Remove("X5");

            PrintMembers<string>(allCarsTheyLike);

            string[] strArray = new string[9];
            allCarsTheyLike.CopyTo(strArray, 0);

            PrintMembers<string>(strArray);
        }

        private static void PrintMembers<T>(ICollection<T> cars)
        {
            Console.WriteLine( string.Join(", ", cars));

            Console.WriteLine(new string('-', 50));
            Console.WriteLine();
        }
    }
}
