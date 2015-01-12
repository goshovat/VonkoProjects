using System;
using System.Collections.Generic;

class SubsetOfElementsWithSumS
{
    static void Main()
    {
        Console.WriteLine("Input the sum you like to check: ");
        int givenSum = int.Parse(Console.ReadLine());
        int currentSum = int.MinValue;

        int[] myArr = { 2, 1, 2, 4, 3, 5, 2, 6 };
        //1 2 2 3 4 5 6
        int lenArr = myArr.Length;
        bool found = false;

        Array.Sort(myArr);

        List<int> elementsList = new List<int>();

        for (int i = 0; i < lenArr; i++)
        {
            if (found == false)
            {
                elementsList.RemoveRange(0, elementsList.Count);
                currentSum = myArr[i];
                elementsList.Add(myArr[i]);

                for (int j = lenArr - 1; j > i; j--)
                {
                    if (myArr[j] + currentSum > givenSum)
                    {
                        continue;
                    }
                    else
                    {
                        currentSum += myArr[j];
                        elementsList.Add(myArr[j]);
                    }

                    if (currentSum == givenSum)
                    {
                        found = true;
                        break;
                    }
                }
            }
            else
            {
                break;
            }
        }

        elementsList.Sort();

        //Print the elements
        if (found == true)
        {
            Console.WriteLine("The sum is: {0}", givenSum);
            Console.WriteLine("The elements are: ");
            foreach (int element in elementsList)
            {
                Console.Write(element + " ");
            }
        }
        else
        {
            Console.WriteLine("There are no such elements");
        }
        Console.WriteLine();
    }
}
