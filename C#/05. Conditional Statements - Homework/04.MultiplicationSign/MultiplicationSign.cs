using System;

class MultiplicationSign
{
    static void Main()
    {
        Console.WriteLine("Enter three numbers:");
        int negative = 0;

        for (int i = 0; i < 3; i++)
        {
            double a = double.Parse(Console.ReadLine());
            if (a == 0)
            {
                Console.WriteLine(0);
                return;
            }
            else if (a < 0)
            {
                negative++;
            }
        }

        if (negative % 2 == 0)
        {
            Console.WriteLine("+");
        }
        else
        {
            Console.WriteLine("-");
        }
    }
}
