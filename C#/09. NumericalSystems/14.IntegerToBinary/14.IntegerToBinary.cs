using System;
using System.Collections.Generic;

class IntegerToBinary
{
    static void Main()
    {
        Console.WriteLine("Enter a positive integer: ");

        uint integer = uint.Parse(Console.ReadLine());

        string result = string.Join("", ConvertToBinary(integer));

        Console.WriteLine("The integer in binary is: {0}", result);
    }

    static List<uint> ConvertToBinary(uint integer)
    {
        List<uint> result = new List<uint>();

        while (integer != 0)
        {
            uint currentNumber = integer % 2;

            result.Insert(0, currentNumber);

            integer /= 2;
        }

        return result;
    }
}
