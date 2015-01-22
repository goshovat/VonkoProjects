using System;
using System.Collections.Generic;

class HexadecimalToDecimal
{
    private static Dictionary<char, int> hexDigits = new Dictionary<char,int>() {
        {'0', 0}, {'1', 1}, {'2', 2}, {'3', 3}, {'4', 4}, {'5', 5}, {'6', 6}, {'7', 7}, {'8', 8},
        {'9', 9}, {'A', 10}, {'B', 11}, {'C', 12}, {'D', 13}, {'E', 14}, {'F', 15}
    };
    private const long SYSTEM_BASE = 16;

    static void Main()
    {
        Console.WriteLine("Enter a hexadecimal number:");
        string hexNumber = Console.ReadLine();
        long decNumber = 0;

        for (int i = hexNumber.Length - 1; i >= 0; i--)
        {
            decNumber += (long)
                        Math.Pow(SYSTEM_BASE, (double)(hexNumber.Length - i - 1))
                        * hexDigits[hexNumber[i]];
        }

        Console.WriteLine(decNumber);
    }
}
