using System;
using System.Numerics;

class _248
{
    static void Main()
    {
        BigInteger a = int.Parse(Console.ReadLine());
        BigInteger b = int.Parse(Console.ReadLine());
        BigInteger c = int.Parse(Console.ReadLine());
        BigInteger result = 0;

        switch ((int)b)
        {
            case 2:
                result = a % c;
                break;

            case 4:
                result = a + c;
                break;

            case 8:
                result = a * c;
                break;
        }

        BigInteger remainder = result % 4;
        BigInteger divisionResult = result / 4;

        if (remainder == 0)
        {
            Console.WriteLine(divisionResult);
            Console.WriteLine(result);
        }
        else
        {
            Console.WriteLine(remainder);
            Console.WriteLine(result);
        }
    }
}
