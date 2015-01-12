using System;

class MostIncrasingElementsNonSeq
{
    static void Main()
    {
        //Initialize the array
        Console.WriteLine("Enter the length of the array: ");
        int arrLen = int.Parse(Console.ReadLine());
        int[] myArr = new int[arrLen];

        //set the values of the array
        for (int i = 0; i < arrLen; i++)
        {
            Console.WriteLine("Enter element No {0} of the array: ", i);
            myArr[i] = int.Parse(Console.ReadLine());
        }

        //in this array we will store the number of increasing elements ending at each index
        var lensArr = new int[arrLen];

        for (int i = 0; i < arrLen; i++)
        {
            lensArr[i] = 1; 

            for (int j = i -1; j >= 0; j--)
            {
                if (myArr[i] > myArr[j] &&
                    lensArr[i] <= lensArr[j])
                {
                    lensArr[i] = lensArr[j] + 1;
                }
            }
        }

        //test print
        for (int i = 0; i < lensArr.Length; i++)
        {
            Console.WriteLine("Members: {0}", lensArr[i]);
        }

        //now we will print the biggest number of increasing elements
        var maxElements = 0;

        for (int i = 0; i < arrLen; i++)
        {
            if (lensArr[i] > maxElements)
            {
                maxElements = lensArr[i];
            }
        }

        int difference = 1;
        Console.WriteLine("The increasing elements are: ");

        string elementsString = "";

        for (int i = 0; i < arrLen; i++)
        {
            if (lensArr[i] == maxElements)
            {
                elementsString = myArr[i] + " " + elementsString;

                for (int j = i-1; j >= 0; j--)
                {
                    if (lensArr[i] == lensArr[j] + difference)
                    {
                        elementsString = myArr[j] + " " + elementsString;
                        difference++;
                    }
                }
            }
        }

        Console.WriteLine(elementsString);
    }
}

