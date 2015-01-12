using System;

class ExtractBitFromPosB
{
    static void Main()
    {
        Console.WriteLine("Write the number i:");
        string inputI = Console.ReadLine();
        int i = Convert.ToInt32(inputI);

        Console.WriteLine("Write the number b:");
        string inputB = Console.ReadLine();
        int b = Convert.ToInt32(inputB);

        string vBinary = Convert.ToString(i, 2).PadLeft(32, '0');
        Console.WriteLine("The number in binary is: {0}", vBinary);

        int mask = 1;
        mask <<= b;
        mask &= i;
        mask >>= b;

        Console.WriteLine("The bit at position {0} of the number {1} is: {2}", b,i, mask);
    }
}

