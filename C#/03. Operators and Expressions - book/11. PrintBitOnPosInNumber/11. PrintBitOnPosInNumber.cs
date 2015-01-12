using System;

class PrintBitOnPosInNumber
{
    static void Main()
    {
        Console.WriteLine("Write the number n:");
        string inputN = Console.ReadLine();
        int n = Convert.ToInt32(inputN);
        Console.WriteLine("Write the position p:");
        string inputP = Console.ReadLine();
        int p = Convert.ToInt32(inputP);

        int mask = 1 << p;
        if ((n & mask) != 0)
        {
            Console.WriteLine("The bit on pos {0} is 1", p);
        }
        else
        {
            Console.WriteLine("The bit on pos {0} is 0", p);
        }
    }
}

