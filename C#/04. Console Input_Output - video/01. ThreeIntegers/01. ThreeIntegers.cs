using System;

class ThreeIntegers
{
    static void Main()
    {
        Console.WriteLine("Write the first integer: ");
        string inputA = Console.ReadLine();
        int a;
        Console.WriteLine();
        Console.WriteLine("Write the second integer: ");
        string inputB = Console.ReadLine();
        int b;
        Console.WriteLine();
        Console.WriteLine("Write the third integer: ");
        string inputC = Console.ReadLine();
        int c;
        Console.WriteLine();

        if (int.TryParse(inputA, out a) && (int.TryParse(inputB, out b)) 
            && (int.TryParse(inputC, out c)))
        {
            Console.WriteLine("The sum of {0}, {1} and {2} is {3}", a, b, c, a+b+c);
        }
        else
        {
            Console.WriteLine("Please enter valid integers!");
            Console.WriteLine();
            Main();
        }
    }
}

