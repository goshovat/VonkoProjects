using System;

class IsBitOnPos1
{
    static void Main()
    {
        Console.WriteLine("Write the number v:");
        string inputV = Console.ReadLine();
        int v = Convert.ToInt32(inputV);
        Console.WriteLine("Write the position p:");
        string inputP = Console.ReadLine();
        int p = Convert.ToInt32(inputP);

        int mask = 1 << p;

        bool isOne = false;

        if ((mask & v) != 0)
        {
            isOne = true;
        }

        Console.WriteLine(isOne);
    }
}

