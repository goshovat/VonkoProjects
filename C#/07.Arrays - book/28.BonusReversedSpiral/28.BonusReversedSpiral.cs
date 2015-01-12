using System;

class BonusReversedSpiral
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[,] matrix = new int[n,n];

        string direction = "down";
        int currentNumber = 0;

        //set the start row and col
        int row = matrix.GetLength(0) / 2;

        if (n % 2 == 0)
        {
            row--;
        }

        int col = matrix.GetLength(1) / 2;

        int maxSteps = 1;
        int currentSteps = 0;
        int changeDirection = 0;

        for (int i = 0; i < matrix.Length; i++)
        {
            matrix[row, col] = currentNumber;

            switch (direction)
            {
                case "down" :                     
                        currentSteps++;    

                        if (currentSteps > maxSteps)
                        {
                            direction = "left";
                            col--;
                            changeDirection++;
                            currentSteps = 1;

                            if (changeDirection % 2 == 0)
                            {
                                maxSteps++;
                            }
                        }
                        else
                        {
                            row++;
                        }

                    break;

                case "left":
                    currentSteps++;

                    if (currentSteps > maxSteps)
                    {
                        direction = "up";
                        row--;
                        changeDirection++;
                        currentSteps = 1;

                        if (changeDirection % 2 == 0)
                        {
                            maxSteps++;
                        }
                    }
                    else
                    {
                        col--;
                    }

                    break;

                case "up" :
                    currentSteps++;

                    if (currentSteps > maxSteps)
                    {
                        direction = "right";
                        col++;
                        changeDirection++;
                        currentSteps = 1;

                        if (changeDirection % 2 == 0)
                        {
                            maxSteps++;
                        }
                    }
                    else
                    {
                        row--;
                    }
                    break;

                case "right" :
                    currentSteps++;

                    if (currentSteps > maxSteps)
                    {
                        direction = "down";
                        row++;
                        changeDirection++;
                        currentSteps = 1;

                        if (changeDirection % 2 == 0)
                        {
                            maxSteps++;
                        }
                    }
                    else
                    {
                        col++;
                    }
                    break;
            }

            currentNumber++;
        }

        PrintMatrix(matrix);
    }

    private static void PrintMatrix(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row, col].ToString().PadLeft(4));
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}

