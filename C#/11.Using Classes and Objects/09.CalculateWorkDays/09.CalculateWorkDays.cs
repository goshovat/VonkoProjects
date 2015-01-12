using System;

class CalculateWorkDays
{
    static DateTime[] officialHolidays;
    static DateTime[] workingSaturdays;

    static void Main()
    {
        DateTime currentDate = DateTime.Today;
        DateTime targetDate = new DateTime(2014, 11, 23);

        officialHolidays = new DateTime[] { new DateTime(2014, 9, 3), new DateTime(2014, 9, 30), new DateTime(2014, 10, 15), new DateTime(2014, 10, 25), new DateTime(2014, 11, 10) };
        workingSaturdays = new DateTime[] { new DateTime(2014, 9, 6), new DateTime(2014, 10, 4), new DateTime(2014, 11, 1) };

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

            if (date.DayOfWeek == DayOfWeek.Saturday && Array.IndexOf(workingSaturdays, date) != -1) 
            {
                workingDays++;
            }
        }

        return workingDays;
    }
}