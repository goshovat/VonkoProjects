using System;

class MaximalIncreasingSequence
{
    static void Main()
    {
        //a sample input array to test the program
        int[] testArray = { 3, 2, 3, 4, 2, 2, 4 };

        int len = testArray.Length;

        //in  this array we store how long will be the sequence of equal elements on each position
        int[] lensArray = new int[len];

        int currentElement = testArray[0];
        lensArray[0] = 1;
        int currentSeqLen = 1;
        int maxSeqLen = 1;

        for (int i = 1; i < len; i++)
        {
            if (testArray[i] > currentElement)
            {
                currentSeqLen++;
                lensArray[i] = currentSeqLen;
            }
            //if the increasing sequence is interrupted
            else
            {
                currentElement = testArray[i];
                currentSeqLen = 1;
                lensArray[i] = 1;
            }

            if (currentSeqLen > maxSeqLen)
                maxSeqLen = currentSeqLen;
        }

        //now print the sequences
        for (int i = 0; i < len; i++)
        {
            if (lensArray[i] == maxSeqLen)
            {
                for (int j = i - maxSeqLen + 1; j <= i; j++)
                {
                    Console.Write(testArray[j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
