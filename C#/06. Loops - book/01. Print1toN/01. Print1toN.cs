using System;

class Print1toN
{
    static void Main()
    {
        Console.Write("Enter the number n: ");
        int n = 0;

        try
        {
            n = int.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Enter a valid number!");
        }

        Console.WriteLine();

        if (n > 0)
        {
            int i = 1;

            while (i <= n)
            {
                Console.WriteLine(i);
                i++;
            }
        }
        else
        {
            Console.WriteLine("Enter a valid number!");
        }
    }
}

