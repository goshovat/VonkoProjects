using System;
using System.Collections.Generic;

class MostFrequentNumber
{
    static void Main()
    {
        int[] testArray = { 4, 1, 1, 1 ,1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 };

        int len = testArray.Length;

        //create an array to store the how many times is met the element on each position

        int[] lensArray = new int[len];
        for (int i = 0; i < len; i++)
        {
            lensArray[i] = 1;
        }

        for (int i = 0; i < len - 1; i++)
        {
            int currentElement = testArray[i];

            for (int j = i + 1; j < len; j++)
            {
                if (testArray[j] == currentElement && lensArray[j] <= lensArray[i])
                {
                    lensArray[j]++;
                }
            }
        }

        //pick the index of the most frequent element
        int maxIndex = 0;
        int maxCount = lensArray[0];
        List<int> maxIndexesList = new List<int>();

        for (int i = 0; i < len; i++)
        {
            if (lensArray[i] > maxCount)
            {
                maxIndex = i;
                maxCount = lensArray[i];

                maxIndexesList.Clear();
                maxIndexesList.Add(maxIndex);
            }
        }

        //we continue from the first encouter of the index with biggest count; to find if there are others of the same count
        for (int i = maxIndex + 1; i < len; i++)
		{
			 if (lensArray[i] == maxCount) 
             {
                 maxIndexesList.Add(i);
             }
		}

        //print the result
        for (int i = 0; i < maxIndexesList.Count; i++) 
        {
            maxIndex = maxIndexesList[i];

            for (int j = 0; j < maxCount; j++)
            {
                Console.Write(testArray[maxIndex] + " ");
            }
            Console.WriteLine();
        }
    }
}

