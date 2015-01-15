using System;

class BitsExchange
{
    static void Main()
    {
        Console.WriteLine("Write the number n:");
        uint number = uint.Parse(Console.ReadLine());

        string binaryNumber = Convert.ToString(number, 2).PadLeft(32, '0');
        Console.WriteLine("The number in binary is: {0}", binaryNumber);
        Console.WriteLine();

        uint mask = 7;
        mask <<= 3;
        uint juniorBits = mask & number;
        string juniorBitsStr = Convert.ToString(juniorBits, 2).PadLeft(32, '0');
        Console.WriteLine("The junior bits are: {0}\n", juniorBitsStr);
        //null the junior bits of the original number
        number &= (~juniorBits);
        //move the saved junior bits
        juniorBits <<= 21;

        mask <<= 21;
        uint seniorBits = mask & number;
        string seniorBitsStr = Convert.ToString(seniorBits, 2).PadLeft(32, '0');
        Console.WriteLine("The senior bits are: {0}", seniorBitsStr);
        Console.WriteLine();
        //null the senior bits
        number &= (~seniorBits);
        seniorBits >>= 21;

        //place the extracted bits on their new positions
        number |= juniorBits;
        number |= seniorBits;

        Console.WriteLine("The new value of n is: {0}", number);
    }
}

