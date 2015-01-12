using System;

class IsPointInCircleAndOutsideRect
{
    static void Main()
    {
        Console.WriteLine("Write coorditnate X of the point: ");
        string inputX = Console.ReadLine();
        double x = Convert.ToDouble(inputX);
        Console.WriteLine("Write coordinate Y of the point: ");
        string inputY = Console.ReadLine();
        double y = Convert.ToDouble(inputY);
        Console.WriteLine("Write radius of the circle with center(0,0)");
        string inputR = Console.ReadLine();
        double r = Convert.ToDouble(inputR);

        bool inCircle = false;
        if ((x * x + y * y) <= (r * r))
        {
            inCircle = true;
        }

        bool inRectang = false;
        if ((x <= 5) && (x >= -1) && (y >= -5) && (y <= 1))
        {
            inRectang = true;
        }

        if ((inCircle == true) && (inRectang == false))
        {
            Console.WriteLine("The poin is in the circle and out of the rectangle");
        }
        else
        {
            Console.WriteLine("The point is NOT in the circle and out of the rectangle");
        }
    }
}

