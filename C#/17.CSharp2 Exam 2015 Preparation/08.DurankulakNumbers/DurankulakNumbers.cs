using System;
using System.Collections.Generic;
using System.Numerics;

class DurankulakNumbers
{
    private const int SYSTEM_BASE = 168;

    private static Dictionary<char, int> durankulakDigitsValues =
            new Dictionary<char, int>() { { 'A', 0 }, { 'B', 1 }, { 'C', 2 }, { 'D', 3 }, { 'E', 4 }, { 'F', 5 }, { 'G', 6 }, 
            { 'H', 7 }, { 'I', 8 }, { 'J',9 }, {'K', 10}, {'L', 11}, {'M', 12}, {'N', 13}, {'O', 14}, {'P', 15}, {'Q', 16}, 
            {'R', 17} , {'S', 18}, {'T', 19}, {'U', 20}, {'V', 21}, {'W', 22}, {'X', 23}, {'Y', 24}, {'Z', 25}};

    static void Main()
    {
        string durankulakNumber = Console.ReadLine();

        List<int> durankulakNumbers = new List<int>();
        string currentDigit = "";

        for (int i = 0; i < durankulakNumber.Length; i++)
        {
            if (durankulakDigitsValues.ContainsKey(durankulakNumber[i])
                && currentDigit == "")
            {
                durankulakNumbers.Add(
                   durankulakDigitsValues[durankulakNumber[i]]);
            }
            else
            {
                if (currentDigit.Length <= 1)
                {
                    currentDigit += char.ToUpper(durankulakNumber[i]);
                }
                
                if (currentDigit.Length == 2)
                {
                    int value = 26 * (durankulakDigitsValues[currentDigit[0]] + 1)
                        + durankulakDigitsValues[currentDigit[1]];
                    currentDigit = "";

                    durankulakNumbers.Add(value);
                }
            }
        }

        //calculate the durankulak number
        BigInteger decimalNumber = 0;
        for (int i = durankulakNumbers.Count - 1; i >= 0; i--)
        {
            BigInteger currentDurankulakDigit = 
                durankulakNumbers[durankulakNumbers.Count - 1 - i];
            
            BigInteger product = 1;
            for (int power = 0; power < i; power++)
            {
                product *= SYSTEM_BASE;
            }

            decimalNumber += product * currentDurankulakDigit;
        }

        Console.WriteLine(decimalNumber);
    }
}
