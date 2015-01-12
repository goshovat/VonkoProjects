using System;
using System.Collections.Generic;

namespace RotatingMatrix
{
    class RotatingMatrix
    {
        private static int[,] matrix;
        private const int START_ROW = 0;
        private const int START_COL = 0;

        static List<int> vonkoList = new List<int>();

        static void Main()
        {
            try
            {
                Console.WriteLine("Enter a positive number:");
                int matrixSize = int.Parse(Console.ReadLine());

                if (matrixSize <= 0)
                    throw new ApplicationException(string.Format(
                        "Error! Cannot fill matrix with size {0}", matrixSize));

                matrix = new int[matrixSize, matrixSize];

                FillMatrix();
                PrintMatrix();
            }
            catch (ApplicationException applicationException)
            {
                Console.WriteLine(applicationException.Message);
                Console.WriteLine(applicationException.StackTrace);
            }
            catch (FormatException formatException)
            {
                Console.WriteLine(formatException.Message);
                Console.WriteLine(formatException.StackTrace);
            }
        }

        private static void FillMatrix()
        {
            int row = 0;
            int col = 0;
            int counter = 1;

            //the first step is made always in the top-left corner
            matrix[START_ROW, START_COL] = counter;
            counter++;

            while (true)
            {
                bool canStepAround = false;

                while (IsRightDownFree(row, col, ref canStepAround))
                    StepRightDown(ref row, ref col, ref counter);

                while (IsDownFree(row, col, ref canStepAround))
                    StepDown(ref row, ref col, ref counter);

                while (IsLeftDownFree(row, col, ref canStepAround))
                    StepLeftDown(ref row, ref col, ref counter);

                while (IsLeftFree(row, col, ref canStepAround))
                    StepLeft(ref row, ref col, ref counter);

                while (IsLeftUpFree(row, col, ref canStepAround))
                    StepLeftUp(ref row, ref col, ref counter);

                while (IsUpFree(row, col, ref canStepAround))
                    StepUp(ref row, ref col, ref counter);

                while (IsUpRightFree(row, col, ref canStepAround))
                    StepUpRight(ref row, ref col, ref counter);

                while (isRightFree(row, col, ref canStepAround))
                    StepRight(ref row, ref col, ref counter);

                /*If there is no free step next to our current position,
                 scan the table from top for new one*/
                if (!canStepAround)
                    FindFreeStep(ref row, ref col, ref canStepAround);

                //if there is no free step in the whole table, the program is done
                if (!canStepAround)
                    break;
            }
        }

        //the methods that check for free step around position in all directions
        private static bool IsRightDownFree(
            int row, int col, ref bool canStepAround)
        {
            if (row + 1 < matrix.GetLength(0) && col + 1 < matrix.GetLength(1)
                && matrix[row + 1, col + 1] == default(int))
            {
                //we have found a free step around our position
                canStepAround = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool IsDownFree(int row, int col, ref bool canStepAround)
        {
            if (row + 1 < matrix.GetLength(0)
                && matrix[row + 1, col] == default(int))
            {
                //we have found a free step around our position
                canStepAround = true;
                return true;
            }
            else
                return false;
        }

        private static bool IsLeftDownFree(int row, int col, ref bool canStepAround)
        {
            if (row + 1 < matrix.GetLength(0) && col-1 >= 0
               && matrix[row + 1, col-1] == default(int))
            {
                //we have found a free step around our position
                canStepAround = true;
                return true;
            }
            else
                return false;
        }

        private static bool IsLeftFree(int row, int col, ref bool canStepAround)
        {
            if (col - 1 >= 0
               && matrix[row, col - 1] == default(int))
            {
                //we have found a free step around our position
                canStepAround = true;
                return true;
            }
            else
                return false;
        }

        private static bool IsLeftUpFree(int row, int col, ref bool canStepAround)
        {
            if (col - 1 >= 0 && row - 1 >= 0
              && matrix[row-1, col - 1] == default(int))
            {
                //we have found a free step around our position
                canStepAround = true;
                return true;
            }
            else
                return false;
        }

        private static bool IsUpFree(int row, int col, ref bool canStepAround)
        {
            if (row - 1 >= 0
              && matrix[row - 1, col] == default(int))
            {
                //we have found a free step around our position
                canStepAround = true;
                return true;
            }
            else
                return false;
        }

        private static bool IsUpRightFree(int row, int col, ref bool canStepAround)
        {
            if (row - 1 >= 0 && col + 1 < matrix.GetLength(1)
             && matrix[row - 1, col + 1] == default(int))
            {
                //we have found a free step around our position
                canStepAround = true;
                return true;
            }
            else
                return false;
        }

        private static bool isRightFree(int row, int col, ref bool canStepAround)
        {
            if (col + 1 < matrix.GetLength(1)
             && matrix[row, col + 1] == default(int))
            {
                //we have found a free step around our position
                canStepAround = true;
                return true;
            }
            else
                return false;
        }

        //the methods that walk the matrix
        private static void StepRightDown(ref int row, ref int col, ref int counter)
        {      
            matrix[row + 1, col + 1] = counter;
            row++;
            col++;
            counter++;
        }

        private static void StepDown(ref int row, ref int col, ref int counter)
        {
            matrix[row + 1, col] = counter;
            row++;
            counter++;
        }

        private static void StepLeftDown(ref int row, ref int col, ref int counter)
        {
            matrix[row + 1, col - 1] = counter;
            row++;
            col--;
            counter++;
        }

        private static void StepLeft(ref int row, ref int col, ref int counter)
        {
            matrix[row, col - 1] = counter;
            col--;
            counter++;
        }

        private static void StepLeftUp(ref int row, ref int col, ref int counter)
        {
            matrix[row - 1, col - 1] = counter;
            col--;
            row--;
            counter++;
        }

        private static void StepUp(ref int row, ref int col, ref int counter)
        {
            matrix[row - 1, col] = counter;
            row--;
            counter++;
        }

        private static void StepUpRight(ref int row, ref int col, ref int counter)
        {
            matrix[row - 1, col + 1] = counter;
            row--;
            col++;
            counter++;
        }

        private static void StepRight(ref int row, ref int col, ref int counter)
        {
            matrix[row, col + 1] = counter;
            col++;
            counter++;
        }

        //this method will find the first free cell, closest to the top row
        private static void FindFreeStep(ref int row, ref int col, ref bool canStepAround)
        {
            for (int curRow = 0; curRow < matrix.GetLength(0); curRow++)
            {
                for (int curCol = 0; curCol < matrix.GetLength(1); curCol++)
                {
                    if (matrix[curRow, curCol] == default(int))
                    {
                        /*we move the current position top-left from the free one,
                        because the filling will start down-right from current position*/
                        row = curRow -1;
                        col = curCol -1;
                        canStepAround = true;
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
