using System;
using System.Numerics;

class BinaryToDec
{
    static void Main()
    {
        Console.Write("Enter a number in a binary numeric system: ");
        BigInteger binary = 1;

        try
        {
            binary = int.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Please enter valid number!");
        }

        if (binary > 0)
        {
            BigInteger lastDigit = 0;
            int powerCounter = 0;
            BigInteger result = 0;

            while (binary > 0)
            {
                lastDigit = binary % 10;
                result = lastDigit * (BigInteger)Math.Pow(2, powerCounter) + result;
                binary /= 10;
                powerCounter++;
            }

            Console.WriteLine("The number in decimal: {0}", result);
        }
        else
        {
            Console.WriteLine("Enter a valid number!");
        }
    }
}

