using System;
using System.Numerics;

class FactorialZeroesAtTheEnd
{
    static void Main()
    {
        Console.WriteLine("Write end to check how many are the 0s at the end of \r\n it's factorial: ");
        uint n = 1;
        BigInteger factorial = 1;
        int counter = 0;

        try 
        {
            n = uint.Parse(Console.ReadLine()); 
        }
        catch (FormatException)
        {
            Console.WriteLine("Please enter a valid number!");
        }

        if (n > 0)
        {
            for (BigInteger i = 1; i <= n; i++)
            {
                factorial *= i;
            }

            Console.WriteLine("The factorial is: {0}", factorial);

            while (true)
            {
                if (factorial % 10 == 0)
                {
                    counter++;
                    factorial /= 10;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine("The number of 0s at the end: {0}", counter);
        }
        else
        {
            Console.WriteLine("Enter a valid number!");
        }
    }
}

