using System;
using System.Collections.Generic;

namespace SearchEngine
{
    class YearComparer:IComparer<Car>
    {
        public int Compare(Car car1, Car car2)
        {
            return car1.Year.CompareTo(car2.Year);
        }
    }
}
