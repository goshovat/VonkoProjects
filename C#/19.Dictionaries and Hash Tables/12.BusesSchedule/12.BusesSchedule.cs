using System;
using System.Collections.Generic;

//the main idea of the solution is to compare the arrival and
//departure times as strings. this will give correct time coparison
//using the 24-hours time format
namespace BusesSchedule
{
    class BusesSchedule
    {
        static void Main()
        {
            //first create all the sets to be used
            HashSet<TimeInterval> busesAfter = new HashSet<TimeInterval>();
            HashSet<TimeInterval> busesBefore = new HashSet<TimeInterval>();
            HashSet<TimeInterval> busesInInterval = new HashSet<TimeInterval>();

            TimeInterval interval = new TimeInterval("[08:22-09:05]");

            //create a set of all buses to work upon
            TimeInterval[] allBuses = new TimeInterval[] {
                new TimeInterval("[08:24-08:33]"), new TimeInterval("[08:20-09:00]"), 
                new TimeInterval("[08:32-08:37]"), new TimeInterval("[09:00-09:15]")
            };

            //add all buses arriving in the interval
            AddAfter(busesAfter, interval, allBuses);
            //add all buses departuring in the interval
            AddBefore(busesBefore, interval, allBuses);

            busesInInterval.UnionWith(busesAfter);
            busesInInterval.IntersectWith(busesBefore);

            Console.WriteLine("The buses in the interval are: ");
            foreach(TimeInterval bus in busesInInterval)
                Console.WriteLine(bus);
        }

        private static void AddAfter(HashSet<TimeInterval> set, 
           TimeInterval interval,  params TimeInterval[] buses)
        {
            foreach (TimeInterval bus in buses)
                if (interval.ArrTime.CompareTo(bus.ArrTime) < 0)
                    set.Add(bus);
        }

        private static void AddBefore(HashSet<TimeInterval> set,
            TimeInterval interval, params TimeInterval[] buses)
        {
            foreach (TimeInterval bus in buses)
                if (interval.DepTime.CompareTo(bus.DepTime) > 0)
                    set.Add(bus);
        }
    }
}
