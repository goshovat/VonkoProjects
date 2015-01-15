using System;

class IsPointWithinACircle
{
    static void Main()
    {
        //for precise calculation use the decima type
        Console.WriteLine("Write the coordinate X:");
        decimal xCoord = decimal.Parse(Console.ReadLine());

        Console.WriteLine("Write the coordinate Y:");
        decimal yCoord = decimal.Parse(Console.ReadLine());

        Console.WriteLine("Write the radius R:");
        decimal radius = decimal.Parse(Console.ReadLine());

        if (xCoord * xCoord + yCoord * yCoord < radius * radius)
        {
            Console.WriteLine("The point is WITHIN a circle with a center 0,0 and radius {0}", radius);
        }
        else if (xCoord * xCoord + yCoord * yCoord == radius * radius)
        {
            Console.WriteLine("The point is ON the circle with a center 0,0 and radius {0}", radius);
        }
        else
        {
            Console.WriteLine("The point is OUTSIDE of a circle with a center 0,0 and radius {0}", radius);
        }
    }
}