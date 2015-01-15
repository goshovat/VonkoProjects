using System;

class IsThirdDigitSeven
{
    static void Main()
    {
        Console.WriteLine("Write a number of four digits:");
        int number = int.Parse(Console.ReadLine());

        int number2 = number / 100;

        if (number2 % 10 == 7)
        {
            Console.WriteLine(true);
        }
        else
        {
            Console.WriteLine(false);
        }
    }
}

