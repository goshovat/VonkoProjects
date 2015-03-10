using System;
using System.Collections.Generic;

class NineGagNumbers
{
    private static Dictionary<string, int> nineGagDigits = new Dictionary<string, int>() 
    { 
        {"-!", 0}, {"**", 1}, {"!!!", 2}, {"&&", 3}, {"&-", 4}, {"!-", 5}, {"*!!!", 6}, {"&*!", 7}, {"!!**!-", 8}
    };

    private const int SYSTEM_BASE = 9;

    static void Main()
    {
        string input = Console.ReadLine();
        List<int> nineGagNumbers = new List<int>();

        string currentNumber = "";
        for (int i = 0; i < input.Length; i++)
        {
            currentNumber += input[i];

            if (nineGagDigits.ContainsKey(currentNumber))
            {
                nineGagNumbers.Add(nineGagDigits[currentNumber]);
                currentNumber = "";
            }
        }

        ulong decimalNumber = 0;

        for (int i = 0; i < nineGagNumbers.Count; i++) 
        {
            ulong power = 1;
            for (int j = 0; j < nineGagNumbers.Count - 1 - i; j++)
            {
                power *= SYSTEM_BASE;
            }
            decimalNumber += power * (ulong)nineGagNumbers[i];
        }

        Console.WriteLine(decimalNumber);
    }
}
