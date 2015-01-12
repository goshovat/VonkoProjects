using System;

class CartesianCoordinateSystem
{
    static void Main()
    {
        string inputX = Console.ReadLine(); 
        double x = double.Parse(inputX);
        string inputY = Console.ReadLine();
        double y = double.Parse(inputY);

        if (x > 0 && y > 0) 
        {
            Console.WriteLine(1);
        }
        else if (x < 0 && y > 0) 
        {
            Console.WriteLine(2);
        }
        else if (x < 0 && y < 0) 
        {
            Console.WriteLine(3);
        }
        else if (x > 0 && y < 0)
        {
            Console.WriteLine(4);
        }
        else if (x == 0 && y == 0)
        {
            Console.WriteLine(0);
        }
        else if (x == 0 && y != 0)
        {
            Console.WriteLine(5);
        }
        else
        {
            Console.WriteLine(6);
        }
    }
}

