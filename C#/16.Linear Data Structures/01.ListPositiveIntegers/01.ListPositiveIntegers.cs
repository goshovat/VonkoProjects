using System;
using System.Collections.Generic;

namespace ListPositiveIntegers
{
    class ListPositiveIntegers
    {
        static void Main()
        {
            List<uint> integerList = new List<uint>();
            Console.WriteLine("Input a positive integer, and press enter. If you like to end the sequence press enter witout inputing anything:");
            uint sum = 0;
            double mean = 0;

            try
            {
                string input = Console.ReadLine();

                while (input != "")
                {
                    integerList.Add(uint.Parse(input));
                    input = Console.ReadLine();
                    sum += integerList[integerList.Count - 1];
                }

                mean = (double)sum / integerList.Count;
            }
            catch (FormatException formatExc)
            {
                Console.WriteLine(formatExc.Message);
                Console.WriteLine(formatExc.StackTrace);
            }
            catch (OverflowException overflowExc)
            {
                Console.WriteLine(overflowExc.Message);
                Console.WriteLine(overflowExc.StackTrace);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }

            Console.WriteLine("The sum is: {0}", sum);
            Console.WriteLine("The mean is: {0:N2}", mean);
        }
    }
}
