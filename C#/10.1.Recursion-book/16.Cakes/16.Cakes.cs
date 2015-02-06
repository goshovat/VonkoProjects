using System;
using System.Collections.Generic;

class Cakes
{
    static int[] cakePrices = { 15, 25, 28 };
    static int[] iterations;
    static int numberOfCakes;
    static int minRemainder = int.MaxValue;
    static bool zeroSolutionFound = false;
    static bool alreadyTurned = false;
    static List<int> minRemainderIndex = new List<int>(); 
    static int sum = 127;
    static int currentSum = 0;

    static void Main()
    {
        numberOfCakes = cakePrices.Length;
        iterations = new int[numberOfCakes];
        int currentCake = 0;

        SumCakes(currentCake);

        if (!zeroSolutionFound)
        {
            Console.WriteLine("Solution found: {0} times cake1, {1} times cake2 and {2} times cake3", minRemainderIndex[0], minRemainderIndex[1], minRemainderIndex[2]);
            Console.WriteLine("Remainder: {0}", minRemainder);
        }
    }

    //this recursive method will find the corect sum of our cakes
    static void SumCakes(int currentCake)
    {
        CheckSums();

        if (currentCake == numberOfCakes)
        {
            alreadyTurned = true;
            return;
        }

        while(currentSum < sum) 
        {
            if (alreadyTurned)
            {
                currentSum += cakePrices[currentCake];
                iterations[currentCake]++;
            }

            SumCakes(currentCake + 1);
        }

        int timesLastCakeAdded = iterations[currentCake];

        for (int i = 0; i < timesLastCakeAdded; i++)
        {
            currentSum -= cakePrices[currentCake];
            iterations[currentCake]--;
        }
    }

    //this method will check our current bill every time a new cake is bought
    static void CheckSums()
    {
        if (sum - currentSum < 0)
        {
            return;
        }
        if (sum - currentSum == 0)
        {
            minRemainder = 0;
            zeroSolutionFound = true;
            Console.WriteLine("Solution found: {0} times cake1, {1} times cake2 and {2} times cake3", iterations[0], iterations[1], iterations[2]);
        }
        else if (sum - currentSum > 0 && sum - currentSum < minRemainder)
        {
            minRemainder = sum - currentSum;

            minRemainderIndex = new List<int>();
            for (int i = 0; i < numberOfCakes; i++)
            {
                minRemainderIndex.Add(iterations[i]);
            }           
        }
    }
}
