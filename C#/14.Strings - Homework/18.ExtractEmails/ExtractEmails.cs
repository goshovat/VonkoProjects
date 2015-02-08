using System;
using System.Text.RegularExpressions;

class ExtractEmails
{
    static void Main()
    {
        string text = "Please contact us by phone (+359 222 222 222) or by email at example@abv.bg or atbaj.ivan@yahoo.co.uk. This is not email: test@test. This also: @telerik.com. Neither this: a@a.b.";
        MatchCollection emails = GetEmails(text);

        Console.WriteLine("The emails in the text are:");

        foreach (Match email in emails)
        {
            Console.Write(email + " ");
        }
        Console.WriteLine();
    }

    static MatchCollection GetEmails(string text)
    {
        if (text == null)
            throw new ApplicationException("You have given text with null value.");

        MatchCollection emails = Regex.Matches(text, @"(\w[-._\w]*\w@\w[-._\w]*\w\.\w{2,3})");

        return emails;
    }
}

