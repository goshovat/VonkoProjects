using System;

class RectangleArea
{
    static void Main()
    {
        Console.WriteLine("Write the width:");
        string inputWidth = Console.ReadLine();
        double width = Convert.ToDouble(inputWidth);

        Console.WriteLine("Write the height, bitch!");
        string inputHeight = Console.ReadLine();
        double height = Convert.ToDouble(inputHeight);

        double area = width * height;
        Console.WriteLine("The area is: {0}", area);
    }
}

