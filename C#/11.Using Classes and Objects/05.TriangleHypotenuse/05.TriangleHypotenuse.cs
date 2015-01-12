using System;

class TriangleHypotenuse
{
    static void Main()
    {
        Console.WriteLine("Write the length of the first catet:");
        double catet1 = double.Parse(Console.ReadLine());
        Console.WriteLine("Write the length of the second catet:");
        double cater2 = double.Parse(Console.ReadLine());

        double area = CalculateHypotenuze(catet1, cater2);

        Console.WriteLine("The hypotenuze is: {0:N2}", area);
    }

    //this method calculates hypotenuze by given 2 catets
    static double CalculateHypotenuze(double catet1, double catet2)
    {
        return Math.Sqrt(Math.Pow(catet1, 2) + Math.Pow(catet2, 2));
    }
}
