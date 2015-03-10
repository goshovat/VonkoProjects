namespace MobilePhone
{
    using System;

    public class Call
    {
        private int duration;

        public Call(DateTime date, int duration, ulong dialedNumber)
        {
            this.Date = date;
            this.Duration = duration;
            this.DialedNumber = DialedNumber;
        }

        public DateTime Date { get; private set; }
        public TimeSpan Time
        {
            get { return this.Date.TimeOfDay; }
        }
        public int Duration
        {
            get { return this.duration; }
            private set
            {
                if (this.duration < 0)
                    throw new ArgumentException("Call duration cannog be negative");

                this.duration = value;
            }
        }
        public ulong DialedNumber { get; private set; }

        public override string ToString()
        {
            return string.Format(
                "{0}, {1} seconds, {2}", this.Date, this.Duration, this.DialedNumber);
        }
    }
}
