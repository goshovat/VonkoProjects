using System;
using System.Numerics;
using System.Text;

class KaspichanNumbers
{
    private static char [] kaspichanDigits =
        new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I','J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 
                'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};
    private const int SYSTEM_BASE = 256;

    static void Main()
    {
        string input = Console.ReadLine();
        BigInteger decimalNumber = BigInteger.Parse(input);

        StringBuilder result = new StringBuilder();
        string currentKaspNumber = string.Empty;

        if (decimalNumber == 0)
        {
            Console.WriteLine("A");
            return;
        }

        while (decimalNumber > 0)
        {
            int remainder = (int)(decimalNumber % SYSTEM_BASE);

            char seniorComponent = default(char);
            if (remainder > 25)
            {
                seniorComponent = char.ToLower(kaspichanDigits[remainder / 26 - 1]);
            }

            char juniorComponent = kaspichanDigits[remainder % 26];

            if (remainder > 25)
                currentKaspNumber = seniorComponent.ToString() + juniorComponent;
            else 
                currentKaspNumber = juniorComponent.ToString();

            result.Insert(0, currentKaspNumber);
            decimalNumber /= SYSTEM_BASE;
        }

        Console.WriteLine(result.ToString());
    }
}
