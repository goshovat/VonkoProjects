using System;

class IsThirdDigit7
{
    static void Main()
    {
        Console.WriteLine("Write a number of four digits:");
        string input = Console.ReadLine();
        int number = Convert.ToInt32(input);

        int number2 = number / 100;

        if (number2 % 10 == 7)
        {
            Console.WriteLine("The third digit is 7, baby!");
        }
        else
        {
            Console.WriteLine("The third digit is not 7!");
        }
    }
}

