using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.QuadraticEquation
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Write the coefficents 'a', 'b' and 'c' of your quadratic equation: ");
            string inputA = Console.ReadLine();
            double aDouble;
            bool parseA = double.TryParse(inputA, out aDouble);
            Console.WriteLine();

            string inputB = Console.ReadLine();
            double bDouble;
            bool parseB = double.TryParse(inputB, out bDouble);
            Console.WriteLine();

            string inputC = Console.ReadLine();
            double cDouble;
            bool parseC = double.TryParse(inputC, out cDouble);
            Console.WriteLine();

            if ((parseA == true) && (parseB == true) && (parseC == true))
            {
                double d = Math.Sqrt((bDouble * bDouble) - (4 * aDouble * cDouble));

                if (d == 0)
                {
                    double x = (-bDouble) / (2 * aDouble);

                    Console.WriteLine("The only real solution to the equation is: {0:F3}", x);
                    Console.WriteLine();
                }
                else if (d > 0)
                {
                    double x1 = (-bDouble + Math.Sqrt(d)) / (2 * aDouble);
                    double x2 = (-bDouble - Math.Sqrt(d)) / (2 * aDouble);

                    Console.WriteLine("The two real solutions to the equation are {0:F3} and {1:F3}", x1,x2);
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("There is no real solution to the equation");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Please enter valid numbers!");
                Console.WriteLine();
                Main();
            }
        }
    }
}
