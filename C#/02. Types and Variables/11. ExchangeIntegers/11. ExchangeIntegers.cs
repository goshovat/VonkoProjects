using System;

class ExchangeIntegers
{
    static void Main()
    {
        int a = 5;
        int b = 10;
        b = b - a;
        a = b + a;
        Console.WriteLine("a is {0}, b is {1}",a,b);
    }
}

