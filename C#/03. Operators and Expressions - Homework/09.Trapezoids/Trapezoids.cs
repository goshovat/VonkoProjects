using System;

class TrapezoidArea
{
    static void Main()
    {
        Console.WriteLine("Write the first base A(in cm):");
        double a = double.Parse(Console.ReadLine());

        Console.WriteLine("Write the second base B(in cm):");
        double b = double.Parse(Console.ReadLine());

        Console.WriteLine("Write the height H(in cm):");
        double h = double.Parse(Console.ReadLine());

        double area = (a + b) * h / 2.0;

        Console.WriteLine("The area is: {0}", area);
    }
}

