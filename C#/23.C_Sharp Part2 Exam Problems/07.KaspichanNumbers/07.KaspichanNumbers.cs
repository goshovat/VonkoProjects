namespace KaspichanNumbers
{
    using System;
    using System.Text;
    using System.Numerics;

    class KaspichanNumbers
    {
        public const int KASPICHAN_BASE = 256;

        static char[] kaspichanDigitsValues =
            new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I','J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 
                'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};

        static void Main()
        {
            BigInteger decimalNumber = BigInteger.Parse(Console.ReadLine());
            if (decimalNumber == 0)
            {
                Console.WriteLine(kaspichanDigitsValues[0]);
                return;
            }

            StringBuilder kaspichanNumber = new StringBuilder();
            while (decimalNumber > 0)
            {
                int remainder = (int)(decimalNumber % KASPICHAN_BASE);
                kaspichanNumber.Insert(0, GetKaspichanValue(remainder));
                decimalNumber /= KASPICHAN_BASE;
            }
            Console.WriteLine(kaspichanNumber.ToString());
        }

        private static string GetKaspichanValue(int number)
        {
            int rightPart = number % 26;
            int leftPart = number / 26;
            string result = "";

            if (leftPart > 0)
                result = char.ToLower(kaspichanDigitsValues[leftPart - 1])
                    + "" + kaspichanDigitsValues[rightPart];
            else
                result = kaspichanDigitsValues[rightPart].ToString(); 

            return result;
        }
    }
}
