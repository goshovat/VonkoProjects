using System;

class PutVatPositionP
{
    static void Main()
    {
        Console.WriteLine("Write the number n:");
        string inputN = Console.ReadLine();
        int n = Convert.ToInt32(inputN);

        string binary = Convert.ToString(n, 2).PadLeft(32, '0');

        Console.WriteLine("Write the position of the bit you like to modify:");
        string inputP = Console.ReadLine();
        int p = Convert.ToInt32(inputP);
        Console.WriteLine();

        Console.WriteLine("Write the value(V) you like to put on position v:(0 or 1)");
        string inputV = Console.ReadLine();
        int v = Convert.ToInt32(inputV);
        Console.WriteLine();

        Console.WriteLine("The binary representation of the number n is: {0}", binary);
        Console.WriteLine();

        if ((v != 0) && (v != 1))
        {
            Console.WriteLine("V must be 0 or 1!");
        }
        else
        {
            //I create mask0 to be able to make 0 the bit p in the number n
            int mask0 = 1;
            mask0 <<= p;

            v <<= p;

            //Now I make 0 the bit at position p in the number
            n &= (~mask0);

            //Now when the bit is 0 we can easily place the new value from v
            n |= v;

            Console.WriteLine("The new number n is: {0}", n);

            string binary2 = Convert.ToString(n, 2).PadLeft(32, '0');

            Console.WriteLine("The new number n in binary is: {0}", binary2);
        }
    }
}
