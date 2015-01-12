namespace IEnumerableExtensionMethods
{
    using System;
    using System.Collections.Generic;

    class IEnumerableExtensionsMain
    {
        static void Main(string[] args)
        {
            List<double> numbers = new List<double> { 1, 2, 3, 2000 };

            //test the SumAll extension method
            double sum = numbers.SumAll<double>();
            Console.WriteLine("Sum: {0}", sum);

            //test the ProductAll extension method
            double product = numbers.ProductAll<double>();
            Console.WriteLine("Product: {0}", product);

            //test the MinAll extension method
            double minValue = numbers.MinAll<double>();
            Console.WriteLine("Min Value: {0}", minValue);

            //test the MaxAll extension method
            double maxValue = numbers.MaxAll<double>();
            Console.WriteLine("Max Value: {0}", maxValue);

            //test the AverageAll extension method
            double averageValue = numbers.AverageAll<double>();
            Console.WriteLine("Average Value: {0}", averageValue);
        }
    }
}
