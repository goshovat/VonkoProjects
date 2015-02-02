using System;
using System.Numerics;

class PeaceofCake
{
    static void Main()
    {
        BigInteger a = int.Parse(Console.ReadLine());
        BigInteger b = int.Parse(Console.ReadLine());
        BigInteger c = int.Parse(Console.ReadLine());
        BigInteger d = int.Parse(Console.ReadLine());

        a *= d;
        c *= b;

        BigInteger nominator = a + c;
        BigInteger denominator = b * d;

        decimal result = ((decimal)nominator / (decimal)denominator);
        if (result >= 1)
        {
            Console.WriteLine((int)result);
        }
        else
        {
            Console.WriteLine("{0:N22}", result);
        }
        Console.WriteLine("{0}/{1}", nominator, denominator);
    }
}
