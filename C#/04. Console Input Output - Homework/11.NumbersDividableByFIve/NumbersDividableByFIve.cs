using System;

class NumbersDividableByFIve
{
    static void Main()
    {
        Console.WriteLine("Write two positive integers: ");
        int number1 = int.Parse(Console.ReadLine());
        int number2 = int.Parse(Console.ReadLine());
        if (number1 > number2)
        {
            int temp = number1;
            number1 = number2;
            number2 = number1;
        }
        int count = 0;
        Console.WriteLine();

        for (int i = number1; i <= number2; i++)
        {
            if (i % 5 == 0)
            {
                count++;
                Console.Write(i);
                if (i < number2)
                {
                    Console.Write(", ");
                }
                else
                {
                    Console.WriteLine();
                }
            }
        }

        Console.WriteLine("The integers in between divisible by 5 are: {0}", count);

    }
}
