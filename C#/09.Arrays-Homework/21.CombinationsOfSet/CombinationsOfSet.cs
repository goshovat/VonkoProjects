using System;

class CombinationsOfSet
{
    static void Main()
    {
        Console.WriteLine("Input the number N: ");
        int highEnd = int.Parse(Console.ReadLine());
        Console.WriteLine("Input the number K: ");
        int numberOfElements = int.Parse(Console.ReadLine());
        int[] combinationsArray = new int[numberOfElements];

        for (int i = 0; i < numberOfElements; i++)
        {
            combinationsArray[i] = 1;
        }

        while (Next(combinationsArray, highEnd))
        {
            if (AreValidCOmbinations(combinationsArray))
            {
                Console.WriteLine(string.Join(",", combinationsArray));
            }
        }
    }

    private static bool AreValidCOmbinations(int[] combinationsArray)
    {
        bool areValidCombinations = true;

        for (int i = 0; i < combinationsArray.Length; i++)
        {
            for (int j = i + 1; j < combinationsArray.Length; j++)
            {
                if (combinationsArray[i] == combinationsArray[j] ||
                    combinationsArray[i] > combinationsArray[j])
                {
                    areValidCombinations = false;
                    return areValidCombinations;
                }
            }
        }
        return areValidCombinations;
    }

    //this method will generate the cobinations
    private static bool Next(int[] combinationsArray, int highEnd)
    {
        int index = combinationsArray.Length - 1;

        while (index >= 0)
        {
            combinationsArray[index]++;

            if (combinationsArray[index] > highEnd)
            {
                combinationsArray[index] = 1;
                index--;
            }
            else
            {
                return true;
            }
        }
        if (index == -1)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}

