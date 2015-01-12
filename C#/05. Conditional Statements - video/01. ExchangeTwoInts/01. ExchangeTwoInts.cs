using System;

class ExchangeTwoInts
{
    static void Main()
    {
        Console.WriteLine("Enter two integers: ");
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int biggerNumber = 0;
        Console.WriteLine();

        if (a > b)
        {
            biggerNumber = a;
            a = b;
            b = biggerNumber;
            Console.WriteLine(b);
        }

        Console.WriteLine("The second integer is: {0}" ,b);
    }
}

