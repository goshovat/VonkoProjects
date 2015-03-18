namespace InvalidRangeException
{
    using System;

    public class TestClass
    {
        public int Number { get; private set; }
        public DateTime Date { get; private set; }

        public TestClass(int number, DateTime date)
        {
            if (number < 1 || number > 100)
                throw new InvalidRangeException<int>("The number is otside of the range", 1, 100);

            //demonstrate how it will work with an inner exception
            try
            {
                if (date == default(DateTime))
                    throw new ArgumentException("The date cannot be null.");

                if (date.CompareTo(new DateTime(1980, 1, 1)) < 0
                || date.CompareTo(new DateTime(2013, 12, 30)) > 0)
                    throw new InvalidRangeException<DateTime>("The date is outside of the range",
                        new DateTime(1980, 1, 1), new DateTime(2013, 12, 30));
            }
            catch (ArgumentException applExc)
            {
                throw new InvalidRangeException<DateTime>("The date is outside of the range",
                    applExc, new DateTime(1980, 1, 1), new DateTime(2013, 12, 30));
            }

            this.Number = number;
            this.Date = date;
        }
    }
}
