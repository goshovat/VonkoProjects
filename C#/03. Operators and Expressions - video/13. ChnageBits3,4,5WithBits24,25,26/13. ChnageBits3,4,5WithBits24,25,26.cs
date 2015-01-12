using System;

class ChnageBits3_4_5with24_25_26
{
    static void Main()
    {
        Console.WriteLine("Write the number n:");
        string input = Console.ReadLine();
        uint n = Convert.ToUInt32(input);

        string binary = Convert.ToString(n, 2).PadLeft(32, '0');
        Console.WriteLine("The number in binary is: {0}", binary);
        Console.WriteLine();

        uint mask = 7;
        mask <<= 3;
        uint juniorBits = mask & n;
        string juniorBitsStr = Convert.ToString(juniorBits, 2).PadLeft(32, '0');
        Console.WriteLine("The junior bits are: {0}", juniorBitsStr);
        Console.WriteLine();
        //Now I will null the junior bits of the original number
        n &= (~juniorBits);
        juniorBits <<= 21;

        mask <<= 21;
        uint seniorBits = mask & n;
        string seniorBitsStr = Convert.ToString(seniorBits, 2).PadLeft(32, '0');
        Console.WriteLine("The senior bits are: {0}", seniorBitsStr);
        Console.WriteLine();
        //Now I will null the senior Bits
        n &= (~seniorBits);
        seniorBits >>= 21;

        n |= juniorBits;
        n |= seniorBits;

        Console.WriteLine("The new value of n is: {0}", n);
        Console.WriteLine();
        string binary2 = Convert.ToString(n, 2).PadLeft(32, '0');
        Console.WriteLine("The new value of n in binary is: {0}", binary2);
    }
}

