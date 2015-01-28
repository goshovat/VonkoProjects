using System;

class BeerTime
{
    static void Main()
    {
        Console.WriteLine("Enter time in the format '1:00 PM':");
        string input = Console.ReadLine();
        string[] entities = input.Split(new char[] { ':', ' ' },
            StringSplitOptions.RemoveEmptyEntries);
        int hours = 0;
        int minutes = 0;
        DateTime beerTimeStart = new DateTime(2013, 01, 14, 13, 0, 0);
        DateTime beerTimeEnd = new DateTime(2013, 01, 14, 3, 0, 0);

        if (entities.Length < 3 || !int.TryParse(entities[0], out hours)
            || hours < 1 || hours > 12 || !int.TryParse(entities[1], out minutes)
            || minutes < 0 || minutes > 59 || (entities[2] != "AM" && entities[2] != "PM"))
        {
            Console.WriteLine("Invalid time");
        }
        else
        {
            if (entities[2] == "PM")
            {
                hours += 12;
            }

            DateTime time = new DateTime(2013, 01, 14, hours, minutes, 0);

            if (time.CompareTo(beerTimeStart) > 0
                || time.CompareTo(beerTimeEnd) < 0)
            {
                Console.WriteLine("Beer time.");
            }
            else
            {
                Console.WriteLine("Non-beer time.");
            }
        }
    }
}

