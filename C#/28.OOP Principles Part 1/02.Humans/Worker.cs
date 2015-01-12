namespace Humans
{
    using System;

    public class Worker : Human
    {
        public double WeekSalary { get; private set; }
        public int WorkHoursPerDay { get; private set; }

        public Worker
            (string firstName, string lastName, double weekSalary, int workHoursPerDay)
            :base(firstName, lastName)
        {
            if (weekSalary < 0)
                throw new ArgumentException("Week salary cannot be negative.");

            if (workHoursPerDay < 0)
                throw new ArgumentException("Work hours per day cannot be negative");

            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public double CalculateMoneyPerHour()
        {
            return (this.WeekSalary / 7 ) / this.WorkHoursPerDay;
        }

        public override string ToString()
        {
            return string.Format("Worker: {0} {1} Pay per hour: {2:N2}"
                , base.FirstName, base.LastName, this.CalculateMoneyPerHour());
        }
    }
}
