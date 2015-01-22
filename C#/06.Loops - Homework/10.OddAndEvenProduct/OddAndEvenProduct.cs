using System;

class OddAndEvenProduct
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        string[] numbers = input.Split(new char[] { ' ' }, 
            StringSplitOptions.RemoveEmptyEntries);
        int productOdd = 1;
        int productEven = 1;

        for (int i = 1; i <= numbers.Length; i++)
        {
            if (i % 2 == 0)
            {
                productEven *= int.Parse(numbers[i - 1]);
            }
            else
            {
                productOdd *= int.Parse(numbers[i - 1]);
            }
        }

        if (productOdd == productEven)
        {
            Console.WriteLine("product = {0}", productOdd);
            Console.WriteLine("yes");
        }
        else
        {
            Console.WriteLine("odd_product = {0}", productOdd);
            Console.WriteLine("even_product = {0}", productEven);
            Console.WriteLine("no");
        }
    }
}
