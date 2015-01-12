using System;

class EvenOrOdd
{
    static void Main()
    {
        string input = Console.ReadLine();
        int number = Convert.ToInt32(input);
        if (number % 2 == 0)
        {
            Console.WriteLine("The number is even");
        }
        else
        {
            Console.WriteLine("The number is odd");
        }
    }
}
