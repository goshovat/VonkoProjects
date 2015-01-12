using System;
using System.Collections.Generic;

class MergeSortAlgorithm
{
    static void Main()
    {
        int[] testArray = { 1, 990, -99, 5, 2, 8, 0, -10, -20, 30, 50, 7 };

        List<int> testArrayToList = new List<int>(testArray);

        List<int> sortedArrayList = MergeSort(testArrayToList);

        //priint the result
        for (int i = 0; i < sortedArrayList.Count; i++)
        {
            Console.Write(sortedArrayList[i] + " ");
        }
    }

    private static List<int> MergeSort(List<int> testArrayList)
    {
        if (testArrayList.Count <= 1)
        {
            return testArrayList;
        }
        else
        {
            int middle = testArrayList.Count / 2;

            List<int> leftPart = new List<int>();
            List<int> rightPart = new List<int>();

            for (int i = 0; i < testArrayList.Count; i++)
            {
                if (i < middle)
                {
                    leftPart.Add(testArrayList[i]);
                }
                else
                {
                    rightPart.Add(testArrayList[i]);
                }
            }

            leftPart = MergeSort(leftPart);
            rightPart = MergeSort(rightPart);

            return Merge(leftPart, rightPart);
        }
    }

    //this method will merge the elements att the bottom of the recursion
    private static List<int> Merge(List<int> leftPart, List<int> rightPart)
    {
        List<int> resultArray = new List<int>();

        while (leftPart.Count > 0 || rightPart.Count > 0)
        {
            if (leftPart.Count > 0 && rightPart.Count > 0)
            {
                if (leftPart[0] < rightPart[0])
                {
                    resultArray.Add(leftPart[0]);
                    leftPart.Remove(leftPart[0]);
                }
                else
                {
                    resultArray.Add(rightPart[0]);
                    rightPart.Remove(rightPart[0]);
                }
            }
            else if (leftPart.Count > 0)
            {
                resultArray.Add(leftPart[0]);
                leftPart.Remove(leftPart[0]);
            }
            else if (rightPart.Count > 0)
            {
                resultArray.Add(rightPart[0]);
                rightPart.Remove(rightPart[0]);
            }
        }

        return resultArray;
    }
}
