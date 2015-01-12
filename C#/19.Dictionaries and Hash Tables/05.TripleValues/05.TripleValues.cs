using System;
using System.Collections.Generic;

namespace TripleValues
{
    class TripleValuesTest
    {
        static void Main()
        {
            try
            {
                DoubleKeyHashTable<string, double> averageMarks = new DoubleKeyHashTable<string, double>();
                averageMarks["goshko", "vonko"] = 4.5;
                Console.WriteLine(averageMarks["goshko", "vonko"]);

                averageMarks.Add("conko", "pepa", 2.5);
                Console.WriteLine(averageMarks["conko", "pepa"]);

                averageMarks["conko", "pepa"] = 7;
                Console.WriteLine(averageMarks["conko", "pepa"]);
            }
            catch (ApplicationException applExc)
            {
                Console.WriteLine(applExc.Message);
            }
        }
    }
}
