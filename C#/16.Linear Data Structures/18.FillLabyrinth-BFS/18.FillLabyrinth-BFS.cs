using System;
using System.Collections.Generic;

namespace FillLabyrinth_BFS
{
    class FillLabyrinth_BFS
    {
        static void Main()
        {
            string[,] labyrinth = {
                                   {"0", "0", "0", "x", "0", "x"},
                                   {"0", "x", "0", "x", "0", "x"},
                                   {"0", "s", "x", "0", "x", "0"},
                                   {"0", "x", "0", "0", "0", "0"},
                                   {"0", "0", "0", "x", "x", "0"},
                                   {"0", "0", "0", "x", "0", "x"},
                               };

            FillLabyrinth(labyrinth);

            MarkUnvisitedCells(labyrinth);

            PrintLabyrinth(labyrinth);
        }

        private static void FillLabyrinth(string[,] labyrinth)
        {
            int height = labyrinth.GetLength(0);
            int width = labyrinth.GetLength(1);

            int row = 2;
            int col = 1;

            Cell currentCell = new Cell(row, col, "0");

            Queue<Cell> cellsQueue = new Queue<Cell>();
            cellsQueue.Enqueue(currentCell);
            int currentStep = 0;

            for (int i = 0; i < width * height; i++)
            {
                if (cellsQueue.Count > 0)
                {
                    currentCell = cellsQueue.Dequeue();
                    row = currentCell.Row;
                    col = currentCell.Col;
                    labyrinth[currentCell.Row, currentCell.Col] = currentCell.Value;

                    //add the four cells next to the current in the queue
                    currentStep = int.Parse(currentCell.Value);
                    if (row - 1 >= 0 && labyrinth[row - 1, col] == "0")
                        cellsQueue.Enqueue(new Cell(row - 1, col, (currentStep + 1).ToString()));

                    if (col + 1 < width && labyrinth[row, col + 1] == "0")
                        cellsQueue.Enqueue(new Cell(row, col + 1, (currentStep + 1).ToString()));

                    if (row + 1 < height && labyrinth[row + 1, col] == "0")
                        cellsQueue.Enqueue(new Cell(row + 1, col, (currentStep + 1).ToString()));

                    if (col - 1 >= 0 && labyrinth[row, col - 1] == "0")
                        cellsQueue.Enqueue(new Cell(row, col - 1, (currentStep + 1).ToString()));
                }
            }
        }

        private static void MarkUnvisitedCells(string[,] labyrinth)
        {
            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    if (labyrinth[row, col] == "0")
                        labyrinth[row, col] = "u";
                }
            }
        }

        static void PrintLabyrinth(string[,] labyrinth)
        {
            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    Console.Write(labyrinth[row, col].PadLeft(3, ' '));
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
