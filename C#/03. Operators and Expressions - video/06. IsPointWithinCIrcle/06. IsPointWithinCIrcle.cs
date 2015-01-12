using System;

class IsPodecimalWithinCIrcle
    {
        static void Main()
        {
            Console.WriteLine("Write the coordinate X:");
            string inputX = Console.ReadLine();
            decimal x = Convert.ToDecimal(inputX);

            Console.WriteLine("Write the coordinate Y:");
            string inputY = Console.ReadLine();
            decimal y = Convert.ToDecimal(inputY);

            Console.WriteLine("Write the radius R:");
            string inputR = Console.ReadLine();
            decimal r = Convert.ToDecimal(inputR);

            if (x * x + y * y < r * r)
            {
                Console.WriteLine("The podecimal is WITHIN a circle with a center 0,0 and radius {0}",r);
            }
            else if (x*x + y*y == r*r)
            {
                Console.WriteLine("The podecimal is ON the circle with a center 0,0 and radius {0}",r);
            }
            else
            {
                Console.WriteLine("The podecimal is OUTSIDE of a circle with a center 0,0 and radius {0}", r);
            }
        }
    }

