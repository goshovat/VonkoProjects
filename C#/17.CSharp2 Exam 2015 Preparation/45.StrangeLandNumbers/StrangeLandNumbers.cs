using System;
using System.Collections.Generic;
using System.Text;

class StrangeLandNumbers
{
    private static ulong SYSTEM_BASE = 7;
    private static Dictionary<string, ulong> strangeDigits = new Dictionary<string, ulong>() 
    { 
        {"f", 0}, {"bIN", 1}, {"oBJEC", 2}, {"mNTRAVL", 3}, {"lPVKNQ", 4}, {"pNWE", 5}, {"hT", 6} 
    };

    static void Main()
    {
        string input = Console.ReadLine();

        List<ulong> digitsParsed = new List<ulong>();
        StringBuilder buffer = new StringBuilder();

        for (int i = 0; i < input.Length; i++)
        {
            buffer.Append(input[i]);

            if (strangeDigits.ContainsKey(buffer.ToString()))
            {
                digitsParsed.Add(strangeDigits[buffer.ToString()]);
                buffer.Clear();
            }
        }

        ulong result = 0;
        ulong power = 1;
        for (int i = 0; i < digitsParsed.Count; i++)
        {
            for (int j = 0; j < digitsParsed.Count - i - 1; j++)
            {
                power *= SYSTEM_BASE;
            }
            result += digitsParsed[i] * power;
            power = 1;
        }

        Console.WriteLine(result);
    }
}
