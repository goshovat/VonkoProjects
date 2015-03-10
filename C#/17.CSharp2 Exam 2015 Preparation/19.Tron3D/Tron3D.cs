using System;
using System.Linq;

class Tron3D
{
    private static int origHeight = 0;
    private static int height = 0;
    private static int startWidth = 0;
    private static int otherWidth = 0;

    static void Main()
    {
        int[] sizes = Console.ReadLine().Split()
            .Select(int.Parse).ToArray();

        origHeight = sizes[0];
        height = origHeight + 1;
        startWidth = sizes[1];
        otherWidth = sizes[2];
        char[,] field = new char[height, 2 * startWidth + 2 * otherWidth];

        string redMoves = Console.ReadLine();
        string blueMoves = Console.ReadLine();

        //string[] directions = new string[] { "east", "south", "west", "north" };
        int[] directions = new int[] { 0, 1, 2, 3 };
        int[] redCoords = new int[] { origHeight / 2, startWidth / 2 }; //row, col
        int[] newRedCoords = new int[] { origHeight / 2, startWidth / 2 }; ;
        int redDir = 0;
        int blueDir = 2;
        int[] blueCoords = new int[] {origHeight / 2, 
            startWidth + otherWidth + startWidth /2}; //row, col
        int[] newBlueCoords = new int[] {origHeight / 2, 
            startWidth + otherWidth + startWidth /2};

        int redMoveIndex = 0;
        int blueMoveIndex = 0;

        bool isRedCrashed = false;
        bool isBlueCrashed = false;
        char redMove = default(char);
        char blueMove = default(char);
        bool isRedCrashedForbWall = false;
        double redDistance = 0;

        while (true)
        {
            while (true)
            {
                if (redMoveIndex < redMoves.Length)
                    redMove = redMoves[redMoveIndex];

                switch (redMove)
                {
                    case 'R':
                        redDir++;
                        if (redDir == directions.Length)
                            redDir = 0;
                        break;
                    case 'L':
                        redDir--;
                        if (redDir < 0)
                            redDir = directions.Length - 1;
                        break;
                    case 'M':
                        switch (redDir)
                        {
                            case 0:
                                newRedCoords[1] = redCoords[1] + 1;
                                if (newRedCoords[1] == (2 * startWidth + 2 * otherWidth))
                                    newRedCoords[1] = 0;
                                break;
                            case 1:
                                newRedCoords[0] = redCoords[0] - 1;
                                if (newRedCoords[0] < 0)
                                {
                                    isRedCrashed = true;
                                    isRedCrashedForbWall = true;
                                }
                                break;
                            case 2:
                                newRedCoords[1] = redCoords[1] - 1;
                                if (newRedCoords[1] < 0)
                                    newRedCoords[1] = (2 * startWidth + 2 * otherWidth) - 1;
                                break;
                            case 3:
                                newRedCoords[0] = redCoords[0] + 1;
                                if (newRedCoords[0] == height)
                                {
                                    isRedCrashed = true;
                                    isRedCrashedForbWall = true;
                                }
                                break;
                        }
                        break;
                }

                redMoveIndex++;

                if (redMove == 'M')
                    break;
            }

            while (true)
            {
                if (blueMoveIndex < blueMoves.Length)
                    blueMove = blueMoves[blueMoveIndex];

                switch (blueMove)
                {
                    case 'R':
                        blueDir++;
                        if (blueDir == directions.Length)
                            blueDir = 0;
                        break;
                    case 'L':
                        blueDir--;
                        if (blueDir < 0)
                            blueDir = directions.Length - 1;
                        break;
                    case 'M':
                        switch (blueDir)
                        {
                            case 0:
                                newBlueCoords[1] = blueCoords[0] + 1;
                                if (newBlueCoords[1] == (2 * startWidth + 2 * otherWidth))
                                    newBlueCoords[1] = 0;
                                break;
                            case 1:
                                newBlueCoords[0] = blueCoords[0] - 1;
                                if (newBlueCoords[0] < 0)
                                    isBlueCrashed = true;
                                break;
                            case 2:
                                newBlueCoords[1] = blueCoords[1] - 1;
                                if (newBlueCoords[1] < 0)
                                    newBlueCoords[1] = (2 * startWidth + 2 * otherWidth - 1);
                                break;
                            case 3:
                                newBlueCoords[0] = blueCoords[0] + 1;
                                if (newBlueCoords[0] == height)
                                    isBlueCrashed = true;
                                break;
                        }
                        break;
                }

                blueMoveIndex++;

                if (blueMove == 'M')
                    break;
            }

            //check for collisions
            //both players hit their heads
            if (newRedCoords[0] == newBlueCoords[0] &&
                newRedCoords[1] == newBlueCoords[1])
            {
                isRedCrashed = true;
                isBlueCrashed = true;
            }
            else
            {   
                if (newRedCoords[0] < height && 
                    field[newRedCoords[0], newRedCoords[1]] != default(char))
                    isRedCrashed = true;

                if (newBlueCoords[0] < height &&
                    field[newBlueCoords[0], newBlueCoords[1]] != default(char))
                    isBlueCrashed = true;
            }

            if (isRedCrashed && isBlueCrashed) 
            {
                Console.WriteLine("DRAW");

                if (isRedCrashedForbWall)
                    redDistance = GetDistanceFromStart(redCoords[0],
                        redCoords[1]);
                else
                    redDistance = GetDistanceFromStart(newRedCoords[0],
                        newRedCoords[1]);

                Console.WriteLine(redDistance);
                break;
            }
            else if (isRedCrashed || isBlueCrashed) 
            {
                if (isRedCrashed) 
                {
                    Console.WriteLine("BLUE");

                    redDistance = GetDistanceFromStart(newRedCoords[0],
                        newRedCoords[1]);
                    Console.WriteLine(redDistance);
                }
                else if (isBlueCrashed) 
                {
                    Console.WriteLine("RED");

                    if (isRedCrashedForbWall)
                        redDistance = GetDistanceFromStart(redCoords[0],
                            redCoords[1]);
                    else
                        redDistance = GetDistanceFromStart(newRedCoords[0],
                            newRedCoords[1]);

                    Console.WriteLine(redDistance);
                }
                break;
            }
            //nobody crashed and game continues
            else 
            {
                field[newRedCoords[0], newRedCoords[1]] = 'V';
                field[newBlueCoords[0], newBlueCoords[1]] = 'V';

                redCoords[0] = newRedCoords[0];
                redCoords[1] = newRedCoords[1];
                blueCoords[0] = newBlueCoords[0];
                blueCoords[1] = newBlueCoords[1];
            }
        }
    }

    //private static int CalculateRedDistance(int rowRed, int colRed)
    //{
    //    int rowsPassed = Math.Abs(rowRed - origHeight / 2);
    //    int colsPassed = 0;

    //    if (colRed < (startWidth + otherWidth + startWidth / 2))
    //        colsPassed = colRed - startWidth / 2;
    //    else
    //        colsPassed = (2 * startWidth + 2 * otherWidth) - colRed +
    //            startWidth / 2;

    //    return rowsPassed + colsPassed;
    //}

    static double GetDistanceFromStart(int row, int col)
    {
        if (col > otherWidth + startWidth + startWidth / 2)
            col = 2 * otherWidth + startWidth - col;

        return Math.Abs(col - startWidth / 2) + Math.Abs(row - origHeight / 2);
    }
}
