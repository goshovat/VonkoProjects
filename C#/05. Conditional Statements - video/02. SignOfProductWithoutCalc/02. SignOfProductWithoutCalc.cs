using System;

class SignOfProductWithoutCalc
{
    static void Main()
    {
        Console.WriteLine("Enter three numbers");
        int negative = 0;
        Console.WriteLine();

        for (int i = 0; i < 3; i++)
        {
            int a = int.Parse(Console.ReadLine());
            if (a == 0)
            {
                Console.WriteLine("The product will be zero");
                return;
            }
            else if (a < 0)
            {
                negative++;
            }
        }

        if (negative % 2 == 0)
        {
            Console.WriteLine("The number is positive");
        }
        else
        {
            Console.WriteLine("The number is negative");
        }
    }
}

