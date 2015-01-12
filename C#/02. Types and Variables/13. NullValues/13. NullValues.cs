using System;

class NullValues
{
    static void Main()
    {
        int? a = 5;
        double? b = 7;
        Console.WriteLine("a:{0} b:{1}",a,b);
        Console.WriteLine("Now we will give them null values");
        a = null;
        b = null;
        Console.WriteLine("a:{0} b:{1}",a,b);
        Console.WriteLine("Now we will add some integers to the null values");
        a = a + 6;
        b = b + 8;
        Console.WriteLine("a:{0} b:{1}",a,b);
    }
}

