using System;
using System.Numerics;

class _369
{
    static void Main()
    {
        long a = long.Parse(Console.ReadLine());
        long b = long.Parse(Console.ReadLine());
        long c = long.Parse(Console.ReadLine());
        long result = 0;

        switch ((long)b)
        {
            case 3:
                result = a + c;
                break;
            case 6:
                result = a * c;
                break;
            case 9:
                result = (int)a % (int)c;
                break;
        }

        decimal finalResult = 0;
        if (result % 3 == 0)
        {
            finalResult = (long)result / 3;
        }
        else
        {
            finalResult = (long)result % 3;
        }

        Console.WriteLine(finalResult);
        Console.WriteLine(result);
    }
}
