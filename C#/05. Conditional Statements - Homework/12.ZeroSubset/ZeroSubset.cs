using System;
using System.Collections.Generic;
using System.Text;

class ZeroSubset
{
    static void Main()
    {
        /*I suggest there may be more efficient way to solve the task, just I didn't have much time
        and made a quick solution using the gray algorithm*/
        int numberIntegers = 5;
        int[] numbers = new int[numberIntegers];
        Console.WriteLine("Enter 5 integers:");
        for (int i = 0; i < numberIntegers; i++)
        {
            int input = int.Parse(Console.ReadLine());
            numbers[i] = input;
        }
        int numberCombinations = (int)Math.Pow(2, numberIntegers);
        bool subsetFound = false;
        List<int> subsetMembers = new List<int>();
        HashSet<string> subsets = new HashSet<string>();

        for (int combination = 0; combination < numberCombinations; combination++)
        {
            int currentSum = 0;
            subsetMembers = new List<int>();
            for (int j = 0; j < numberIntegers; j++)
            {
                if (((1 << j) & combination) != 0)
                {
                    currentSum += numbers[numbers.Length - 1 - j];
                    subsetMembers.Add(numbers[numbers.Length - 1 - j]);
                }
            }
            if (currentSum == 0 && subsetMembers.Count != 0)
            {
                subsetFound = true;
                string currentSubset = GetSubset(subsetMembers);
                subsets.Add(currentSubset);
            }
        }
        if (subsetFound == false)
        {
            Console.WriteLine("No zero subset");
        }
        else
        {
            foreach(string subset in subsets)
                Console.WriteLine(subset);
        }
    }

    private static string GetSubset(List<int> subsetMembers)
    {
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < subsetMembers.Count; i++)
        {
            if (i != 0)
            {
                result.Append("+ ");
            }
            result.Append(subsetMembers[i] + " ");
        }
        result.Append("= " + 0);
        return result.ToString();
    }
}
