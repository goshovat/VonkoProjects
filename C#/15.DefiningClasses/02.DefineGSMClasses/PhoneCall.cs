using System;

namespace GSM
{
    public class PhoneCall
    {
        private DateTime startDateTime;
        private DateTime duration;

        //define the constructor
        public PhoneCall(DateTime startDateTime, DateTime duration)
        {
            this.startDateTime = startDateTime;
            this.duration = duration;
        }

        //define properties to access the date and time
        public DateTime StartDate
        {
            get { return this.startDateTime; }
        }

        public DateTime Duration
        {
            get { return this.duration; }
        }

        //these property is only for user reference
        public string StartTime
        {
            get { return this.startDateTime.TimeOfDay.ToString(); }
        }
    }
}
