using System;

class CheckTheBitAtGivenPosition
{
    static void Main()
    {
        Console.WriteLine("Write the number:");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine("Write the position p:");
        int position = int.Parse(Console.ReadLine());

        int mask = 1 << position;
        bool isOne = false;

        if ((mask & number) != 0)
        {
            isOne = true;
        }

        Console.WriteLine(isOne);
    }
}

