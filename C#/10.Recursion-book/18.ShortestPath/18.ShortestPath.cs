using System;
using System.Collections.Generic;

class ShortestPath
{
    static char[,] field = {
                               {' ','*',' ',' ',' ','*','*','*','*','*'},
                               {' ',' ',' ','*',' ',' ',' ',' ','*','*'},
                               {' ','*','*','*',' ',' ','*','*','*','*'},
                               {' ',' ',' ',' ','*',' ',' ',' ',' ','*'},
                               {' ',' ',' ',' ','*','*','*','*','*','*'},
                           };

    //static char[,] field = {
    //                           {' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},
    //                           {' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},
    //                           {' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},
    //                           {' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},
    //                           {' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},
    //                       };

    static int height = field.GetLength(0);
    static int width = field.GetLength(1);

    static List<FieldStep> openList = new List<FieldStep>();
    static List<FieldStep> finalPath = new List<FieldStep>();

    static void Main()
    {
        int startRow = 0;
        int startCol = 0;
        FieldStep startStep = new FieldStep(startRow, startCol);

        int endRow = 3;
        int endCol = 8;
        FieldStep endStep = new FieldStep(endRow, endCol);

        FindShortestPath(startStep, endStep);

        PrintResult(endStep);
    }

    //this is the method using the breadth first search algorithm
    static void FindShortestPath(FieldStep startStep, FieldStep endStep)
    {
        openList.Add(startStep);

        while (openList.Count != 0)
        {
            //check if the current step is in the field
            FieldStep currentStep = openList[0];

            if (currentStep.Row == endStep.Row && currentStep.Col == endStep.Col)
            {
                while (currentStep.Parent != null)
                {
                    finalPath.Add(currentStep);
                    currentStep = currentStep.Parent;
                }
            }

            openList.RemoveAt(0);
            field[currentStep.Row, currentStep.Col] = 'V';

            //start adding the neighbours of the current step

            if (currentStep.Row - 1 >= 0 && field[currentStep.Row - 1, currentStep.Col] == ' ')
            {
                FieldStep upNeigbour = new FieldStep(currentStep.Row - 1, currentStep.Col);
                upNeigbour.Parent = currentStep;
                openList.Add(upNeigbour);
            }

            if (currentStep.Col + 1 < width && field[currentStep.Row, currentStep.Col + 1] == ' ')
            {
                FieldStep rightNeighbour = new FieldStep(currentStep.Row, currentStep.Col + 1);
                rightNeighbour.Parent = currentStep;
                openList.Add(rightNeighbour);
            }

            if (currentStep.Row + 1 < height && field[currentStep.Row + 1, currentStep.Col] == ' ')
            {
                FieldStep downNeigbour = new FieldStep(currentStep.Row + 1, currentStep.Col);
                downNeigbour.Parent = currentStep;
                openList.Add(downNeigbour);
            }

            if (currentStep.Col - 1 > 0 && field[currentStep.Row, currentStep.Col - 1] == ' ')
            {
                FieldStep leftNeigbour = new FieldStep(currentStep.Row, currentStep.Col - 1);
                leftNeigbour.Parent = currentStep;
                openList.Add(leftNeigbour);
            }

        }
    }

    //this method will print the final result
    static void PrintResult(FieldStep endStep)
    {
        Console.WriteLine("Path found!");
        for (int i = finalPath.Count - 1; i >= 0; i--)
        {
            Console.WriteLine("Row: {0}, Col: {1}", finalPath[i].Row, finalPath[i].Col);

            if (finalPath[i].Row == endStep.Row && finalPath[i].Col == endStep.Col
                && i != 0)
            {
                Console.WriteLine();
                Console.WriteLine("Path found!");
            }
        }
        Console.WriteLine();
    }

}
