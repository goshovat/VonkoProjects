using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.WithinCircleAndOutOfRect
{
    class Program
    {
        static void Main(string[] args)
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

            //The coordinates of the center of the circle;
            decimal Xo = 1;
            decimal Yo = 1;

            bool inCircle = false;
            bool inRectangle = false;

            //Now we will check if the podecimal is within the circle
            if ((x - Xo) * (x - Xo) + (y - Yo) * (y - Yo) <= r * r)
            {
                inCircle = true;
            }
          
            else
            {
                inCircle = false;
            }

            //Now we will check if the podecimal is within the rectangle
            if ((x >= -1) && (x <= 5) && (y >= -1) && (y <= 1))
            {
                inRectangle = true;
            }
            else
            {
                inRectangle = false;
            }

            //Now we check if the podecimal is within the circle and outside the rectangle

            if ((inCircle == true) && (inRectangle == false))
            {
                Console.WriteLine("The podecimal is within the circle and outside the rectangle");
            }
            else
            {
                Console.WriteLine("The podecimal is NOT within the cricle and outside the rectangle");
            }
        }
    }
}
