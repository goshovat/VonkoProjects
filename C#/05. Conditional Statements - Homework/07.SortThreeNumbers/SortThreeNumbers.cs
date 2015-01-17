using System;

class SortThreeNumbers
{
    static void Main()
    {
        Console.WriteLine("Enter three numbers:");
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());

        if (a >= b && a >= c)
        {
            if (a == b & a == c)
            {
                Console.WriteLine("The three numbers are equal to {0}", a);
            }
            else if (a > b && a == c)
            {
                Console.WriteLine("The biggest numbers are {0} and {1} and {2} is smaller", a, c, b);
            }
            else if (a > c && a == b)
            {
                Console.WriteLine("The biggest numbers are {0} and {1} and {2} is smaller", a, b, c);
            }
            else
            {
                if (b > c)
                {
                    Console.WriteLine("The descending order of the numbers is {0},{1},{2}", a, b, c);
                }
                else if (b < c)
                {
                    Console.WriteLine("The descending order of the numbers is {0},{1},{2}", a, c, b);
                }
                else
                {
                    Console.WriteLine("{0} is bigger amd {1} and {2} are smaller and equal", a, b, c);
                }
            }
        }
        else if (a >= b && a <= c)
        {
            if (a == b && a < c)
            {
                Console.WriteLine("{0} is bigger amd {1} and {2} are smaller and equal", c, a, b);
            }
            else if (a > b && a < c)
            {
                Console.WriteLine("The descending order of the numbers is {0},{1},{2}", c, a, b);
            }
        }
        else if (a >= c && a <= b)
        {
            if (a == c && a < b)
            {
                Console.WriteLine("{0} is bigger amd {1} and {2} are smaller and equal", b, a, c);
            }
            else if (a > c && a < b)
            {
                Console.WriteLine("The descending order of the numbers is {0},{1},{2}", b, a, c);
            }
        }
        else if (a < b && a < c)
        {
            if (b > c)
            {
                Console.WriteLine("The descending order of the numbers is {0},{1},{2}", b, c, a);
            }
            else if (b < c)
            {
                Console.WriteLine("The descending order of the numbers is {0},{1},{2}", c, b, a);
            }
            else
            {
                Console.WriteLine("The biggest numbers are {0} and {1} and {2} is smaller", b, c, a);
            }
        }
    }
}

