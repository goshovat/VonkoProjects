using System;

class CompareFloatingPoints
{
    static void Main()
    {
        double a = 5.3;
        double b = 6.01;
        float c = Convert.ToSingle(a);
        float d = Convert.ToSingle(b);
        bool compare = (c == d);
        Console.WriteLine(compare);
        a = 5.00000001;
        b = 5.00000003;
        c = Convert.ToSingle(a);
        d = Convert.ToSingle(b);
        compare = (c == d);
        Console.WriteLine(compare);
    }
}

