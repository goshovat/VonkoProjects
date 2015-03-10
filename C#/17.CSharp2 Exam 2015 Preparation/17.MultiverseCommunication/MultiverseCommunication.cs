using System;
using System.Collections.Generic;

class MultiverseCommunication
{
    private const int SYSTEM_BASE = 13;
    private static Dictionary<string, ulong> multiDigits
        = new Dictionary<string, ulong>() {{"CHU", 0}, {"TEL", 1}, {"OFT", 2},{"IVA", 3}, {"EMY", 4}, 
        {"VNB",5}, {"POQ", 6}, {"ERI", 7}, {"CAD", 8}, {"K-A", 9}, {"IIA", 10}, {"YLO", 11}, {"PLA", 12}};

    static void Main()
    {
        string input = Console.ReadLine();

        List<ulong> digits = new List<ulong>();
        string currentDigit = "";

        for (int i = 0; i < input.Length; i++)
        {
            currentDigit += input[i];

            if (multiDigits.ContainsKey(currentDigit))
            {
                digits.Add(multiDigits[currentDigit]);
                currentDigit = "";
            }             
        }

        ulong result = 0;
        ulong power = 1;
        for (int i = digits.Count - 1; i >= 0; i--)
        {
            for (int pow = 0; pow < i; pow++)
            {
                power *= SYSTEM_BASE;
            }
            result += power * digits[digits.Count - i - 1];
            power = 1;
        }

        Console.WriteLine(result);
    }
}