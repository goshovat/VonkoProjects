using System;

class IsTheBitAtPosP_1
{
    static void Main()
    {
        Console.WriteLine("Write the number v:");
        string inputV = Console.ReadLine();
        int v = Convert.ToInt32(inputV);

        Console.WriteLine("Write the number p:");
        string inputP = Console.ReadLine();
        int p = Convert.ToInt32(inputP);

        string vBinary = Convert.ToString(v, 2).PadLeft(32, '0');
        Console.WriteLine("The number in binary is: {0}", vBinary);

        int mask = 1;
        mask <<= p;
        mask &= v;
        mask >>= p;

        bool isOne = false;

        if (mask == 1)
        {
            isOne = true;
        }
        else
        {
            isOne = false;
        }

        Console.WriteLine("The bit at position {0} of the number {1} is 1 - {2}", p,v,isOne);   
    }
}

