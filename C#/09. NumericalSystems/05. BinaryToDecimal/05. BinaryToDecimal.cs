﻿using System;
using System.Collections.Generic;

class BinaryToDecimal
{
    static void Main()
    {
        int numberInBinary = 100011011;

        double numberInDecimal = ConvertToDecimal(numberInBinary);

        Console.WriteLine("The number in decimal is: {0}", numberInDecimal);
    }

    //this method will convert the number to decimal

    static double ConvertToDecimal(int numberInBinary)
    {
        double result = 0;

        char[] numberInArray = numberInBinary.ToString().ToCharArray();

        Array.Reverse(numberInArray);

        for (int i = 0; i < numberInArray.Length; i++)
        {
            if (numberInArray[i] == '1')
            {
                result += Math.Pow(2.0, (double)i);
            }
        }

        return result;      
    }
}
