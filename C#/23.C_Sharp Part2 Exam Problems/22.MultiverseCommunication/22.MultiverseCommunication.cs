namespace MultiverseCommunication
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class MultiverseCommunication
    {
        private const ulong SYSTEM_BASE = 13;
        private static Dictionary<string, int> encriptedDigits = new Dictionary<string, int>()
        {
            {"CHU", 0}, {"TEL", 1}, {"OFT", 2}, {"IVA", 3}, {"EMY", 4}, {"VNB", 5}, {"POQ", 6}, {"ERI", 7},
            {"CAD", 8}, {"K-A", 9}, {"IIA", 10}, {"YLO", 11}, {"PLA", 12}
        };
        private static List<int> digitsFound = new List<int>();
        private static StringBuilder buffer = new StringBuilder();

        static void Main()
        {
            string input = Console.ReadLine();

            ExtractDigits(input);
            ulong answer = ConvertToDecimal();

            Console.WriteLine(answer);
        }

        private static void ExtractDigits(string input)
        {
            foreach(char symbol in input)
            {
                buffer.Append(symbol);
                string suspectedDigit = buffer.ToString();

                if (encriptedDigits.ContainsKey(suspectedDigit))
                {
                    digitsFound.Add(encriptedDigits[suspectedDigit]);
                    buffer.Clear();
                }
            }
        }

        private static ulong ConvertToDecimal()
        {
            ulong result = 0;
            for (int i = 0; i < digitsFound.Count; i++)
            {
                int position = digitsFound.Count - 1 - i;
                ulong positionConst = 1;
                for (int j = 0; j < digitsFound.Count - 1 - i; j++) 
                {
                    positionConst *= SYSTEM_BASE;
                }
                result += positionConst * (ulong)digitsFound[i];
            }
            return result;
        }
    }
}
