namespace ExchangeVariableValues
{
    using System;

    class ExchangeVariableValues
    {
        static void Main()
        {
            int a = 5;
            int b = 10;
            Console.WriteLine("Before exchange a is {0}, b is {1}", a, b);
            b = b - a;
            a = b + a;
            Console.WriteLine("After exchange a is {0}, b is {1}", a, b);
        }
    }
}
