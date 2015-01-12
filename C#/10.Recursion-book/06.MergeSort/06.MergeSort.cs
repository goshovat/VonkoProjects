using System;
using System.Collections.Generic;

class MergeSortAlgorithm
{
    static void Main()
    {
        int[] arrayToSort = new int[] {1, -6, 7, 9, 10, 15, -99, -1000, 54, 100, 54, 200, 54, 0, 1001, -1000, 500};

        List<int> arrayInList = new List<int>(arrayToSort);

        List<int> result = MergeSort(arrayInList);

        Console.WriteLine("The sorted list is:\n\r{0}", string.Join(" ", result));
    }

    //this is the recursive method for the merge sort algorithm
    static List<int> MergeSort(List<int> list)
    {
        if (list.Count == 1)
            return list;

        List<int> leftList = new List<int>();
        List<int> rightList = new List<int>();

        for (int i = 0; i < list.Count; i++)
        {
            if (i < list.Count / 2)
            {
                leftList.Add(list[i]);
            }
            else
            {
                rightList.Add(list[i]);
            }
        }

        leftList = MergeSort(leftList);
        rightList = MergeSort(rightList);

        return Merge(leftList, rightList);
    }

    //this method will merge two already sorted lists
    static List<int> Merge(List<int> leftList, List<int> rightList)
    {
        List<int> result = new List<int>();

        while(leftList.Count > 0|| rightList.Count > 0) 
        {
            if (leftList.Count > 0 && rightList.Count > 0) 
            {
                if (leftList[0] < rightList[0]) 
                {
                    result.Add(leftList[0]);
                    leftList.RemoveAt(0);
                }
                else 
                {
                    result.Add(rightList[0]);
                    rightList.RemoveAt(0);
                }
            }
            else if (leftList.Count > 0) 
            {
                result.Add(leftList[0]);
                leftList.RemoveAt(0);
            }
            else if (rightList.Count > 0) 
            {
                result.Add(rightList[0]);
                rightList.RemoveAt(0);
            }
        }

        return result;
    }
}
