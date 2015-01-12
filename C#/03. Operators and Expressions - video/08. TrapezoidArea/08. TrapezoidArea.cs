using System;

class TrapezoidArea
{
    static void Main()
    {
        Console.WriteLine("Write the first base A(in cm):");
        string inputA = Console.ReadLine();
        double a = Convert.ToDouble(inputA);

        Console.WriteLine("Write the second base B(in cm):");
        string inputB = Console.ReadLine();
        double b = Convert.ToDouble(inputB);

        Console.WriteLine("Write the height H(in cm):");
        string inputH = Console.ReadLine();
        double h = Convert.ToDouble(inputH);

        double area = (a + b) * h / 2.0;

        Console.WriteLine("The area is: {0} cm2", area);
    }
}

