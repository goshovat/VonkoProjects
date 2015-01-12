using System;
using System.Globalization;
using System.Text.RegularExpressions;

class ExtractDates
{
    static void Main()
    {
        try
        {
            string text = "I was born at 14.06.1980. My sister was born at 3.7.1984. In 5/1999 I graduated my high school. The law says (see section 7.3.12) that we are allowed to do this (section 7.4.2.9).";
            MatchCollection dates = GetDates(text);

            Console.WriteLine("The dates in the text are:");
            string format = "d.m.yyyy";

            foreach (Match date in dates)
            {
                DateTime currentDate = DateTime.ParseExact(date.ToString(), format, CultureInfo.InvariantCulture);
                Console.WriteLine(currentDate.ToString("dd.MM.yyyy", new CultureInfo("en-CA")));
            }
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

    static MatchCollection GetDates(string text)
    {
        if (text == null)
            throw new ApplicationException("You have given text with null value.");

        MatchCollection dates = Regex.Matches(text, @"(0?[1-9]|[12][0-9]|3[01])[.](0?[1-9]|1[012])[.]\d{4}");

        return dates;
    }
}
