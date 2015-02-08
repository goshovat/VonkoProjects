using System;

class Workdays
{
    static DateTime[] officialHolidays;
    static DateTime[] workingSaturdays;

    static void Main()
    {
        DateTime currentDate = DateTime.Today;
        DateTime targetDate = new DateTime(2015, 4, 23);

        officialHolidays = new DateTime[] { new DateTime(2015, 4, 3), new DateTime(2015, 4, 30), 
            new DateTime(2015, 3, 15), new DateTime(2015, 3, 25), new DateTime(2015, 3, 10) };
        workingSaturdays = new DateTime[] { new DateTime(2015, 2, 6), 
            new DateTime(2015, 3, 4), new DateTime(2015, 3, 1) };

        int workingDays = CalculateWorkingDays(currentDate, targetDate);

        Console.WriteLine(workingDays);
    }

    static int CalculateWorkingDays(DateTime currentDate, DateTime targetDate)
    {
        int currentDayOfYear = currentDate.DayOfYear;
        int targetDayOfYear = targetDate.DayOfYear;

        int workingDays = 0;

        for (DateTime date = currentDate; date <= targetDate; date = date.AddDays(1))
        {
            if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday
                && Array.IndexOf(officialHolidays, date) == -1)
            {
                workingDays++;
            }
        }
        return workingDays;
    }
}
