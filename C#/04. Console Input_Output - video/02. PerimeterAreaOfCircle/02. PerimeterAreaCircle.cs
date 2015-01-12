using System;

class PerimeterAreaOfCircle
{
    static void Main()
    {
        Console.WriteLine("Enter the radius of the circle: ");
        string input = Console.ReadLine();
        double radius;
        double perimeter;
        double area;

        if (double.TryParse(input, out radius))
        {
            perimeter = 2 * Math.PI * radius;
            area = Math.PI * radius * radius;

            Console.WriteLine("The perimeter of the circle is: {0:F3}", perimeter);
            Console.WriteLine("The area of the circle is: {0:F3}", area);
        }
        else
        {
            Console.WriteLine("Please enter valid number!");
            Main();
            Console.WriteLine();
        }
    }
}

