using System;

class RectangleArea
{
    static void Main()
    {
        Console.WriteLine("Write the width:");
        double width = double.Parse(Console.ReadLine());
        Console.WriteLine("Write the height:");
        double height = double.Parse(Console.ReadLine());

        if (width < 0 || height < 0)
            throw new ArgumentException("The width or height cannot be negative.");

        double perimeter = 2 * (width + height);
        double area = width * height;
        Console.WriteLine("Perimeter: {0:N2}, Area: {1:N2}", perimeter, area);
    }
}
