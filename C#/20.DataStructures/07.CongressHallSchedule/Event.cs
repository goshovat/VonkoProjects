using System;
using System.Collections.Generic;

namespace CongressHallSchedule
{
    class Event
    {
        private string name;
        private DateTime start;
        private DateTime end;

        public Event(string name, DateTime start, DateTime end)
        {
            this.name = name;
            this.start = start;
            this.end = end;
        }

        public string Name
        {
            get { return this.name; }
        }

        public DateTime Start
        {
            get { return this.start; }
        }

        public DateTime End
        {
            get { return this.end; }
        }

        public override string ToString()
        {
            return string.Format("{0}\nStart: {1}.{2}.{3} {4}:{5}:{6}\nEnd: {7}.{8}.{9} {10}:{11}:{12}\n",
                this.name, this.start.Year, this.start.Month, this.start.Day, this.start.Hour, 
                this.start.Minute, this.start.Second, this.end.Year, this.end.Month, this.end.Day, 
                this.end.Hour, this.end.Minute, this.end.Second);
        }
    }
}
