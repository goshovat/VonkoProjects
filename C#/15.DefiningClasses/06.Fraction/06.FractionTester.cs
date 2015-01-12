using System;
using System.Collections.Generic;

namespace Fraction
{
    class FractionTester
    {
        static void Main()
        {
            try
            {
                //!! different cases that will cause application exceptions defined in the class

                //TestFraction("10000000/0000000");
                //TestFraction("-20/-20");
                //TestFraction("-20/");
                //TestFraction("/2421");
                //TestFraction("2.5/3.1");
                //TestFraction("da/224");
                //TestFraction("+23/24");

                TestFraction("-214/43");
                TestFraction("24/42");
                TestFraction("2442142/21412412");
            }
            catch (ApplicationException applExc)
            {
                Console.WriteLine(applExc.Message);
                Console.WriteLine(applExc.StackTrace);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }

        public static void TestFraction(string input) 
        {
            Fraction testFraction = Fraction.Parse(input);
            Console.WriteLine(string.Format("The numerator is: {0}", testFraction.Numerator));
            Console.WriteLine(string.Format("The denominator is: {0}", testFraction.Denominator));
            Console.WriteLine(string.Format("The decimal representation is: {0}", testFraction.Decimal));
            testFraction.AbbreviateFraction();
            Console.WriteLine("The abbreviated fraction is:{0}", testFraction.ToString());
            Console.WriteLine(new string('-', 55));
        }
    }
}
