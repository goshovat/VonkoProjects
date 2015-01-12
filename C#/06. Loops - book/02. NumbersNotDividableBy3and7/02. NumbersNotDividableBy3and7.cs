using System;

class NumbersNotDividableBy3and7
{
    static void Main()
    {
        Console.WriteLine("Enter the number n, to check which numbers " + 
                         "from 1 to n are cannot be divided by 3 and 7 at the same time: ");
        int n = 0;

        try
        {
            n = int.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Enter a valid number!");
        }

        if (n > 0)
        {
            int i = 1;

            while (i <= n)
            {
                if (i % 3 != 0 || i % 7 != 0)
                {
                    Console.WriteLine(i);
                }
                i++;
            }
        }
        else
        {
            Console.WriteLine("Enter a valid number!");
        }
    }
}

