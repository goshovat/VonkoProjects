using System;

class IntegersDividableBy5
{
    static void Main()
    {
        Console.WriteLine("Write two positive integers: ");
        string inputA = Console.ReadLine();
        int a;
        string inputB = Console.ReadLine();
        int b;
        int count = 0;
        Console.WriteLine();

        if ((int.TryParse(inputA, out a)) && (int.TryParse(inputB, out b)))
        {
            int biggerNumber = ((a + b) + Math.Abs(a - b)) / 2;
            int lesserNumber = ((a + b) - Math.Abs(a - b)) / 2;

            for (int i = lesserNumber; i <= biggerNumber; i++)
            {
                if (i % 5 == 0)
                {
                    count++;
                }
            }

            Console.WriteLine("The integers in between divisible by 5 are: {0}", count);
        }
        else
        {
            Console.WriteLine("Please enter two valid integers!");
            Console.WriteLine();
            Main();
        }
    }
}

