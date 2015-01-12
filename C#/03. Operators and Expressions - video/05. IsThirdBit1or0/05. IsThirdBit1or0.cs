using System;

class IsThirdBit1or0
{
    static void Main()
    {
        Console.WriteLine("Write the number:");
        string input = Console.ReadLine();
        int n = Convert.ToInt32(input);

        string nBinary = Convert.ToString(n, 2).PadLeft(32, '0');
        Console.WriteLine("The number in binary is: {0}", nBinary);

        int mask = 1;
        mask <<= 3;
        mask &= n;
        mask >>= 3;

        Console.WriteLine("The third bit is: {0}", mask);
    }
}

