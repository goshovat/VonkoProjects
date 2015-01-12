using System;

class ChangeNToChangeV
{
    static void Main()
    {
        Console.WriteLine("Write a number n:");
        string inputN = Console.ReadLine();
        int n = Convert.ToInt32(inputN);
        Console.WriteLine("Write a positioon p:");
        string inputP = Console.ReadLine();
        int p = Convert.ToInt32(inputP);
        Console.WriteLine("Write the new value of the bit p, v:");
        string inputV = Console.ReadLine();
        int v = Convert.ToInt32(inputV);

        string binary = Convert.ToString(n, 2).PadLeft(32, '0');
        Console.WriteLine("The old value of n in binary is: {0}", binary);
        Console.WriteLine();
       
        int mask = 1 << p;
 
        if (v == 0)
        {
            n = n & (~ mask); 
        }
        else if (v == 1)
        {
            n = n | mask;
        }

        Console.WriteLine("The value of v is: {0}",v);
        Console.WriteLine();
        Console.WriteLine("The new value of n is: {0}", n);
        Console.WriteLine();
        string binary2 = Convert.ToString(n, 2).PadLeft(32, '0');
        Console.WriteLine("The new value of n in binary is: {0}",binary2);;
    }
}

