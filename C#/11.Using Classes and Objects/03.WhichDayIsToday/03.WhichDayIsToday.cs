using System;

class WhichDayIsToday
{
    static void Main()
    {
        DateTime today = DateTime.Today;

        string thisDay = CheckDay(today);

        Console.WriteLine("Today is {0}", thisDay);
    }

    static string CheckDay(DateTime today)
    {
        return Convert.ToString(today.DayOfWeek);
    }
}
