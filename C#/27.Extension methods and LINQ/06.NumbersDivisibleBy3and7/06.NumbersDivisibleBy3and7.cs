namespace NumbersDivisibleBy3and7
{
    using System;
    using System.Linq;

    class NumbersDivisibleBy3and7
    {
        static void Main()
        {
            int[] numbers = new int[] { 1, 3, 21, 7, 14, 9, 8, 15, 42, 99, 100 };

            //using extension methods and lambda expression
            var numbersDivisible = numbers
                                    .Where(n => (n % 3 == 0 && n % 7 == 0))
                                    .Select(n => n);

            foreach(int number in numbersDivisible)
                Console.WriteLine(number);

            Console.WriteLine();
            //using LINQ query
            var numbersDivisible1 = from number in numbers
                                    where (number % 3 == 0 && number % 7 == 0)
                                    select number;

            foreach (int number in numbersDivisible1)
                Console.WriteLine(number);
        }
    }
}
