using System;

class BiggestAreaOfSameNumbers
{
    //define different matrixes for different tests

    //original test
    //static int[,] myMatrix = {
    //                        {1, 3, 2, 2, 1, 4},
    //                        {3, 3, 3, 2, 4, 4},
    //                        {4, 3, 1, 2, 3, 3},
    //                        {4, 3, 1, 3, 3, 1},
    //                        {4, 3, 3, 3, 1, 1}
    //                      };

    static int[,] myMatrix = { {1, 3, 3, 3, 2, 4},
                        {3, 3, 3, 2, 4, 4},
                        {4, 3, 1, 2, 3, 3},
                        {4, 3, 1, 3, 3, 1},
                        {4, 3, 3, 3, 1, 1}
                      };

    //static int[,] myMatrix = {
    //                       {1,2,3,4},
    //                       {1,2,2,2},
    //                       {1,2,2,2}
    //                   };

    //define a char matrix to store which position we have visited
    static bool[,] visitedMatrix = new bool[myMatrix.GetLength(0), myMatrix.GetLength(1)];
    static int biggest = int.MinValue;
    static int currentBiggest = 0;
    static int currentNumber = int.MinValue;
    static int steps = 0;

    static void Main()
    {
        //print the given matrix of numbers
        Console.WriteLine("The matrix is: ");
        PrintMatrix(myMatrix);

        //find the biggest area


        for (int row = 0; row < myMatrix.GetLength(0); row++)
        {
            for (int col = 0; col < myMatrix.GetLength(1); col++)
            {
                currentNumber = myMatrix[row, col];
                currentBiggest = FindBiggestArea(currentBiggest, currentNumber, steps, row, col);
                Console.WriteLine("outside biggest: {0}", currentBiggest);

                if (currentBiggest > biggest)
                {
                    biggest = currentBiggest;
                }

                Console.WriteLine("BIGGEST : {0}", biggest);

                currentBiggest = 0;
                steps = 0;

                //reset the field in the visited matrix so we can check it again
                visitedMatrix = new bool[myMatrix.GetLength(0), myMatrix.GetLength(1)];
            }
        }

        Console.WriteLine("The biggest area is: {0}", biggest);
    }

    //define the recursive function that finds the biggest area
    static int FindBiggestArea(int currentBiggest, int currentNumber, int steps, int row, int col)
    {
        if (visitedMatrix[row, col] == true || myMatrix[row, col] != currentNumber)
        {
            return currentBiggest;
        }
        else
        {
            visitedMatrix[row, col] = true;
            currentBiggest++;
            steps++;

            //define these variables for the four current biggest numbers returned from the recursive call of the function in the four directions
            int currentBiggest1 = 0;
            int currentBiggest2 = 0;
            int currentBiggest3 = 0;
            int currentBiggest4 = 0;

            if (col + 1 < visitedMatrix.GetLength(1))
                currentBiggest1 = FindBiggestArea(currentBiggest, currentNumber, steps, row, col + 1);
            if (row - 1 >= 0)
                currentBiggest2 = FindBiggestArea(currentBiggest, currentNumber, steps, row - 1, col);
            if (col - 1 >= 0)
                currentBiggest3 = FindBiggestArea(currentBiggest, currentNumber, steps, row, col - 1);
            if (row + 1 < visitedMatrix.GetLength(0))
                currentBiggest4 = FindBiggestArea(currentBiggest, currentNumber, steps, row + 1, col);

            //find the biggest value returned
            currentBiggest = FindMax(currentBiggest1, currentBiggest2, currentBiggest3, currentBiggest4);

            int[] biggestsArr = { currentBiggest1, currentBiggest2, currentBiggest3, currentBiggest4 };
            int newCurrentBiggest = currentBiggest;

            for (int i = 0; i < biggestsArr.Length; i++)
            {
                if (biggestsArr[i] != currentBiggest && biggestsArr[i] != 0)
                {
                    newCurrentBiggest += biggestsArr[i] - steps;
                    Console.WriteLine("The sum:{0}", currentBiggest);
                }
            }

            //
            Console.WriteLine("Number: {0} currentBiggest: {1} steps: {2}", currentNumber, currentBiggest, steps);
            Console.WriteLine("currentBiggest1: {0} currentBiggest2: {1} currentBiggest3 {2} currentBiggest4 {3}", biggestsArr[0], biggestsArr[1], biggestsArr[2], biggestsArr[3]);
            Console.WriteLine();
            return newCurrentBiggest;
        }
    }

    //
    static int FindMax(int currentBiggest1, int currentBiggest2, int currentBiggest3, int currentBiggest4)
    {
        int max = 0;

        int[] arr = { currentBiggest1, currentBiggest2, currentBiggest3, currentBiggest4 };

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
            }
        };

        return max;
    }

    //define a method to print the matrix
    static void PrintMatrix(int[,] matrix)
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

