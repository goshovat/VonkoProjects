using System;

class MostCommonElement
{
    static void Main()
    {
        ////Initialize the array
        Console.WriteLine("Enter the length of the array: ");
        int arrLen = int.Parse(Console.ReadLine());
        int[] myArr = new int[arrLen];

        //set the values of the array
        for (int i = 0; i < arrLen; i++)
        {
            Console.WriteLine("Enter element No {0} of the array: ", i);
            myArr[i] = int.Parse(Console.ReadLine());
        }

        //find the most common element

        int currrentNumber = 0;
        int maxEncounters = 0;
        int currentMaxEncounters = 0;
        int mostCommonNumber = int.MinValue;

        for (int i = 0; i < arrLen; i++)
        {
            if (myArr[i] != int.MinValue)
            {
                currrentNumber = myArr[i];
                myArr[i] = int.MinValue;
                currentMaxEncounters = 1;

                for (int j = i + 1; j < arrLen; j++)
                {
                    if (myArr[j] != int.MinValue && myArr[j] == currrentNumber)
                    {
                        currentMaxEncounters++;
                        myArr[j] = int.MinValue;

                        if (currentMaxEncounters > maxEncounters)
                        {
                            maxEncounters = currentMaxEncounters;
                            mostCommonNumber = currrentNumber;

                        }
                    }
                }


            }
        }

        Console.WriteLine("The most common number is: {0}", mostCommonNumber);
        Console.WriteLine("It is met {0} times", maxEncounters);
    }
}

