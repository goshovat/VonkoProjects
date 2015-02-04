using System;
using System.Text;

class StudentsToStudentsAndBitsToBits
{
    private static int[,] grid;
    private static StringBuilder concatenatedBits = new StringBuilder();

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        grid = new int[n, 30];

        //get the input
        for (int row = 0; row < n; row++)
        {
            uint currentNumber = uint.Parse(Console.ReadLine());

            uint mask = 1;
            for (int col = 29; col >= 0; col--)
            {
                if ((currentNumber & mask) != 0)
                    grid[row, col] = 1;
                else
                    grid[row, col] = 0;

                mask <<= 1;
            }
        }

        //fill the array3
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < 30; col++)
            {
                concatenatedBits.Append(grid[row, col]);
            }
        }

        string allBits = concatenatedBits.ToString();
        //find the longest sequences
        int longestSequenceZeroes = 0;
        int longestSequenceOnes = 0;

        char currentDigit = allBits[0];
        int currentSeqLen = 1;

        for (int i = 1; i < allBits.Length; i++)
        {
            if (allBits[i] == currentDigit)
            {
                currentSeqLen++;
            }
            else
            {
                if (currentDigit == '0')
                {
                    if (currentSeqLen > longestSequenceZeroes)
                    {
                        longestSequenceZeroes = currentSeqLen;
                    }
                }
                else if (currentDigit == '1')
                {
                    if (currentSeqLen > longestSequenceOnes)
                    {
                        longestSequenceOnes = currentSeqLen;
                    }
                }
                currentDigit = allBits[i];
                currentSeqLen = 1;
            }
        }

        if (currentDigit == '0')
        {
            if (currentSeqLen > longestSequenceZeroes)
            {
                longestSequenceZeroes = currentSeqLen;
            }
        }
        else if (currentDigit == '1')
        {
            if (currentSeqLen > longestSequenceOnes)
            {
                longestSequenceOnes = currentSeqLen;
            }
        }

        Console.WriteLine(longestSequenceZeroes);
        Console.WriteLine(longestSequenceOnes);
    }
}
