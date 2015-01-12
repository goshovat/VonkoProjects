using System;
using System.Collections.Generic;

namespace RemoveNegativeNumbers
{
    class RemoveNegativeNumbers
    {
        static void Main()
        {
            int[] givenArray = new int[] { 19, -10, 12, -6, -3, 34, -2, 5 };

            List<int> positiveNumbers = new List<int>();

            for (int i = 0; i < givenArray.Length; i++)
            {
                if (givenArray[i] > 0)
                    positiveNumbers.Add(givenArray[i]);
            }

            Console.WriteLine("The positive numbers are: ");
            foreach (int number in positiveNumbers)
                Console.Write(number + " ");

            Console.WriteLine();
        }
    }
}
