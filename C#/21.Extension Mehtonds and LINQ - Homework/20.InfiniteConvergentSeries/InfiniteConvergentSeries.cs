using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfiniteConvergentSeries
{
    class InfiniteConvergentSeries
    {
        static void Main()
        {
            Console.WriteLine(Sum(m => 1/ (decimal)Math.Pow(2, m-1)));
            Console.WriteLine(Sum(m => 1m/Enumerable.Range(1, m).Aggregate((a, b) => a * b)));
            Console.WriteLine(Sum(m => -1 /(decimal)Math.Pow(-2, m-1)));
        }

        private static decimal Sum(Func<int, decimal> function)
        {
            decimal sum = 1;

            for (int i = 2; Math.Abs(function(i)) > 0.01m; i++)
            {
                sum += function(i);
            }

            return sum;
        }
    }
}
