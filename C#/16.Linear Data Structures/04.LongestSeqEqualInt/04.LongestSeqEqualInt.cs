using System;
using System.Collections.Generic;

namespace LongestSeqEqualInt
{
    class LongestSeqEqualInt
    {
        static void Main()
        {
            List<int> givenList = new List<int>() { 1, 2, 0, 9, 4, 4, 4, 6, 6, 6, 2, 3, 10, 10, 10, 10, 3, 3, 3, 12, 12, 12, 12 };

            //catch the exeption in case you are given empty list
            try 
            {
                int longestCount = 0;
                int elementOfBiggestCount = givenList[0];

                int currentCount = 0;
                int currentElement = givenList[0];

                //find the longest count and the element using Kadan's algorithm
                for (int i = 1; i < givenList.Count; i++)
                {
                    if (givenList[i] == currentElement)
                    {
                        currentCount++;
                    }
                    else
                    {
                        currentElement = givenList[i];
                        currentCount = 1;
                    }

                    if (currentCount > longestCount)
                    {
                        longestCount = currentCount;
                        elementOfBiggestCount = currentElement;
                    }
                }

                //create with the longest count of the given element
                List<int> longestList = new List<int>();
                for (int i = 0; i < longestCount; i++)
                {
                    longestList.Add(elementOfBiggestCount);
                    Console.WriteLine(elementOfBiggestCount + " ");
                }
            }
            catch (NullReferenceException nullRef)
            {
                Console.WriteLine("You are given empty list!");
                Console.WriteLine(nullRef.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
