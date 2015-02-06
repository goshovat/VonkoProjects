using System;
using System.Collections.Generic;

class HexadecimalToBinary
{
    static void Main()
    {
        string numberInHex = "FFE6";
        string result = string.Join("", ConvertHexToBin(numberInHex));

        Console.WriteLine("The number in binary is: {0}", result);
    }

    static List<string> ConvertHexToBin(string numberInHex)
    {
        List<string> result = new List<string>();
        char[] hexSymbols = { 'A', 'B', 'C', 'D', 'E', 'F' };
        int temp = 0;

        for (int i = 0; i < numberInHex.Length; i++)
        {
            char currentSymbol = numberInHex[i];

            if (!int.TryParse(currentSymbol.ToString(), out temp))
            {
                temp = Array.IndexOf(hexSymbols, currentSymbol) + 10;
            }
            result.Add(Convert.ToString(temp, 2).PadLeft(4, '0'));
        }
        return result;
    }
}
