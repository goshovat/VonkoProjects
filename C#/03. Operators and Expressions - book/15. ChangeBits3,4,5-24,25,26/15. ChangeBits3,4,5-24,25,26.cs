using System;

class ChangeBits3_4_5_24_25_26
{
    static void Main()
    {
        Console.WriteLine("Enter the number:");
        string input = Console.ReadLine();
        uint n = Convert.ToUInt32(input);
        string binaryOriginal = Convert.ToString(n, 2).PadLeft(32, '0');

        Console.WriteLine("The original number in binary is: {0}", binaryOriginal);
        Console.WriteLine();

        uint juniorChecker = 7 << 3;
        uint juniorBits = juniorChecker & n;  //Here we take the first three bits 
        string juniorBitsStr = Convert.ToString(juniorBits, 2).PadLeft(32, '0');
        Console.WriteLine("The first bits are: {0}", juniorBitsStr);
        Console.WriteLine();
        n = n & (~juniorBits); // Here we null the first three bits
        string binary2 = Convert.ToString(n, 2).PadLeft(32, '0');
        Console.WriteLine("The number with the first bits nulled is: {0}", binary2);
        Console.WriteLine();
        juniorBits = juniorBits << 21;  //Here we mve the first three bits to their new positions
        string juniorBitsStr2 = Convert.ToString(juniorBits, 2).PadLeft(32, '0');
        Console.WriteLine("The first bits moved to their new positions are: {0}", juniorBitsStr2);

        uint seniorChecker = 7 << 24;
        uint seniorBits = seniorChecker & n;  //Here we take the other three bits
        string seniorBitsStr = Convert.ToString(seniorBits, 2).PadLeft(32, '0');
        Console.WriteLine("The other three bits are: {0}", seniorBitsStr);
        Console.WriteLine();
        n = n & (~seniorBits);
        string binary3 = Convert.ToString(n, 2).PadLeft(32, '0');
        Console.WriteLine("The number with the other three bits also nulled is: {0}", binary3);
        Console.WriteLine();
        seniorBits = seniorBits >> 21;   //We move the other three bits to their new positions
        string seniorBitsStr2 = Convert.ToString(seniorBits, 2).PadLeft(32, '0');
        Console.WriteLine("The other three bits moved to their new positions are: {0}", seniorBitsStr2);
        Console.WriteLine();

        n = n | juniorBits;
        n = n | seniorBits;

        string binaryFinal = Convert.ToString(n, 2).PadLeft(32, '0');
        Console.WriteLine("The number with the bits exchanget is: {0}", binaryFinal);
    }
}