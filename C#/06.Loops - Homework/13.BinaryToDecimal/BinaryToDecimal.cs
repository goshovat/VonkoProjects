
using System;

class BinaryToDecimal
{
    private const double SYSTEM_BASE = 2;

    static void Main()
    {
        Console.WriteLine("Enter the binary number as a string:");
        string binary = Console.ReadLine();
        long decimalNumber = 0;


        for (int i = binary.Length - 1; i >= 0; i--)
        {
            char currentChar = binary[i];

            if (currentChar != '0' && currentChar != '1')
                throw new ArgumentException("Invalid binary string.");

            if (currentChar == '1')
            {
                decimalNumber += (long)
                    Math.Pow(SYSTEM_BASE, (double)(binary.Length - i - 1));
            }
        }

        Console.WriteLine("The decimal representation is:");
        Console.WriteLine(decimalNumber);
    }
}
