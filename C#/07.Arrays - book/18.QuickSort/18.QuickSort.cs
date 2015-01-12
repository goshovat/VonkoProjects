using System;
using System.Collections.Generic;

class QuickSort
{
    static Random randomGenerator = new Random();

    static void Main()
    {
        int[]  myArray = { 1, -10, -8, 7, -6, 3, 4, 5};

        Console.WriteLine("The original array is: ");
        Console.WriteLine(String.Join(", ",  myArray));

        //in this list will be transfered the original array
        List<int> myList = new List<int>();

        //put all the values from the array into the list
        FillOriginalList(myArray, myList);

        int pivot = myList[myList.Count / 2];

        //process the result string to remove the excessive spaces
        string resutlString = Sort(myList);

        while (resutlString.IndexOf("  ") != -1)
        {
            resutlString = resutlString.Replace("  ", " ");
        }

        Console.WriteLine("The arranged array is: ");
        Console.WriteLine(resutlString);
    }

    static string Sort(List<int> myList)
    {
        int lenList = myList.Count;

        if (lenList <= 1)
        {
            return String.Join(", ",  myList) + " ";
        }
        else
        {
            //Random randomGenerator = new Random();
            int newPivotIndex = randomGenerator.Next(0, lenList);
            int pivot =  myList[newPivotIndex];
            Console.WriteLine(pivot);

            //here we put all elements less and equal to the pivot
            List<int> less = new List<int>();
            //here we put all elements bigger than the pivot
            List<int> bigger = new List<int>();

            //divide the elements into the 'less' and 'bigger' lists
            for (int i = 0; i < lenList; i++)
            {
                if ( myList[i] <= pivot)
                {
                    less.Add(myList[i]);
                }
                else
                {
                    bigger.Add(myList[i]);
                }
            }

            return (Sort(less) + Sort(bigger));
        }
    }

    //define the method to transfer the original array into string
    private static void FillOriginalList(int[] myArray, List<int> myList)
    {
        for (int i = 0; i < myArray.Length; i++)
        {
            myList.Add(myArray[i]);
        }
    }
}

