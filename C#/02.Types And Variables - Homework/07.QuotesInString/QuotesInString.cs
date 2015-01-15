using System;

class QuotesInString
{
    static void Main()
    {
        string escapedStr = "The \"use\" of quotation causes difficulties.";
        string unescapedStr = @"The ""use"" of quotation causes difficulties.";
        Console.WriteLine(escapedStr);
        Console.WriteLine(unescapedStr);
    }
}
