using System;

class TriangleSurface
{
    static void Main()
    {
        Console.WriteLine("Choose wheter to calculate area by 3 sides(enter 1), a side and it's height(2),\n\ror two sides and angle in degress between them(3):");
        int choice = int.Parse(Console.ReadLine());
        double area = 0;
        bool foundSolution = false;

        switch (choice)
        {
            case 1:
                area = CalculateBySideAndHeight();
                break;
            case 2:
                area = CalculateByThreeSides();
                break;
            case 3:
                area = CalculateByTwoSidesAndAngle();
                break;
            default:
                Console.WriteLine("Wrong choice!");
                break;
        }

        if (choice == 1 || choice == 2 || choice == 3)
            foundSolution = true;

        if (foundSolution)
            Console.WriteLine("Area: {0:N2}", area);
    }

    //for every variant of finding the triangle's area there is a separate method
    static double CalculateByThreeSides()
    {
        Console.WriteLine("Enter the length of the first side: ");
        double side1 = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter the length of the second side:");
        double side2 = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter the length of the third side:");
        double side3 = double.Parse(Console.ReadLine());

        double semiPerimeter = (side1 + side2 + side3) / 2;

        double area = Math.Sqrt(semiPerimeter * (semiPerimeter - side1)
            * (semiPerimeter - side2) * (semiPerimeter - side3));

        return area;
    }

    static double CalculateBySideAndHeight()
    {
        Console.WriteLine("Enter the length of the side:");
        double side = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter the length of the height:");
        double height = double.Parse(Console.ReadLine());

        double area = side * height / 2;

        return area;
    }

    static double CalculateByTwoSidesAndAngle()
    {
        Console.WriteLine("Enter the length of the first side:");
        double side1 = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter the length of the second side:");
        double side2 = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter the length of the angle in degrees:");
        double angleInDegrees = double.Parse(Console.ReadLine());

        double angleInRadians = Math.PI * angleInDegrees / 180;

        double area = 0.5 * side1 * side2 * Math.Sin(angleInRadians);

        return area;
    }
}
