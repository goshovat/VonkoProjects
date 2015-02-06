using System;
using System.Collections.Generic;

class DecimalToHexadecimal
{
    static void Main()
    {
        Console.WriteLine("Enter a decimal number to see it's hex representation: ");
        int number = int.Parse(Console.ReadLine());
        string result = string.Join("", ConvertToHex(number));

        Console.WriteLine("The number in hex is: {0}", result);
    }

    static List<string> ConvertToHex(int number)
    {
        string[] hexSymbols = { "A", "B", "C", "D", "E", "F" };

        List<string> hexList = new List<string>();
        string currentSymbol = null;

        while (number != 0)
        {
            int currentNumber = number % 16;

            if (currentNumber < 10)
            {
                currentSymbol = currentNumber.ToString();
            }
            else
            {
                currentSymbol = hexSymbols[currentNumber - 10];
            }

            hexList.Insert(0, currentSymbol);
            number /= 16;
        }
        return hexList;
    }
}

