using System;
using System.Collections.Generic;

class EightQueens
{
    static int size = 8;
    static int numberOfQueens = 8;
    static List<string>[,] field = new List<string>[size, size];
    static int solutions = 0;

    static void Main()
    {
        int currentQueen = 0;

        InitializeLists();

        PositionQueens(currentQueen, 0);
    }

    static void InitializeLists()
    {
        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                field[row, col] = new List<string>();
            }
        }
    }

    //this is the recursive method that will distribute the queens
    static void PositionQueens(int currentQueen, int col)
    {
        if (currentQueen == numberOfQueens)
        {
            solutions++;
            PrintField();
            return;
        }

        for (int row = 0; row < size; row++)
        {
            if (CanPutQueen(row, col))
            {
                PutQueen(row, col);
                PositionQueens(currentQueen + 1, col + 1);
                RemoveQueen(row, col);
            }
        }
    }

    //this method will check if we can put queen on every square in relation to other queens already put
    private static bool CanPutQueen(int row, int col)
    {
        //check the vertical for attack upside
        for (int currentRow = row; currentRow >= 0; currentRow--)
        {
            if (ContainsQueen(currentRow, col))
            {
                return false;
            }
        }
        //check the vertical for attack downside
        for (int currentRow = row; currentRow < size; currentRow++)
        {
            if (ContainsQueen(currentRow, col))
            {
                return false;
            }
        }
        //check the horizontal leftside
        for (int currentCol = col; currentCol >= 0; currentCol--)
        {
            if (ContainsQueen(row, currentCol))
            {
                return false;
            }
        }
        //check the hozizontal rightside
        for (int currentCol = col; currentCol < size; currentCol++)
        {
            if (ContainsQueen(row, currentCol))
            {
                return false;
            }
        }
        //check the diagonal left-up
        int diagCol = col;
        int diagRow = row;
        while (diagRow >= 0 && diagCol >= 0)
        {
            if (ContainsQueen(diagRow, diagCol))
            {
                return false;
            }
            diagRow--;
            diagCol--;
        }
        //check the diagonal right-up
        diagCol = col;
        diagRow = row;
        while (diagRow >= 0 && diagCol < size)
        {
            if (ContainsQueen(diagRow, diagCol))
            {
                return false;
            }
            diagRow--;
            diagCol++;
        }
        //check the diagonal left-down
        diagCol = col;
        diagRow = row;
        while (diagRow < size && diagCol >= 0)
        {
            if (ContainsQueen(diagRow, diagCol))
            {
                return false;
            }
            diagRow++;
            diagCol--;
        }
        //check the diagonal right-down
        diagCol = col;
        diagRow = row;
        while (diagRow < size && diagCol < size)
        {
            if (ContainsQueen(diagRow, diagCol))
            {
                return false;
            }
            diagRow++;
            diagCol++;
        }

        //if there is no threat for the queen return true
        return true;
    }

    //this method will check if every square is threataned by attack from a queen
    private static bool ContainsQueen(int row, int col)
    {
        return field[row, col].Contains("Q");
    }

    //this method will put a queen on a playfield and will mark it's attack zones
    static void PutQueen(int row, int col)
    {
        field[row, col].Add("Q");
    }

    //this method will remove a queen after the current configuration is printed
    static void RemoveQueen(int row, int col)
    {
        field[row, col].Remove("Q");
    }

    //this method can print the chessfield any time
    private static void PrintField()
    {
        Console.WriteLine(solutions);
        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                int index = -1;

                for (int i = 0; i < field[row, col].Count; i++)
                {
                    int tempIndex = -1;
                    tempIndex = field[row, col].IndexOf("Q");

                    if (tempIndex != -1)
                    {
                        index = tempIndex;
                        break;
                    }

                }

                if (index > -1)
                {
                    Console.Write(field[row, col][index].PadLeft(3, ' '));
                }
                if (index == -1)
                {
                    Console.Write("*".PadLeft(3, ' '));
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }


}
