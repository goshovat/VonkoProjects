using System;

namespace Humans
{
    class Worker : Human
    {
        private double hoursWorked;
        private double totalEarninngs;

        public Worker(string givenName, string familyName)
        {
            base.givenName = givenName;
            base.familyName = familyName;
        }

        public double HoursWorked
        {
            get { return this.hoursWorked; }
            set { this.hoursWorked = value; }
        }

        public double TotalEarnings
        {
            get { return this.totalEarninngs; }
            set { this.totalEarninngs = value; }
        }

        public double CalculateEarningPerHour() 
        {
            if (this.hoursWorked == 0)
                return 0;

            double result = this.totalEarninngs / this.hoursWorked;
            return double.Parse(string.Format("{0:N2}", result));
        }

        public override int CompareTo(Human otherWorker)
        {
            Worker worker = (Worker)otherWorker;

            if (this.CalculateEarningPerHour() > worker.CalculateEarningPerHour())
                return 1;
            else if (this.CalculateEarningPerHour() < worker.CalculateEarningPerHour())
                return -1;
            else
                return 0;
        }

        public override void PrintPersonInfo()
        {
            Console.WriteLine("Worker: {0} {1}; Earnings per hour-> {2:N2}",
                    this.givenName, this.familyName, this.CalculateEarningPerHour());
        }
    }
}
