using System;
using System.Collections.Generic;

class Warhead
{
    private const int BOARD_WIDTH_HEIGHT = 16;
    private static int[,] board = new int[BOARD_WIDTH_HEIGHT, BOARD_WIDTH_HEIGHT];
    private static List<string> outputList = new List<string>();

    static void Main()
    {
        for (int rows = 0; rows < BOARD_WIDTH_HEIGHT; rows++)
        {
            string input = Console.ReadLine();

            for (int cols = 0; cols < BOARD_WIDTH_HEIGHT; cols++)
            {
                board[rows, cols] = int.Parse(input[cols].ToString());
            }
        }

        //PrintBoard();
        bool iSbombExploderOrDisarmed = false;
        while (!iSbombExploderOrDisarmed)
        {
            string command = Console.ReadLine();
            if (command == "hover")
            {
                int row = int.Parse(Console.ReadLine());
                int col = int.Parse(Console.ReadLine());

                if (board[row, col] == 1)
                    outputList.Add("*");
                else
                    outputList.Add("-");
            }
            else if (command == "operate")
            {
                int row = int.Parse(Console.ReadLine());
                int col = int.Parse(Console.ReadLine());

                if (board[row, col] == 1)
                {
                    //detonate
                    outputList.Add("missed");
                    int shapes = CheckNumberShapesRed() + CheckNumberShapesBlue();
                    outputList.Add(shapes.ToString());
                    outputList.Add("BOOM");
                    iSbombExploderOrDisarmed = true;
                }
                else
                {
                    RemoveIfEightCapacitors(row, col, board);
                }
            }
            else if (command == "cut")
            {
                string color = Console.ReadLine();
                if (color == "red" || color == "left")
                {
                    int shapes = CheckNumberShapesRed();
                    if (shapes == 0)
                    {
                        int otherShapes = CheckNumberShapesBlue();
                        outputList.Add(otherShapes.ToString());
                        outputList.Add("disarmed");
                    }
                    else
                    {
                        outputList.Add(shapes.ToString());
                        outputList.Add("BOOM");
                    }
                }
                else if (color == "blue" || color == "right")
                {
                    int shapes = CheckNumberShapesBlue();
                    if (shapes == 0)
                    {
                        int otherShapes = CheckNumberShapesRed();
                        outputList.Add(otherShapes.ToString());
                        outputList.Add("disarmed");
                    }
                    else
                    {
                        outputList.Add(shapes.ToString());
                        outputList.Add("BOOM");
                    }
                }
                iSbombExploderOrDisarmed = true;
            }
        }

        for (int i = 0; i < outputList.Count; i++)
        {
            Console.WriteLine(outputList[i]);
        }
        //PrintBoard();
    }

    private static int CheckNumberShapesRed()
    {
        //make copy of the half we need
        int[,] copyBoard = new int[BOARD_WIDTH_HEIGHT, BOARD_WIDTH_HEIGHT/2];
        for (int row = 0; row < copyBoard.GetLength(0); row++)
        {
            for (int col = 0; col < copyBoard.GetLength(1); col++)
            {
                copyBoard[row, col] = board[row, col];
            }
        }
        //PrintBoard(copyBoard);

        int redShapes = 0;
        for (int row = 0; row < copyBoard.GetLength(0); row++)
        {
            for (int col = 0; col < copyBoard.GetLength(1); col++)
            {
                if (RemoveIfEightCapacitors(row, col, copyBoard))
                    redShapes++;
            }
        }
        return redShapes;
    }

    private static int CheckNumberShapesBlue()
    {
        //make copy of the half we need
        int[,] copyBoard = new int[BOARD_WIDTH_HEIGHT, BOARD_WIDTH_HEIGHT / 2];
        for (int row = 0; row < copyBoard.GetLength(0); row++)
        {
            for (int col = 0; col < copyBoard.GetLength(1); col++)
            {
                copyBoard[row, col] = board[row, col + BOARD_WIDTH_HEIGHT / 2];
            }
        }
        //PrintBoard(copyBoard);

        int blueShapes = 0;
        for (int row = 0; row < copyBoard.GetLength(0); row++)
        {
            for (int col = 0; col < copyBoard.GetLength(1); col++)
            {
                if (RemoveIfEightCapacitors(row, col, copyBoard))
                    blueShapes++;
            }
        }
        return blueShapes;
    }

    private static bool RemoveIfEightCapacitors(int row, int col, int[,] matrix)
    {
        int capacitorsFound = 0;
        for (int i = row - 1; i <= row + 1; i++)
        {
            for (int j = col - 1; j <= col + 1; j++)
            {
                if (i >= 0 && i < matrix.GetLength(0) &&
                    j >= 0 && j < matrix.GetLength(1) &&
                    matrix[i, j] == 1)
                {
                    capacitorsFound++;
                }
            }
        }

        if (capacitorsFound == 8)
        {
            for (int i = row - 1; i <= row + 1; i++)
            {
                for (int j = col - 1; j <= col + 1; j++)
                {
                    matrix[i, j] = 0;
                }
            }
            return true;
        }
        else
        {
            return false;
        }
    }

    private static void PrintBoard(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row, col]);
            }
            Console.WriteLine();
        }
    }
}
