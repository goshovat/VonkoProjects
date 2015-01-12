using System;

class RectanglePerimeterArea
{
    static void Main()
    {
        Console.WriteLine("Write the base:");
        string inputBase = Console.ReadLine();
        double doubleBase = Convert.ToDouble(inputBase);
        Console.WriteLine("Write the height:");
        string inputHeight = Console.ReadLine();
        double doubleHeight = Convert.ToDouble(inputHeight);
        double perimeter = (doubleBase + doubleHeight) * 2;
        Console.WriteLine("The perimeter is: "+ perimeter);
        double area = doubleBase * doubleHeight;
        Console.WriteLine("The area is: " + area);
    }
}

