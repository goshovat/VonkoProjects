namespace _9GagNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class _9GagNumbers
    {
        static string[] nineGagDigits = new string[] {
            "-!", "**", "!!!", "&&", "&-", "!-", "*!!!", "&*!", "!!**!-"
        };
        public const ulong SYSTEM_BASE = 9;

        static void Main()
        {
            string nineGagString = Console.ReadLine();
            List<byte> digitsFound = new List<byte>();

            StringBuilder builder = new StringBuilder();
            for (int symbols = 0; symbols < nineGagString.Length; symbols++)
            {
                builder.Append(nineGagString[symbols]);

                for (byte digit = 0; digit < nineGagDigits.Length; digit++)
                {
                    if (builder.ToString() == nineGagDigits[digit])
                    {
                        digitsFound.Add(digit);
                        builder.Clear();
                    }
                }
            }

            ulong finalResult = TransformToDecimal(digitsFound);
            Console.WriteLine(finalResult);
        }

        private static ulong TransformToDecimal(List<byte> digitsFound)
        {
            ulong result = 0;
            digitsFound.Reverse();
            for (int i = 0; i < digitsFound.Count; i++)
            {
                ulong digitConst = 1;
                for (int j = 0; j < i; j++)
                    digitConst *= SYSTEM_BASE;

                result += digitsFound[i] * digitConst;
            }
            return result;
        }
    }
}
