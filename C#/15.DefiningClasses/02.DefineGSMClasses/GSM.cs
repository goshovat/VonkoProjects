using System;
using System.Collections.Generic;
using System.Text;

namespace GSM
{
    public class GSM
    {
        //the static field for nokia N95
        static private Display N95Display = new Display(9, 241241);
        static private Battery N95Battery = new Battery(BatteryType.LiIon, "N-95 Batt1", 32, 6);
        static private GSM nokiaN95 = new GSM("Nokia", "N95", 30d, new Owner(), N95Display, N95Battery);

        //the instance fields of the class
        private string vendor;
        private string model;
        private double price;
        private Owner owner;
        private Display display;
        private Battery battery;
        private List<PhoneCall> callHistory = new List<PhoneCall>();

        //constructor of the outter class
        public GSM()
            : this(null, null)
        {
        }

        public GSM(string vendor, string model)
            : this(vendor, model, 0, null, null)
        {
        }

        public GSM(string vendor, string model, double price, Display display, Battery battery)
            : this(vendor, model, price, null, display, battery)
        {
        }

        public GSM(string vendor, string model, double price, Owner owner,
            Display display, Battery battery)
        {
            this.vendor = vendor;
            this.model = model;
            this.price = price;
            this.owner = owner;
            this.display = display;
            this.battery = battery;
        }

        //define properties of GSM class
        //every other property of the phone can be changed except vendor and mode;
        public Display Displai
        {
            get { return this.display; }
            set { this.display = value; }
        }

        public string Vendor
        {
            get { return this.vendor; }
        }

        public string Model
        {
            get { return this.model; }
        }

        public double Price
        {
            get { return this.price; }
            set { this.price = value; }
        }

        public Owner Owner
        {
            get { return this.owner; }
            set { this.owner = value; }
        }

        public Battery Batery
        {
            get { return this.battery; }
            set { this.battery = value; }
        }

        public List<PhoneCall> ArchiveList
        {
            get { return this.callHistory; }
        }

        //static method to give info for N95
        public static void PrintInfoN95()
        {
            Console.WriteLine("Info about Nokia N95: ");
            Console.WriteLine("The vendor of the phone is: {0}.", GSM.nokiaN95.vendor);
            Console.WriteLine("The model of the phone is: {0}", GSM.nokiaN95.model);
            Console.WriteLine("The price of the phone is: {0}", GSM.nokiaN95.price);
            Console.WriteLine("The owner of the phone is: {0}", GSM.nokiaN95.owner.Name);
            Console.WriteLine("The display of the phone is: {0} inches", GSM.nokiaN95.display.DisplaySize);
            Console.WriteLine("The battery of the phone is: {0}", GSM.nokiaN95.battery.BatteryModel);
            Console.WriteLine();
        }

        //intance methods of the GSM class
        public void AddCall(PhoneCall item)
        {
            callHistory.Add(item);
        }

        //this method will erase the first encounter of the given call
        public void EraseCall(PhoneCall item)
        {
            callHistory.Remove(item);
        }

        //this method will erase all calls in the archive
        public void EraseAllCalls()
        {
            callHistory.Clear();
        }

        //this method will return the price of all phone calls
        public double CheckBill(double singleCallPrice)
        {
            DateTime totalDuration = new DateTime(1, 1, 1, 0, 0, 0);

            foreach (PhoneCall call in this.callHistory)
            {
                totalDuration = totalDuration.AddHours(call.Duration.Hour);
                totalDuration = totalDuration.AddMinutes(call.Duration.Minute);
                totalDuration = totalDuration.AddSeconds(call.Duration.Second);               
            }

            //get the number of minutes for taxing
            int minutes = totalDuration.Hour * 60 + totalDuration.Minute;

            if (totalDuration.Second != 0)
            {
                minutes += 1;
            }

            return minutes * singleCallPrice;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(string.Format("Brand of the GSM: {0}\nModel: {1}\nPrice: {2}\n",
                this.vendor, this.model, this.price));

            if (this.owner != null)
                result.Append(string.Format("Owner :{0}\n", this.owner.Name));
            if (this.display != null)
                result.Append(string.Format("Display size: {0}\n", this.display.DisplaySize));
            if (this.battery != null)
                result.Append(string.Format("Battery model: {0}\n\n", this.battery.BatteryModel));

            return result.ToString();
        }

        //we create nested classes for the battery and display
        public class Display
        {
            private double displaySize;
            private int colors;

            //define constructors for the display
            public Display()
                : this(0.0)
            {
            }

            public Display(double size)
                : this(size, 0)
            {
            }

            public Display(double displaySize, int colors)
            {
                this.displaySize = displaySize;
                this.colors = colors;
            }

            //define properties
            //we cannot change the display with one of different size, but we can put
            //fake Turkish display with less colors
            public double DisplaySize
            {
                get { return this.displaySize; }
            }

            public int Colors
            {
                get { return this.colors; }
                set { this.colors = value; }
            }
        }

        public class Battery
        {
            private BatteryType batteryType;
            private string batteryModel;
            private double idleTime;
            private double hoursTalk;

            //define properties
            //we can change the battery of the phone with completely different one
            public BatteryType BatteryType
            {
                get { return this.batteryType; }
                set { this.batteryType = value; }
            }

            public string BatteryModel
            {
                get { return this.batteryModel; }
                set { this.batteryModel = value; }
            }

            public double IdleTime
            {
                get { return this.idleTime; }
                set { this.idleTime = value; }
            }

            public double HoursTalk
            {
                get { return this.hoursTalk; }
                set { this.hoursTalk = value; }
            }

            //define constructors for the battery class
            public Battery()
                : this(0)
            {
            }

            public Battery(BatteryType batteryType)
                : this(batteryType, null, 0, 0)
            {
            }

            public Battery(BatteryType batteryType, string batteryModel, double idleTime, double hoursTalk)
            {
                this.batteryType = batteryType;
                this.batteryModel = batteryModel;
                this.idleTime = idleTime;
                this.hoursTalk = hoursTalk;
            }
        }
    }
}
