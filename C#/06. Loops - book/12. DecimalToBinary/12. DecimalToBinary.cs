using System;

class DecimalToBinary
{
    static void Main()
    {
        Console.Write("Enter a number in a decimal numeric system: ");
        int dec = 0;
        int lastDigit = 0;
        string result = "";

        try
        {
            dec = int.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Enter valid number!");
        }

        if (dec > 0)
        {
            while (dec > 0)
            {
                lastDigit = dec % 2;
                result = lastDigit + " " + result;
                dec /= 2;
            }

            Console.WriteLine(result);
        }
        else
        {
            Console.WriteLine("Enter a valid number!");
        }
    }
}

