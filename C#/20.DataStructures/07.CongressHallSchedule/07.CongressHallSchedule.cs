using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

namespace CongressHallSchedule
{
    class CongressHallSchedule
    {
        static IComparer<Event> startComp = new StartComparer();
        static IComparer<Event> endComp = new EndComparer();

        static void Main()
        {
            //hardcode a few events
            //the hall can take more than 1 event in the same time
            //we want to check is it completely free in some interval
            Event event1 = new Event(
                "Seminar Yoga", new DateTime(2014, 11, 20, 09, 15, 56), 
                new DateTime(2014, 11, 20, 09, 55, 40));
            Event event2 = new Event(
                 "Sex Seminar", new DateTime(2014, 11, 20, 09, 00, 00),
                 new DateTime(2014, 11, 20, 09, 30, 00)
                );
            Event event3 = new Event(
                "Fitness conference", new DateTime(2014, 11, 20, 11, 00, 00),
                new DateTime(2014, 11, 20, 11, 30, 00)
                );
            Event event4 = new Event(
                "NLP training", new DateTime(2014, 11, 20, 08, 00, 00),
                new DateTime(2014, 11, 20, 10, 30, 00)
                );

            //the moments between which we need to check the schedule
            DateTime intervalStart = new DateTime(2014, 11, 20, 10, 00, 00);
            DateTime intervalEnd = new DateTime(2014, 11, 20, 11, 00, 00);

            ICollection<Event> eventsCollection
                = new Event[] { event1, event2, event3, event4 };

            bool hallIsFree = IsTheHallFree(eventsCollection, intervalStart, intervalEnd);

            Console.WriteLine("Is the hall free? {0}", hallIsFree ? "Yes" : "No");
        }

        private static bool IsTheHallFree(ICollection<Event> eventsCollection, DateTime intervalStart, DateTime intervalEnd)
        {
            List<Event> startList = new List<Event>(eventsCollection);
            List<Event> endList = new List<Event>(eventsCollection);

            Console.WriteLine("All events: ");
            startList.Sort(startComp);
            PrintCollection(startList);

            endList.Sort(endComp);
            //PrintCollection(endList);

            OrderedSet<Event> eventsEndedAftr =
                GetEventsEndedAftr(endList, intervalStart);

            OrderedSet<Event> eventsStartedBfr =
                GetEventsStartedBfr(startList, intervalEnd);

            OrderedSet<Event> obstructingEvents = eventsEndedAftr;
            obstructingEvents.IntersectionWith(eventsStartedBfr);

            Console.WriteLine("Obstructing events: ");
            PrintCollection(new List<Event>(obstructingEvents));

            if (obstructingEvents.Count == 0)
                return true;
            else 
                return false;
        }

        //this method will return all events ended after given moment
        private static OrderedSet<Event> GetEventsEndedAftr(
            List<Event> givenList, DateTime goal)
        {
            if (givenList.Count == 0)
                throw new ApplicationException("Error! The list is empty.");

            OrderedSet<Event> resultSet = new OrderedSet<Event>(endComp);

            int lowEnd = 0;
            int highEnd = givenList.Count - 1;
            int testPsn = 0;

            while (highEnd > lowEnd)
            {
                testPsn = lowEnd + ((highEnd - lowEnd) / 2);
                if (givenList[testPsn].End.CompareTo(goal) > 0)
                    highEnd = testPsn;
                else
                    lowEnd = testPsn + 1;
            }

            for (int i = lowEnd; i < givenList.Count; i++)
                resultSet.Add(givenList[i]);

            return resultSet;
        }

        //this method will return all events started before given moment
        private static OrderedSet<Event> GetEventsStartedBfr(
            List<Event> givenList, DateTime goal)
        {
            if (givenList.Count == 0)
                throw new ApplicationException("Error! The list is empty.");

            //need to use endComp in order to be able to intersect the sets after
            OrderedSet<Event> resultSet = new OrderedSet<Event>(endComp);

            int lowEnd = 0;
            int highEnd = givenList.Count - 1;
            int testPsn = 0;

            while (highEnd > lowEnd)
            {
                testPsn = lowEnd + ((highEnd - lowEnd) / 2);
                if (givenList[testPsn].Start.CompareTo(goal) < 0)
                    lowEnd = testPsn + 1;
                else
                    highEnd = testPsn;
            }

            for (int i = 0; i < lowEnd; i++)
                resultSet.Add(givenList[i]);

            return resultSet;
        }

        public static void PrintCollection(List<Event> collection) 
        {
            foreach (Event item in collection)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(new string('-', 50));
            Console.WriteLine();
        }
    }
}
