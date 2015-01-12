using System;

class IsThirdBit0or1
{
    static void Main()
    {
        string input = Console.ReadLine();
        int inputInt = Convert.ToInt32(input);
        int checker = 1 << 1;
        if ((inputInt & checker) != 0)
        {
            Console.WriteLine("The third bit is 1!");
        }
        else
        {
            Console.WriteLine("The third bit is 0!");
        }
    }
}

