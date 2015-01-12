using System;

class IsThePointInTheCircle
{
    static void Main()
    {
        Console.WriteLine("Write coordinate X of the point: ");
        string inputX = Console.ReadLine();
        double x = Convert.ToDouble(inputX);
        Console.WriteLine("Write coordinate Y of the point: ");
        string inputY = Console.ReadLine();
        double y = Convert.ToDouble(inputY);
        double checker = x * x + y * y;
        if (checker <= 25)
        {
        
            Console.WriteLine("The point is in the circle");
        }
        else
        {
            Console.WriteLine("The point is outside of the circle");
        }
    }
}

