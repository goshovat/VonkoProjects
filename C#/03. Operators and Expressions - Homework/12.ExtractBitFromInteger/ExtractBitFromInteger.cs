using System;

class ExtractBitFromInteger
{
    static void Main()
    {
        Console.WriteLine("Write the number i:");
        int number = int.Parse(Console.ReadLine());

        Console.WriteLine("Write the number of index:");
        int index = int.Parse(Console.ReadLine());

        string numberBinary = Convert.ToString(number, 2).PadLeft(32, '0');
        Console.WriteLine("The number in binary is: {0}", numberBinary);

        int mask = 1;
        mask <<= index;
        mask &= number;
        mask >>= index;

        Console.WriteLine("The bit at position {0} of the number {1} is: {2}", index, number, mask);
    }
}
