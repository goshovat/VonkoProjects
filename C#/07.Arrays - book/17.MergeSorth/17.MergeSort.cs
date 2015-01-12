using System;
using System.Collections.Generic;

class MergeSorth
{
    static void Main()
    {
        int[] myArray = { 1, 3, 99, 8, -20, -9, 4, 88, 330, 1000, -1100, -50};

        Console.WriteLine("The original array is: ");
        Console.WriteLine(String.Join(", ", myArray));

        //in this list will be transfered the original array
        List<int> myList = new List<int>();

        //put all the values from the array into the list
        FillOriginalList(myArray, myList);

        int middle = myList.Count / 2;

        List<int> resultList = MergeSort(myList);

        Console.WriteLine("The arranged array is: ");

        Print(resultList);
    }

    //define the method that will implement the algorithm
    static List<int> MergeSort(List<int> myList)
    {
        if (myList.Count <= 1)
        {
            return myList;          
        }
        else
        {
            int middleIndex = myList.Count / 2;

            List<int> leftList = new List<int>();
            List<int> rightList = new List<int>();

            for (int i = 0; i < myList.Count; i++)
            {
                if (i < middleIndex)
                {
                    leftList.Add(myList[i]);
                }
                else
                {
                    rightList.Add(myList[i]);
                }
            }

            leftList = MergeSort(leftList);
            rightList = MergeSort(rightList);

            return Merge(leftList, rightList);
        }
    }

    static List<int> Merge(List<int> leftList, List<int> rightList)
    {
        List<int> resultList = new List<int>();

        while (leftList.Count > 0 || rightList.Count > 0)
        {
            if (leftList.Count > 0 && rightList.Count > 0)
            {
                if (leftList[0] <= rightList[0])
                {
                    resultList.Add(leftList[0]);
                    leftList.Remove(leftList[0]);
                }
                else
                {
                    resultList.Add(rightList[0]);
                    rightList.Remove(rightList[0]);
                }
            }
            else if (leftList.Count > 0) 
            {
                resultList.Add(leftList[0]);
                leftList.Remove(leftList[0]);
            }
            else if (rightList.Count > 0)
            {
                resultList.Add(rightList[0]);
                rightList.Remove(rightList[0]);
            }
        }

        return resultList;
    }

    //define the method to transfer the original array into string
    private static void FillOriginalList(int[] myArray, List<int> myList)
    {
        for (int i = 0; i < myArray.Length; i++)
        {
            myList.Add(myArray[i]);
        }
    }

    //define a function to a list
    private static void Print(List<int> resultList)
    {
        for (int i = 0; i < resultList.Count; i++)
        {
            Console.Write(resultList[i] + " ");
        }
        Console.WriteLine();
    }
}

