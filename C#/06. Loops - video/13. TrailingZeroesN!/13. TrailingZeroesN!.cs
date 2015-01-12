using System;

class TrailingZeroesN_
{
    static void Main()
    {
        Console.WriteLine("Write a positive integer N: ");
        decimal n = 0;

        try
        {
            n = decimal.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Enter a valid number!");
            return;
        }

        int counter = 0;
        int powCounter = 0;

        for (int i = 1; i <= n; i++)
        {
            if (i % 5 == 0)
            {
                int divider = i;
                while (divider % 5 == 0)
                {
                    counter++;
                    divider /= 5;
                }
            }
        }

        Console.WriteLine("The trailing zeroes at the end of N! are: {0}", counter);
    }
}

