using System;
using System.Collections.Generic;
using TreeMultiSet;

namespace HappySubSequences
{
    class HappySubSequences
    {
        static void Main()
        {
            ListComparer<int> comparer = new ListComparer<int>();
            TreeMultiSet<List<int>> sequenceS = new TreeMultiSet<List<int>>(comparer);
            List<int> sequenceP = new List<int>() { 1, 1, 2, 1, -1, 2, 3, -1, 1, 2, 3, 5, 1, -1, 2, 3 };
            //List<int> sequenceP = new List<int>(new int[10000]);
            int seqCount = sequenceP.Count;
            Console.WriteLine(DateTime.Now);
            int givenSum = 5;

            //find the subsequences
            for (int i = 0; i < seqCount; i++)
            {
                List<int> currentComb = new List<int>();

                for (int j = i; j < seqCount; j++)
                {       
                    currentComb.Add(sequenceP[j]);

                    if (FindSum(currentComb) == givenSum)
                    {
                        sequenceS.Add(new List<int>(currentComb));

                        if (sequenceS.Count > 10)
                            sequenceS.RemoveBiggest();
                    }           
                }
            }

            Console.WriteLine(DateTime.Now);

            //print the sub-sequences in decreasing order
            foreach (List<int> subSeq in sequenceS)
            {
                Console.WriteLine(string.Join(",", subSeq));
            }
        }

        private static int FindSum(List<int> currentComb)
        {
            int sum = 0;

            foreach (int number in currentComb)
                sum += number;

            return sum;
        }
    }
}
