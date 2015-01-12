using System;

class LeapYear
{
    static void Main()
    {
        DateTime today = DateTime.Now;

        bool isYearFull = CheckYear(today);

        Console.WriteLine("The year is leap: {0}", isYearFull);
    }

    static bool CheckYear(DateTime today)
    {
        if (today.Year % 4 == 0)
        {
            return true;
        }
        return false;
    }
}
