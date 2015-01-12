namespace IEnumerableExtensionMethods
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class IEnumerableExtensions 
    {
        public static T SumAll<T>(this IEnumerable<T> numbers)
        {
            decimal result = 0;

            foreach (dynamic item in numbers)
                result += (decimal)item;

            return (T)(dynamic)result;
        }

        public static T ProductAll<T>(this IEnumerable<T> numbers)
        {
            decimal result = 1;

            foreach (dynamic item in numbers)
                result *= (decimal)item;

            return (T)(dynamic)result;
        }

        public static T MinAll<T>(this IEnumerable<T> numbers)
            where T : IComparable<T>
        {
            if (numbers.Count() == 0)
                throw new ArgumentException("Cannot estimate min value of empty collection.");

            //check the type so there is no overflowing for the max value
            T minValue = numbers.First();

            foreach (T item in numbers)
            {
                if (item.CompareTo(minValue) < 0)
                    minValue = item;
            }

            return (T)(dynamic)minValue;
        }

        public static T MaxAll<T>(this IEnumerable<T> numbers)
            where T : IComparable<T>
        {
            if (numbers.Count() == 0)
                throw new ArgumentException("Cannot estimate max value of empty collection.");

            T maxValue = numbers.First();

            foreach (T item in numbers)
            {
                if (item.CompareTo(maxValue) > 0)
                    maxValue = item;
            }

            return (T)(dynamic)maxValue;
        }

        public static T AverageAll<T>(this IEnumerable<T> numbers)
             where T : IComparable<T>
        {
            if (numbers.Count() == 0)
                throw new ArgumentException("Cannot estimate average value of empty collection.");

            decimal sum = 0;
            int count = 0;

            foreach (dynamic item in numbers)
            {
                sum += (decimal)item;
                count++;
            }

            return (T)(dynamic)(sum / (decimal)count);
        }
    }
}
