using System;

class DivideByFiveAndSeven
{
    static void Main()
    {
        Console.WriteLine("Write the number:");
        int number = int.Parse(Console.ReadLine());

        if ((number % 5 == 0) && (number % 7 == 0) && number != 0)
        {
            Console.WriteLine(true);
        }
        else
        {
            Console.WriteLine(false);
        }
    }
}