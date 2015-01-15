using System;

class PointWithinACircleAndOutsideRect
{
    static void Main(string[] args)
    {
        Console.WriteLine("Write the coordinate X:");
        decimal xCoord = decimal.Parse(Console.ReadLine());

        Console.WriteLine("Write the coordinate Y:");
        decimal yCoord = decimal.Parse(Console.ReadLine());

        decimal radius = 1.5M;

        //The coordinates of the center of the circle;
        decimal Xo = 1;
        decimal Yo = 1;

        bool inCircle = false;
        bool inRectangle = false;

        //Now we will check if the point is within the circle
        if ((xCoord - Xo) * (xCoord - Xo) + 
            (yCoord - Yo) * (yCoord - Yo) <= radius * radius)
        {
            inCircle = true;
        }
        //Now we will check if the point is within the rectangle
        if (xCoord >= -1 && xCoord <= 5 
            && yCoord >= -1 && yCoord <= 1)
        {
            inRectangle = true;
        }

        //Now we check if the podecimal is within the circle and outside the rectangle
        if (inCircle == true && inRectangle == false)
        {
            Console.WriteLine("Yes");
        }
        else
        {
            Console.WriteLine("No");
        }
    }
}

