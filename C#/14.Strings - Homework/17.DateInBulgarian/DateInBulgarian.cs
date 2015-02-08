using System;
using System.Globalization;
using System.Text;

class DateInBulgarian
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Input date and time in the appropriate format dd.mm.yyyy hh:mm:ss");
        string input = Console.ReadLine();
        string format = "d.MM.yyyy HH:mm:ss";

        DateTime currentTime = DateTime.ParseExact(input, format, CultureInfo.InvariantCulture);
        DateTime newTime = currentTime.AddHours(6).AddMinutes(30);

        Console.WriteLine("The time after 6 hours and 30 minutes will be: ");
        Console.WriteLine("{0:d.MM.yyyy HH:mm:ss}", newTime);
        Console.WriteLine("The day in Bulgarian is: " + newTime.ToString("dddd", new CultureInfo("bg-BG")));
    }
}
