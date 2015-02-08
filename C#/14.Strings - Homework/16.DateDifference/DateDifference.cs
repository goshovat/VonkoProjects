using System;
using System.Globalization;

class DateDifference
{
    static void Main()
    {
        Console.WriteLine("Input two dates in the appropriate format dd.mm.yyyy:");
        Console.Write("Date 1: ");
        string input1 = Console.ReadLine();
        Console.Write("Date 2: ");
        string input2 = Console.ReadLine();

        string format = "d.M.yyyy";

        DateTime date1 = DateTime.ParseExact(input1, format, CultureInfo.InvariantCulture);
        DateTime date2 = DateTime.ParseExact(input2, format, CultureInfo.InvariantCulture);

        int difference = date2.DayOfYear - date1.DayOfYear;
        Console.WriteLine("Difference: {0} days", difference);
    }
}
