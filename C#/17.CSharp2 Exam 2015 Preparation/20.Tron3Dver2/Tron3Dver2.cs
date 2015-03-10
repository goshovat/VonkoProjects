using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Tron3Dver2
{
    static void Main()
    {
        int[] xyz = Console.ReadLine().Split(' ')
        .Select(int.Parse).ToArray();

        int oldHeight = xyz[0], oldWidth = xyz[1], oldDepth = xyz[2];
        string[] commands = { Console.ReadLine(), Console.ReadLine() };

        //the data of red player and blue player
        int[] dims = { 2 * (oldWidth + oldDepth), oldHeight + 1 };
        bool[,] visited = new bool[dims[0], dims[1]];
        int[] playerDirections = { 0, 2 };
        int[] directionsCol = { 1, 0, -1, 0 };
        int[] directionsRow = { 0, 1, 0, -1 };

        int[,] playerPositions = {{oldWidth/2, oldHeight/2},
                                     {oldWidth + oldDepth + oldWidth/2, oldHeight/2}};
        bool[] outside = { false, false };
        int[] commandIndexes = { 0, 0 };

        //start the game
        while (true)
        {
            //iterate through both players
            for (int player = 0; player < 2; player++)
            {
                visited[playerPositions[player, 0], playerPositions[player, 1]] = true;
                char cmd = default(char);

                if (commandIndexes[player] < commands[player].Length)
                    cmd = commands[player][commandIndexes[player]];

                commandIndexes[player] += 1;

                //turn or move?
                if (cmd == 'L' || cmd == 'R')
                {
                    playerDirections[player] += (cmd == 'L') ? 1 : 3;
                    playerDirections[player] %= 4;
                    //read the next command of this player
                    player--;
                    continue;
                }
                else
                {
                    int newCol = playerPositions[player, 0] + directionsCol[playerDirections[player]];
                    int newRow = playerPositions[player, 1] + directionsRow[playerDirections[player]];

                    if (newRow < 0 || newRow >= dims[1])
                    {
                        outside[player] = true;
                        //if the red player crashes on the forbidden wall 
                        //we must take his position just before the crash   
                        continue;
                    }

                    if (newCol < 0 || newCol >= dims[0])
                    {
                        //loop over to the other side
                        newCol += dims[0];
                        newCol %= dims[0];
                    }

                    playerPositions[player, 0] = newCol;
                    playerPositions[player, 1] = newRow;
                }
            }

            //after each game cycle when both players move check if somebody died
            bool headOnCollision = playerPositions[0, 0] == playerPositions[1, 0]
                                && playerPositions[0, 1] == playerPositions[1, 1];

            bool redDied = visited[playerPositions[0, 0], playerPositions[0, 1]] || headOnCollision || outside[0];
            bool blueDied = visited[playerPositions[1, 0], playerPositions[1, 1]] || headOnCollision || outside[1];

            if (redDied || blueDied)
            {
                if (redDied && blueDied) Console.WriteLine("DRAW");
                else if (redDied) Console.WriteLine("BLUE");
                else if (blueDied) Console.WriteLine("RED");
                double finalDistance = GetDistanceFromStart(playerPositions[0, 0], playerPositions[0, 1], oldHeight, oldWidth, oldDepth);
                Console.WriteLine(finalDistance);
                return;
            }
        }
    }

    static double GetDistanceFromStart(int col, int row, int oldHeight, int oldWidth, int oldDepth)
    {
        if (col > oldDepth + oldWidth + oldWidth / 2)
            col = 2 * oldDepth + oldWidth - col;

        return Math.Abs(col - oldWidth / 2) + Math.Abs(row - oldHeight / 2);
    }
}
