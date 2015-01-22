using System;
using System.Collections.Generic;
using System.Text;

class DecimalToBinary
{
    private const long SYSTEM_BASE = 2;

    static void Main()
    {
        Console.WriteLine("Enter a decimal number:");
        long decimalNumber = long.Parse(Console.ReadLine());
        Stack<int> binaryNumber = new Stack<int>();

        while (decimalNumber > 0)
        {
            long currentDigit = decimalNumber % SYSTEM_BASE;
            decimalNumber /= SYSTEM_BASE;
            binaryNumber.Push((int)currentDigit);
        }

        foreach (int digit in binaryNumber)
        {
            Console.Write(digit);
        }
        Console.WriteLine();
    }
}
