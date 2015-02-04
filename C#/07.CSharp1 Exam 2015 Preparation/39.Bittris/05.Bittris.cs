using System;
using System.IO;

class BittrisBitwise
{
    static void Main()
    {
        //if (Environment.CurrentDirectory.
        //    ToLower()
        //    .EndsWith("bin\\debug"))
        //{
        //    Console.SetIn(new StreamReader("input.txt"));
        //}
        int numberOfLines = int.Parse(Console.ReadLine());
        const int ROW_COUNT = 4;
        const int COL_COUNT = 8;
        //no need to keep row 0, it must be zero while the game is running
        uint row1 = 0;
        uint row2 = 0;
        uint row3 = 0;

        const uint LOW_BIT = (uint)1;
        const uint HIGH_BIT = LOW_BIT << (COL_COUNT - 1);
        const uint EIGHT_BITS = (LOW_BIT << COL_COUNT) - 1;

        int totalScore = 0;

        while (true)
        {
            uint integer;
            if (!uint.TryParse(Console.ReadLine(), out integer))
            {
                //end of input
                Console.WriteLine(totalScore);
                return;
            }
            string commands = Console.ReadLine() + Console.ReadLine() + Console.ReadLine();
            int currentScore = 0;

            //calculate the score from this piece
            for (int bit = 0; bit < 32; bit++)
            {
                if ((1 << bit & integer) != 0)
                {
                    currentScore++;
                }
            }
            uint piece = integer & EIGHT_BITS;

            //move this piece down
            for (int currentRowIndex = 0; currentRowIndex < ROW_COUNT; currentRowIndex++)
            {
                if (currentRowIndex < 3)
                {
                    char currentCommand = commands[currentRowIndex];
                    if (currentCommand == 'L')
                    {
                        if ((piece & HIGH_BIT) == 0)
                            piece <<= 1;
                    }
                    else if (currentCommand == 'R')
                    {
                        if ((piece & LOW_BIT) == 0)
                            piece >>= 1;
                    }
                }
                int nextRowIndex = currentRowIndex + 1;
                uint nextRowBits = 0;

                switch (nextRowIndex)
                {
                    case 1: nextRowBits = row1; break;
                    case 2: nextRowBits = row2; break;
                    case 3: nextRowBits = row3; break;
                }
                if (nextRowIndex == ROW_COUNT || (nextRowBits & piece) != 0)
                {
                    //piece cannot go any lower
                    //land the piece on the currentRow and check if it is filled
                    switch (currentRowIndex)
                    {
                        case 1: row1 |= piece; break;
                        case 2: row2 |= piece; break;
                        case 3: row3 |= piece; break;
                    }

                    bool isRowFull = false;
                    switch (currentRowIndex)
                    {
                        case 0: isRowFull = (EIGHT_BITS == piece); break;
                        case 1: isRowFull = (EIGHT_BITS == row1); break;
                        case 2: isRowFull = (EIGHT_BITS == row2); break;
                        case 3: isRowFull = (EIGHT_BITS == row3); break;
                    }
                    if (isRowFull)
                    {
                        totalScore += currentScore * 10;
                        //shift down the rows
                        for (int row = currentRowIndex; row >= 1; row--)
                        {
                            switch (row)
                            {
                                case 1: row1 = 0; break;
                                case 2: row2 = row1; break;
                                case 3: row3 = row2; break;
                            }
                        }
                    }
                    else
                    {
                        totalScore += currentScore;
                    }

                    if (currentRowIndex == 0 && !isRowFull)
                    {
                        //the top row remains with some pices and game ends
                        Console.WriteLine(totalScore);
                        return;
                    }

                    break;
                }
            }

        }
    }
}