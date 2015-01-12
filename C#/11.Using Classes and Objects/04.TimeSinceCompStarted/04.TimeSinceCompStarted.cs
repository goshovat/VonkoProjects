using System;
using System.Numerics;

class TimeSinceCompStarted
{
    static void Main()
    {
        DateTime result = CheckTime();

        Console.WriteLine("Days: {0}, Hours: {1}, Minutes: {2}, Seconds: {3}", result.Day, result.Hour, result.Minute, result.Second);
    }

    static DateTime CheckTime()
    {
        int seconds = Environment.TickCount / 1000;
        int minutes = 0;
        int hours = 0;
        int days = 0;

        if (seconds > 60)
        {
            minutes = seconds / 60;
            seconds -= minutes * 60;
        }

        if (minutes > 60)
        {
            hours = minutes / 60;
            minutes -= hours * 60;
        }

        if (hours > 24)
        {
            days = hours / 24;
            hours -= days * 24;
        }

        DateTime result = new DateTime(1, 1, days, hours, minutes, seconds);

        return result;
    }
}

