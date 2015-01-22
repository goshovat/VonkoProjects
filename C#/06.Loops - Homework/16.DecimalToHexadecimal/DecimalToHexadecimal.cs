using System;
using System.Collections.Generic;

class DecimalToHexadecimal
{
    private static Dictionary<int, char> hexDigits = new Dictionary<int, char>() {
        {0, '0'}, {1, '1'}, {2, '2'}, {3, '3'}, {4, '4'}, {5, '5'}, {6, '6'}, {7, '7'}, {8, '8'},
        { 9, '9'}, {10, 'A'}, {11, 'B'}, {12, 'C'}, {13, 'D'}, {14, 'E'}, {15, 'F'}
    };
    private const long SYSTEM_BASE = 16;

    static void Main()
    {
        Console.WriteLine("Enter a decimal number:");
        long decimalNumber = long.Parse(Console.ReadLine());
        Stack<char> hexNumber = new Stack<char>();

        while (decimalNumber > 0)
        {
            long currentDigit = decimalNumber % SYSTEM_BASE;
            decimalNumber /= SYSTEM_BASE;
            hexNumber.Push(hexDigits[(int)currentDigit]);
        }

        foreach (char digit in hexNumber)
        {
            Console.Write(digit);
        }
        Console.WriteLine();
    }
}

