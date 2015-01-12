using System;
using System.Collections.Generic;

class HornerMethod
{
    static void Main(string[] args)
    {
        string numberInBinary = "00111010111";

        int result = ConvertToDecimal(numberInBinary);

        Console.WriteLine("The number in decimal is: {0}", result);
    }

    static int ConvertToDecimal(string numberInBinary)
    {
        int result = 0;

        for (int i = 0, len = numberInBinary.Length; i < len; i++)
        {
            result += int.Parse(numberInBinary[i].ToString());

            if (i != len - 1)
                result *= 2;
        }

        return result;
    }
}
