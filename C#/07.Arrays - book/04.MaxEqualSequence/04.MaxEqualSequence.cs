using System;

class MaxEqualSequence
{
    static void Main()
    {
        //Initialize thea array
        Console.WriteLine("Enter the length of the array: ");
        int arrLen = int.Parse(Console.ReadLine());
        int[] myArr = new int[arrLen];

        //set the values of the array
        for (int i = 0; i < arrLen; i++)
        {
            Console.WriteLine("Enter element No {0} of the array: ", i);
            myArr[i] = int.Parse(Console.ReadLine());
        }

        //finnd the max sequence
        int largestLen = 0;
        int currentLen = 1;
        int[] lensArr = new int[arrLen];

        for (int i = 0; i < arrLen - 1; i++)
        {
            currentLen = 1;

            if (myArr[i] == myArr[i + 1])
            {

                for (int j = i; j < arrLen - 1; j++)
                {
                    if (myArr[j] != myArr[j + 1])
                    {
                        break;
                    }
                    else
                    {
                        currentLen++;
                    }
                }
            };

            //store all largest lengths in a separate array
            if (currentLen > largestLen)
            {
                largestLen = currentLen;
                
                for (int k = 0; k < lensArr.Length; k++)
                {
                    lensArr[k] = 0;
                };

                lensArr[i] = largestLen;

            }
            else if (currentLen == largestLen)
            {
                lensArr[i] = currentLen;
            }
        };

        //if the largest lenght is 1 fill the last element, because the loop before
        //did not reach it
        if (largestLen == 1)
        {
            lensArr[arrLen - 1] = largestLen;
        }

        //Print the largest sequence or sequences if more than one:
        Console.WriteLine("The largest sequence/s is/are: ");
        for (int i = 0; i < lensArr.Length; i++)
        {
            if (lensArr[i] != 0)
            {
                for (var j = lensArr[i]; j < largestLen + lensArr[i]; j++)
                {
                    Console.Write(myArr[i] + " ");
                }
                Console.WriteLine();
                Console.WriteLine(new string('-', 10));
            }         
        }
    }
}

