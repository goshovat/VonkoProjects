using System;
using System.Collections.Generic;

namespace RotatingMatrix
{
    class RotatingMatrix
    {
        static int[,] matrix;
        static int matrixSize;

        static void Main()
        {
            Console.WriteLine("Enter a positive number: ");
            string input = Console.ReadLine();
            while (!int.TryParse(input, out matrixSize)
                || matrixSize < 0 || matrixSize > 100)
            {
                Console.WriteLine("Error! You haven't entered a correct positive number.");
                input = Console.ReadLine();
            }

            matrix = new int[matrixSize, matrixSize];
            int step = matrixSize;
            int currentNumber = 0;
            int row = 0;
            int col = 0; 
            int dx = 1;
            int dy = 1;

            for (int i = 0; i < matrixSize * matrixSize; i++)
            {
                currentNumber++;
                matrix[row, col] = currentNumber;

                //find new step if there is no available step next to our position
                if (!CanStepAround(row, col))
                {           
                    FindFreeCell(ref row, ref col);
                    //after jumping to new field, we need to set to the initial moving direction     
                    dx = 1;
                    dy = 1;
                    continue;
                }

                if (NeedToChangeDirection(row, col, ref dx, ref dy))
                {
                    while (NeedToChangeDirection(row, col, ref dx, ref dy))
                        ChangeDirection(ref dx, ref dy);
                }

                row += dx;
                col += dy;               
            }

            PrintMatrix();
        }

        static bool CanStepAround(int row, int col)
        {
            //all the eight directions we can go, the vertical and horizontal change of coordinates
            int[] diffVer = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] diffHor = { 1, 0, -1, -1, -1, 0, 1, 1 };

            for (int direction = 0; direction < 8; direction++)
            {
                if (row + diffVer[direction] >= matrixSize || row + diffVer[direction] < 0)
                    diffVer[direction] = 0;

                if (col + diffHor[direction] >= matrixSize || col + diffHor[direction] < 0)
                    diffHor[direction] = 0;
            }
            for (int direction = 0; direction < 8; direction++)
            {
                if (matrix[row + diffVer[direction], col + diffHor[direction]] == 0)
                    return true;
            }
            return false;
        }

        static bool NeedToChangeDirection(int row, int col, ref int dx, ref int dy)
        {
            if (row + dx >= matrixSize || row + dx < 0 || col + dy >= matrixSize
                    || col + dy < 0 || matrix[row + dx, col + dy] != 0)
                return true;
            else
                return false;
        }

        static void ChangeDirection(ref int dVer, ref int dHor)
        {
            int[] diffVer = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] diffHor = { 1, 0, -1, -1, -1, 0, 1, 1 };

            int oldDirection = 0;
            for (int direction = 0; direction < 8; direction++)
            {
                if (diffVer[direction] == dVer && diffHor[direction] == dHor)
                {
                    oldDirection = direction;
                    break;
                }      
            }

            dVer = diffVer[(oldDirection + 1) % diffVer.Length];
            dHor = diffHor[(oldDirection + 1) % diffHor.Length];
        }

        static void FindFreeCell(ref int row, ref int col)
        {
            for (int curRow = 0; curRow < matrixSize; curRow++)
            {
                for (int curCol = 0; curCol < matrixSize; curCol++)
                {
                    if (matrix[curRow, curCol] == 0)
                    {
                        row = curRow; 
                        col = curCol;
                        return;
                    }
                }
            }
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col].ToString().PadLeft(4));
                }
                Console.WriteLine();
            }
        }
    }
}
