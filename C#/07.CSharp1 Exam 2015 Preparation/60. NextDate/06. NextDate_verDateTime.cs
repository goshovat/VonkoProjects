using System;

class NextDate_verDateTime
{
    static void Main()
    {
        int day = int.Parse(Console.ReadLine());
        int month = int.Parse(Console.ReadLine());
        int year = int.Parse(Console.ReadLine());

        DateTime currentDate = new DateTime(year, month, day);
        DateTime tomorrow = currentDate.AddDays(1);

        int tomorrowDay = (int)tomorrow.Day;
        int tomorrowMonth = (int)tomorrow.Month;
        int tomorrowYear = (int)tomorrow.Year;

        Console.WriteLine(tomorrowDay + "." + tomorrowMonth + "." + tomorrowYear);
    }
}

