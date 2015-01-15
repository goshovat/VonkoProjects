using System;

class ExtractThirdBit
{
    static void Main()
    {
        Console.WriteLine("Write the number:");
        int number = int.Parse(Console.ReadLine());

        string numberBinary = Convert.ToString(number, 2).PadLeft(32, '0');
        Console.WriteLine("The number in binary is: {0}", numberBinary);

        int mask = 1;
        mask <<= 3;
        mask &= number;
        mask >>= 3;

        Console.WriteLine("The third bit is: {0}", mask);
    }
}

