using System;
using System.Collections.Generic;

namespace MajorNumber
{
    class MajorNumber
    {
        static void Main()
        {
            int[] givenArray = { 1, 2, 3, 3, 3, 3, 2, 2, 3, 2, 1, 3, 3};

            Array.Sort(givenArray);

            int currentOccurences = 0;
            int majorOccurences = givenArray.Length / 2 + 1;
            int currentElement = givenArray[0];

            for (int i = 1; i < givenArray.Length; i++)
            {
                if (givenArray[i] == currentElement)
                {
                    currentOccurences++;
                }
                else
                {
                    if (i >= majorOccurences)
                    {
                        break;
                    }

                    currentElement = givenArray[i];
                    currentOccurences = 1;
                }

                if (currentOccurences == majorOccurences)
                {
                    Console.WriteLine("The major element is: {0}", currentElement);
                    return;
                }
            }

            Console.WriteLine("No major element found!");
        }
    }
}
