using System;

class AdvancedBitsExchange
{
    static void Main()
    {
        Console.WriteLine("Write the number n:");
        uint number;
        string numberInput = Console.ReadLine();
        if (!uint.TryParse(numberInput, out number))
        {
            Console.WriteLine("Out of range.");
            return;
        }

        Console.WriteLine("Enter the starting position of the first sequence(p):");
        int p = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the starting position the second sequence(q):");
        int q = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the length of the sequences(k):");
        int k = int.Parse(Console.ReadLine());

        if (p < 0 || p + k > 32 || q < 0 || q + k > 32)
        {
            Console.WriteLine("Out of range.");
            return;
        }
        else if (q <= p + k - 1)
        {
            Console.WriteLine("Overlapping.");
            return;
        }

        uint mask = 1;
        for (int i = 0; i < k; i++)
        {
            mask *= 2;
        }
        mask -= 1;

        mask <<= p;
        uint juniorBits = mask & number;
        //null the junior bits of the original number
        number &= (~juniorBits);
        juniorBits <<= (q - p);

        mask <<= (q - p);
        uint seniorBits = mask & number;
        //Now I will null the senior Bits
        number &= (~seniorBits);
        seniorBits >>= (q - p);

        number |= juniorBits;
        number |= seniorBits;

        Console.WriteLine("The new value of n is: {0}", number);
    }
}
