//I tested the VS Unit Test Framework. To Run the Tests you need to
// got to the MENU - > TESTs - > Run -> All tests

namespace MobilePhone
{
    using System;
    using System.Collections.Generic;

    public class GSM
    {
        public static GSM iPhone4S;
        //they will not be accessible as static members of GSM, but as public properties
        //of the static member Iphone4s
        private List<Call> callHistory;
        private static Battery iPhoneBattery;
        private static Display iPhoneDisplay;
        private double price;

        static GSM()
        {
            //initialize the static fields
            GSM.iPhoneBattery = new Battery(10, 23, BatteryType.LiIOn);
            GSM.iPhoneDisplay = new Display(3.5, 16000000);
            GSM.iPhone4S = new GSM("Apple", "Iphone 4S", 600, null, iPhoneBattery, iPhoneDisplay);
        }
 
        public GSM
            (string manufacturer, string model, double price, Person owner, Battery battery, Display display)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Price = price;
            this.Owner = owner;
            this.Battery = battery;
            this.Display = display;
            this.callHistory = new List<Call>();
        }

        public GSM(string manufacturer, string model, double price, Person owner) :
            this(manufacturer, model, price, owner, null, null) { }

        public GSM(string manufacturer, string model, double price) :
            this(manufacturer, model, price, null) { }

        //it is not logical to initialize the price be default to 0
        public GSM(string manufacturer, string model)
            : this(manufacturer, model, 500) { }

        public string Manufacturer { get; private set; }
        public string Model { get; private set; }
        public double Price
        {
            get { return this.price; }
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Error! GSM Price cannot be negative.");

                this.price = value;
            }
        }
        public Person Owner { get; private set; }
        public Battery Battery { get; private set; }
        public Display Display { get; private set; }
        public int NumberCalls { get { return this.callHistory.Count; } }

        public void MakeCall(DateTime date, int duration, ulong dialedNumber)
        {
            this.callHistory.Add(new Call(date, duration, dialedNumber));
        }

        public Call GetCallNumber(int number)
        {
            if (number >= this.callHistory.Count)
                throw new ArgumentException("Error! There is no such call in the history");

            return this.callHistory[number];
        }

        public void DeleteCallNumber(int number)
        {
            if (number >= this.callHistory.Count)
                throw new ArgumentException("Error! There is no such call in the history");

            this.callHistory.RemoveAt(number);
        }

        public void DeleteLongestCall()
        {
            int longestIndex = 0;
            int maxDuration = 0;

            for (int i = 0; i < this.callHistory.Count; i++) 
            {
                if (callHistory[i].Duration > maxDuration)
                {
                    maxDuration = callHistory[i].Duration;
                    longestIndex = i;
                }
            }
            this.DeleteCallNumber(longestIndex);
        }

        public void ClearHistory()
        {
            this.callHistory = new List<Call>();
        }

        public double CalculateCurrentBill(double pricePerMinute)
        {
            if (pricePerMinute < 0)
                throw new ArgumentException("Error! Price per minute cannot be negative");

            int resultDuration = 0;
            foreach (Call call in callHistory)
            {
                resultDuration += call.Duration;
            }
            string priceString = string.Format("{0:N2}", resultDuration / 60.0 * pricePerMinute);
            return double.Parse(priceString);
        }

        public void PrintCallHistory()
        {
            foreach(Call call in callHistory)
                Console.WriteLine(call);
        }

        public override string ToString()
        {
            return string.Format("{0} {1}\nBattery: {2}\nDisplay: {3}\nPrice: {4}\nOwner: {5}",
                this.Manufacturer, this.Model, this.Battery, this.Display, this.Price, this.Owner);
        }
    }
}
