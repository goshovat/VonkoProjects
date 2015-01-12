using System;

class Print1toNnotDividableBy3and7
{
    static void Main()
    {
        Console.Write("Ener a random positive number: ");
        int n = 0;

        try
        {
            n = int.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Enter valid numbers!");
            return;
        }

        for (int i = 1; i <= n; i++)
        {
            if (i % 3 != 0 || i % 7 != 0)
            {
                Console.WriteLine(i);
            }
        }
    }
}
