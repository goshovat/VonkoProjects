using System;

class ModifyBitAtGivenPosition
{
    static void Main()
    {
        Console.WriteLine("Write a number:");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine("Write a positioon:");
        int position = int.Parse(Console.ReadLine());
        Console.WriteLine("Write the new value of the bit at the position:");
        int value = int.Parse(Console.ReadLine());

        string binaryNumber = Convert.ToString(number, 2).PadLeft(32, '0');
        Console.WriteLine("The old value of n in binary is: {0}", binaryNumber);
        Console.WriteLine();

        int mask = 1 << position;

        if (value == 0)
        {
            number = number & (~mask);
        }
        else if (value == 1)
        {
            number = number | mask;
        }

        Console.WriteLine("The new value of number is: {0}", number);
    }
}
