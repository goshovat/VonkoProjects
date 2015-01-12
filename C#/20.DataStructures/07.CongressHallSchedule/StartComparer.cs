using System;
using System.Collections.Generic;

namespace CongressHallSchedule
{
    class StartComparer : IComparer<Event>
    {
        public int Compare(Event event1, Event event2)
        {
            return event1.Start.CompareTo(event2.Start);
        }
    }
}
