namespace Zerg
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class Zerg
    {
        private const int SYSTEM_BASE = 15;
        private static Dictionary<string, int> zergDigits = new Dictionary<string,int>() 
        {
          {"Rawr", 0}, {"Rrrr",1}, {"Hsst",2}, {"Ssst",3}, {"Grrr",4}, {"Rarr",5}, {"Mrrr",6}, {"Psst",7}, 
          {"Uaah",8}, {"Uaha",9}, {"Zzzz",10}, {"Bauu",11}, {"Djav",12}, {"Myau",13}, {"Gruh",14} 
        };

        static void Main()
        {
            string encryptedMsg = Console.ReadLine();

            List<int> decimalDigits = ExtractDecimalDigits(encryptedMsg);
            ulong number = GetDecimalNumber(decimalDigits);
            Console.WriteLine(number);
        }

        private static List<int> ExtractDecimalDigits(string encryptedMsg)
        {
            List<int> extractedDigits = new List<int>();
            StringBuilder buffer = new StringBuilder();

            foreach (char symbol in encryptedMsg)
            {
                buffer.Append(symbol);
                if (zergDigits.ContainsKey(buffer.ToString()))
                {
                    extractedDigits.Add(zergDigits[buffer.ToString()]);
                    buffer.Clear();
                }
            }
            return extractedDigits;
        }

        private static ulong GetDecimalNumber(List<int> decimalDigits)
        {
            ulong result = 0;
            for (int i = decimalDigits.Count - 1; i >= 0; i--)
            {
                ulong positionConst = 1;
                for (int j = 0; j < decimalDigits.Count - 1 - i; j++)
                {
                    positionConst *= SYSTEM_BASE;
                }
                ulong currentDigit = (ulong)decimalDigits[i];
                result += currentDigit * positionConst;
            }
            return result;
        }
    }
}
