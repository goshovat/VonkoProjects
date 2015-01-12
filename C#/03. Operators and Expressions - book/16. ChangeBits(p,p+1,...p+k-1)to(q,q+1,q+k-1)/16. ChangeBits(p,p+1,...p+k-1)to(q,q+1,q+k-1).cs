using System;

class ChangeBitsP_Q_K
{
    static void Main()
    {
        Console.WriteLine("Write the number n:");
        uint n = Convert.ToUInt32(Console.ReadLine());
        string binary = Convert.ToString(n, 2).PadLeft(32,'0');

        Console.WriteLine("Write the first starting position p:");
        byte p = Convert.ToByte(Console.ReadLine());
        Console.WriteLine("Write the second starting position q:");
        byte q = Convert.ToByte(Console.ReadLine());
        Console.WriteLine("Write the length of the two sequences of bits k:");
        byte k = Convert.ToByte(Console.ReadLine());

        Console.WriteLine("The number in binary is: {0}", binary);
        Console.WriteLine();
       
        uint mask = 1;

        //Here we create the mask of 1s
        for (int i = 0; i < k; i++)
        {
            mask *= 2;
        }

        uint juniorChecker = (mask - 1) << p;
        string juniorCheckerStr = Convert.ToString(juniorChecker, 2).PadLeft(32,'0');
        Console.WriteLine("The junior checker is: {0}", juniorCheckerStr);
        Console.WriteLine();
        //Now we wiil get the junior bits
        uint juniorBits = n & juniorChecker;
        string juniorBitsStr = Convert.ToString(juniorBits, 2).PadLeft(32, '0');
        Console.WriteLine("The junior bits are: {0}", juniorBitsStr);
        Console.WriteLine();
        //Now we will null the junior bits
        n = n & (~juniorBits);
        string binary2 = Convert.ToString(n, 2).PadLeft(32, '0');
        Console.WriteLine("The number with junior positions nulled is: {0}", binary2);
        Console.WriteLine();
        //Now we will move the senior bits to the position of the junior bits
        juniorBits = juniorBits << (q - p);
        string juniorBitsPos = Convert.ToString(juniorBits, 2).PadLeft(32, '0');
        Console.WriteLine("The mask with junior bits on their new positions is: {0}", juniorBitsPos);
        Console.WriteLine();

        uint seniorChecker = (mask - 1) << q;
        string seniorCheckerStr = Convert.ToString(seniorChecker, 2).PadLeft(32, '0');
        Console.WriteLine("The senior checker is: {0}", seniorCheckerStr);
        Console.WriteLine();
        //Now we will get the senior bits
        uint seniorBits = n & seniorChecker;
        string seniorBitsStr = Convert.ToString(seniorBits, 2).PadLeft(32, '0');
        Console.WriteLine("The senior bits are: {0}", seniorBitsStr);
        Console.WriteLine();
        //Now we will null the senior bits
        n = n & (~seniorBits);
        string binary3 = Convert.ToString(n, 2).PadLeft(32, '0');
        Console.WriteLine("The number with the junior and senior bits nulled is: {0}", binary3);
        Console.WriteLine();
        //Now we will move the senior bits to the position of the junior bits
        seniorBits = seniorBits >> (q - p);
        string seniorBitsPos = Convert.ToString(seniorBits, 2).PadLeft(32, '0');
        Console.WriteLine("The mask with the senior bits on their new position is: {0}", seniorBitsPos);
        Console.WriteLine();

        //Now we will position the junior bits and senior bits on their new position
        n = n | seniorBits;
        n = n | juniorBits;
        string nFinal = Convert.ToString(n, 2).PadLeft(32, '0');
        Console.WriteLine("The number with the bits exchanged is: {0}", nFinal);
    }
}

