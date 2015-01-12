using System;

class AllVariations
{
    static void Main()
    {
        Console.WriteLine("Input the number N: ");
        int highEnd = int.Parse(Console.ReadLine());
        Console.WriteLine("Input the number K: ");
        int numberOfElements = int.Parse(Console.ReadLine());

        int[] variationsArray = new int[numberOfElements];

        for (int i = 0; i < numberOfElements; i++)
        {
            variationsArray[i] = 1;
        }

        while (Next(variationsArray, highEnd))
        {
            Console.WriteLine(string.Join(",", variationsArray));
        }
    }

    //this method will generate the variations
    private static bool Next(int[] variationsArray, int highEnd)
    {
        int index = variationsArray.Length - 1;

        while (index >= 0)
        {
            variationsArray[index]++;

            if (variationsArray[index] > highEnd)
            {
                variationsArray[index] = 1;
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

