using System;

class Quotation
{
    static void Main()
    {
        string unQuoted = "The \"use\" of quotation causes difficulties.";
        string quoted = @"The ""use"" of quotation causes difficulties.";
        Console.WriteLine(unQuoted);
        Console.WriteLine(quoted);
    }
}

