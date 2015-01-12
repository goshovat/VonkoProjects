namespace DurankulakNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    class DurankulakNumbers
    {
        static Dictionary<char, int> durankulakDigitsValues =
            new Dictionary<char, int>() { { 'A', 0 }, { 'B', 1 }, { 'C', 2 }, { 'D', 3 }, { 'E', 4 }, { 'F', 5 }, { 'G', 6 }, 
            { 'H', 7 }, { 'I', 8 }, { 'J',9 }, {'K', 10}, {'L', 11}, {'M', 12}, {'N', 13}, {'O', 14}, {'P', 15}, {'Q', 16}, 
            {'R', 17} , {'S', 18}, {'T', 19}, {'U', 20}, {'V', 21}, {'W', 22}, {'X', 23}, {'Y', 24}, {'Z', 25}};

        static void Main()
        {
            string durankulakNumber = Console.ReadLine();
            BigInteger decimalValue = 0;

            Stack<string> digits = SplitOnDigits(durankulakNumber);
            int i = 0;
            while (digits.Count > 0)
            {
                string currentDigit = digits.Pop();
                BigInteger currentDigitValue = CalculateDigit(currentDigit, i);
                decimalValue += currentDigitValue;
                i++;
            }
            Console.WriteLine(decimalValue);
        }

        private static Stack<string> SplitOnDigits(string durankulakNumber)
        {
            Stack<string> digitsList = new Stack<string>();
            string currentDigit = "";
            for (int i = 0; i < durankulakNumber.Length; i++)
            {
                currentDigit += durankulakNumber[i];
                if (char.IsUpper(durankulakNumber[i]))
                {
                    digitsList.Push(currentDigit);
                    currentDigit = "";
                }
            }
            return digitsList;
        }
        static BigInteger CalculateDigit(string currentDigit, int digitPosition)
        {
            BigInteger value = 0;
            if (currentDigit.Length == 2)
            {
                value = (durankulakDigitsValues[char.ToUpper(currentDigit[0])] + 1) * 26 +
                    durankulakDigitsValues[char.ToUpper(currentDigit[1])];
            }
            else
            {
                value = durankulakDigitsValues[currentDigit[0]];
            }

            for (int i = 0; i < digitPosition; i++)
            {
                value *= 168;
            }
            return value;
        }
    }
}
