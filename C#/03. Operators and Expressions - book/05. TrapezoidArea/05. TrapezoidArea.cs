using System;

class TrapezoidArea
{
    static void Main()
    {
        Console.WriteLine("Write the length of base 1:");
        string inputA = Console.ReadLine();
        double doubleA = Convert.ToDouble(inputA);
        Console.WriteLine("Write the length of base 2:");
        string inputB = Console.ReadLine();
        double doubleB = Convert.ToDouble(inputB);
        Console.WriteLine("Writhe the length of the height:");
        string inputH = Console.ReadLine();
        double doubleH = Convert.ToDouble(inputH);
        double area = (doubleA + doubleB) * doubleH / 2;
        Console.WriteLine("The area is: " + area);
    }
}

