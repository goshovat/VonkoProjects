using System;
using System.Collections.Generic;

namespace CongressHallSchedule
{
    class EndComparer : IComparer<Event>
    {
        public int Compare(Event event1, Event event2)
        {
            return event1.End.CompareTo(event2.End);
        }
    }
}
