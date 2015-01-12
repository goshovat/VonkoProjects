using System;


class ThreeInts
{
    static void Main()
    {
        Console.WriteLine("Write three integers:");

        string inputA = Console.ReadLine();
        string inputB = Console.ReadLine();
        string inputC = Console.ReadLine();   

        int a;
        int b;
        int c;

        bool parseA = int.TryParse(inputA, out a);
        bool parseB = int.TryParse(inputB, out b);
        bool parseC = int.TryParse(inputC, out c);

        int sum = a + b + c;

        if ((parseA == true) && (parseB == true) && (parseC == true))
        {
            Console.WriteLine("The sum of the numbers is: {0}", sum);
        }
        else
        {
            Console.WriteLine("Please enter valid whole numbers!");
        }
    }
}

