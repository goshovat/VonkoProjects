using System;

class Print1toN
{
    static void Main()
    {
        Console.WriteLine("Enter a random positive number:");
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
            Console.WriteLine(i);
        }
    }
}
