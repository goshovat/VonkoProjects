using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class ExtractEmails
{
    static void Main()
    {
        string text = "Please contact us by phone (+359 222 222 222) or by email at example@abv.bg or atbaj.ivan@yahoo.co.uk. This is not email: test@test. This also: @telerik.com. Neither this: a@a.b.";

        try
        {
            MatchCollection emails = GetEmails(text);

            Console.WriteLine("The emails in the text are:");

            foreach (Match email in emails)
            {
                Console.Write(email + " ");
            }
            Console.WriteLine();
        }
        catch (ApplicationException applExc)
        {
            Console.WriteLine("Error! Details:\n{0}", applExc.StackTrace);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error occured during program execution! Details:\n{0}", e.StackTrace);
        }
    }

    static MatchCollection GetEmails(string text)
    {
        if (text == null)
            throw new ApplicationException("You have given text with null value.");

        MatchCollection emails = Regex.Matches(text, @"(\w[-._\w]*\w@\w[-._\w]*\w\.\w{2,3})");

        return emails;
    }
}

