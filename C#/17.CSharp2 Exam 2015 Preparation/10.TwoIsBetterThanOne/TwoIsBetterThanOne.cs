using System;
using System.Collections.Generic;
using System.Linq;

class TwoIsBetterThanOne
{
    static void Main()
    {
        string[] firstTaskInput = Console.ReadLine().Split();
        long a = long.Parse(firstTaskInput[0]);
        long b = long.Parse(firstTaskInput[1]);
        string[] list = Console.ReadLine().Split(new char[] { ',' }, 
            StringSplitOptions.RemoveEmptyEntries);
        int[] numbersList = list.Select(n => int.Parse(n)).ToArray();
        int percent = int.Parse(Console.ReadLine());

        SolveFirstTask(a, b);

        Console.WriteLine(SolveSecondTask(numbersList, percent)); 
    }


    private static void SolveFirstTask(long lower, long upper)
    {
        long maxNumber = (long)Math.Pow(10, 18);
        List<long> numbersList = new List<long>() { 3, 5};
        int left = 0;

        while (left < numbersList.Count)
        {
            int right = numbersList.Count;

            for (int i = left; i < right; i++)
            {
                if (numbersList[i] <= maxNumber)
                {
                    numbersList.Add(numbersList[i] * 10 + 3);
                    numbersList.Add(numbersList[i] * 10 + 5);
                }
            }
            left = right;
        }

        int count = 0;
        foreach (var number in numbersList)
        {
            if (number >= lower && number <= upper 
                && IsPalindromeNumber(number))
            {
                count++;
            }
        }

        Console.WriteLine(count);
    }

    private static bool IsPalindromeNumber(long number)
    {
        string numberStr = number.ToString();

        for (int i = 0; i < numberStr.Length / 2; i++)
        {
            if (numberStr[i] != numberStr[numberStr.Length - 1 - i])
                return false;
        }
        return true; 
    }

    private static int SolveSecondTask(int[] numbersList, int percent)
    {
        Array.Sort(numbersList);
        for (int i = 0; i < numbersList.Length; i++)
        {
            int currentCount = 0;

            for (int j = 0; j < numbersList.Length; j++)
            {
                if (numbersList[j] <= numbersList[i])
                    currentCount++;
            }

            if (currentCount >= (percent / 100.00) * numbersList.Length)
            {
                return numbersList[i]; 
            }
        }

        return numbersList[numbersList.Length - 1];
    }
}
