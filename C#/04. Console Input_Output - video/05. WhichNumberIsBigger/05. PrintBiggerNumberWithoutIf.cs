using System;

class PrintBiggerNumberWithoutIf
{
    static void Main()
    {
        Console.WriteLine("Write two numbers to see which is the bigger one: ");
        string inputA = Console.ReadLine();
        double a;
        string inputB = Console.ReadLine();
        double b;

        if ((double.TryParse(inputA, out a)) && (double.TryParse(inputB, out b)))
        {
            double biggerNumber = ((a + b) + Math.Abs(a - b)) / 2;
            double lesserNumber = ((a + b) - Math.Abs(a - b)) / 2;

            Console.WriteLine("The bigger number is: {0:F2}", biggerNumber);
        }
        else
        {
            Console.WriteLine("Please enter valid numbers!");
            Console.WriteLine();
            Main();
        }
    }
}

