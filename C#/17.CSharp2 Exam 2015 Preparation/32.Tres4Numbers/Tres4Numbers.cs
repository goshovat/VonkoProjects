using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

class Tres4Numbers
{
    private static string[] tresNumbers = new string[] {"LON+", "VK-", "*ACAD", "^MIM", "ERIK|",
            "SEY&", "EMY>>", "/TEL", "<<DON" };

    private const ulong SYSTEM_BASE = 9;

    static void Main()
    {
        BigInteger input = BigInteger.Parse(Console.ReadLine());
        StringBuilder result = new StringBuilder();

        if (input == 0)
            result.Append(tresNumbers[0]);

        while (input > 0)
        {
            BigInteger remainder = input % (BigInteger)SYSTEM_BASE;
            result.Insert(0, tresNumbers[(int)remainder]);
            input /= (BigInteger)SYSTEM_BASE;
        }

        Console.WriteLine(result.ToString().Trim());
    }
}
