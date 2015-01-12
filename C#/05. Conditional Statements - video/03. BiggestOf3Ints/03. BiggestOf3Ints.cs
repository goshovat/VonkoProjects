using System;

class PBiggestOf3Ints
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());
        Console.WriteLine();

        if (a >= b && a >= c)
        {
            if (a == b && a == c)
            {
                Console.WriteLine("The three numbers are eqaual");
            }
            else if (a > b && a > c)
            {
                Console.WriteLine("The biggest number is {0}", a);
            }
            else if (a == b && a > c)
            {
                Console.WriteLine("{0} and {1} are bigger and equal", a, b);
            }
            else 
            {
                Console.WriteLine("{0} and {1} are bigger and equal", a, c);
            }
        }

        else if (a >= b && a <= c)
        {
            if (a > b && a < c)
            {
                Console.WriteLine("The biggest number is {0}", c);
            }
            else if (a == b & a < c)
            {
                Console.WriteLine("The biggest number is {0}", c);
            }
        }

        else if (a <= b && a >= c)
        {
            if (a < b && a > c)
            {
                Console.WriteLine("The biggest number is {0}", b);
            }
            else if (a < b && a == c)
            {
                Console.WriteLine("The biggest number is {0}", b);
            }
        }


        else if (a < b && a < c)
        {
            if (b > c)
            {
                Console.WriteLine("The biggest number is {0}", b);
            }
            else if (b < c)
            {
                Console.WriteLine("The biggest number is {0}", b);
            }
            else
            {
                Console.WriteLine("The numbers {0} and {1} are equal",b,c);
            }
        }

    }
}

