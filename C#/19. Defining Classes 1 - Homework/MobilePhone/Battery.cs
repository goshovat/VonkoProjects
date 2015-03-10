namespace MobilePhone
{
    using System;

    public class Battery
    {
        private int hoursIdle;
        private int hoursTalk;
     
        public Battery(int hoursIdle, int hoursTalk, BatteryType batteryType)
        {
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
            this.BatteryType = batteryType;
        }

        public Battery(int hoursIdle, int hoursTalk) :
            this(hoursIdle, hoursTalk, BatteryType.LiIOn) { }

        //it is not logical to initialize be default the hours to 0
        public Battery() : this(10, 5) { }

        public string Model { get; set; }
        public int HoursIdle
        {
            get { return this.hoursIdle; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Error! Hours Idle must be positive.");

                this.hoursIdle = value;
            }
        }
        public int HoursTalk
        {
            get { return this.hoursTalk; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Error! Hours Talk must be positive.");
                this.hoursTalk = value;
            }
        }
        public BatteryType BatteryType { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {1} hours idle, {2} hours talk",
                this.BatteryType, this.HoursIdle, this.HoursTalk);
        }
    }
}
