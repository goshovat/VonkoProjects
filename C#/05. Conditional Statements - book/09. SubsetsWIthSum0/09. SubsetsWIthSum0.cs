using System;

class SubsetsWIthSum0
{
    static void Main()
    {
        Console.WriteLine("Write your subset of five integers: ");
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());
        int d = int.Parse(Console.ReadLine());
        int e = int.Parse(Console.ReadLine());

        if (a + b == 0)
        {
            Console.WriteLine("The sum of {0} and {1} is zero!", a,b);
        }
        else if (a + b + c == 0)
        {
            Console.WriteLine("The sum of {0}, {1} and {2} is zero!",a,b,c);
        }
        else if (a + b + c + d == 0)
        {
            Console.WriteLine("The sum of {0}, {1}, {2} and {3} is zero!",a,b,c,d);
        }
        else if (a + b + c + d + e == 0)
        {
            Console.WriteLine("The sum of {0}, {1}, {2}, {3} and {4} is zero!",a,b,c,d,e);
        }
        else if (a + c == 0)
        {
            Console.WriteLine("The sum of {0} and {1} is zero!", a,c);
        }
        else if (a + c + d == 0)
        {
            Console.WriteLine("The sum of {0}, {1} and {2} is zero!",a,c,d);
        }
        else if (a + c + d + e == 0)
        {
            Console.WriteLine("The sum of {0}, {1}, {2} and {3} is zero!",a,c,d,e);
        }
        else if (a + d == 0)
        {
            Console.WriteLine("The sum of {0} and {1} is zero!", a, d);
        }
        else if (a + d + e == 0)
        {
            Console.WriteLine("The sum of {0},{1} and {2} is zero!",a,d,e);
        }
        else if (a + e == 0)
        {
            Console.WriteLine("The sum of {0} and {1} is zero!", a,e);
        }
        else if (b + c == 0)
        {
            Console.WriteLine("The sum of {0} and {1} is zero!",b,c);
        }
        else if (b + c + d == 0)
        {
            Console.WriteLine("The sum of {0}, {1} and {2} is zero!",b,c,d);
        }
        else if (b + c + d + e == 0)
        {
            Console.WriteLine("The sum of {0}, {1}, {2} and {3} is zero!",b,c,d,e);
        }
        else if (b + d == 0)
        {
            Console.WriteLine("The sum of {0} and {1} is zero!",b,d);
        }
        else if (b + d + e == 0)
        {
            Console.WriteLine("The sum of {0}, {1} and {2} is zero!",b,d,e);
        }
        else if (b + e == 0)
        {
            Console.WriteLine("The sum of {0} and {1} is zero!", b,e);
        }
        else if (c + d == 0)
        {
            Console.WriteLine("The sum of {0} and {1} is zero!",c,d);
        }
        else if (c + d + e == 0)
        {
            Console.WriteLine("The sum of {0}, {1} and {2} is zero!",c,d,e);
        }
        else if (c + e == 0)
        {
            Console.WriteLine("The sum of {0} and {1} is zero!",c,e);
        }
        else if (d + e == 0)
        {
            Console.WriteLine("The sum of {0} and {1} is zero!", d,e);
        }
        else if (a == 0)
        {
            Console.WriteLine("The number {a} equals zero!");
        }
        else if (b == 0)
        {
            Console.WriteLine("The number {b} equals zero!");
        }
        else if (c == 0)
        {
            Console.WriteLine("The number {c} equals zero!");
        }
        else if (d == 0)
        {
            Console.WriteLine("The number {d} equals zero!");
        }
        else if (e == 0)
        {
            Console.WriteLine("The number {a} equals zero!");
        }

        else
        {
            Console.WriteLine("There are no subsets with sum 0!");
        }
    }
}

