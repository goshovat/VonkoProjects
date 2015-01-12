namespace InvalidRangeException
{
    using System;

    public class InvalidRangeException<T> : System.ApplicationException
        where T : IComparable<T>
    {
        public T Min { get; private set; }
        public T Max { get; private set; }

        public InvalidRangeException(string message, Exception innerExc, T min, T max)
            : base(message, innerExc) 
        {
            if (min.CompareTo(max) >= 0)
                throw new ArgumentException("The min value must be greater to the max value.");

            this.Min = min;
            this.Max = max;
        }

        public InvalidRangeException(string message, T min, T max)
            : this(message, null, min, max)
        {
        }

        public override string Message
        {
            get
            {
                return string.Format("{0}, min value: {1}, max value: {2}.", 
                    base.Message, this.Min, this.Max);
            }
        }
    }
}
