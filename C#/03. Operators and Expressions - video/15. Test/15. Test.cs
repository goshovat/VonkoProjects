using System;
using System.Threading;
using System.Globalization;

class Test
{
    static void Main()
    {
        string str = Console.ReadLine();
        int value;
        bool successParse = Int32.TryParse(str, out value);
        Console.WriteLine(successParse ? "The number is correct" : "fuck off");
    }
}

