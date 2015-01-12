namespace Trails3D
{
    using System;
    using System.Text;

    class Trails3D
    {
        private const int NUMBER_PLAYERS = 2;

        static void Main()
        {
            //get the input info
            string[] sizes = Console.ReadLine().Split(' ');
            int oldHeight = int.Parse(sizes[1]);
            int oldWidth = int.Parse(sizes[0]);
            int oldDepth = int.Parse(sizes[2]);
            int width = 2 * (oldWidth + oldDepth);
            int height = oldHeight + 1;
            bool[,] visited = new bool[width, height];
            string redMoves = ParseCommand(Console.ReadLine());
            string blueMoves = ParseCommand(Console.ReadLine());
            //create some structures to store the players information
            int[,] playerPositions = { { oldWidth / 2, oldHeight / 2 }, 
                                     { oldWidth + oldDepth + oldWidth / 2, oldHeight / 2 } };
            int[] directionsCol = { 1, 0, -1, 0 };
            int[] directionsRow = { 0, -1, 0, 1 };
            int[] playerDirections = { 0, 2 };
            string[] playerMoves = { redMoves, blueMoves };
            int[] playerMoveIndexes = { 0, 0 };
            bool[] outside = { false, false };

            //start the game
            while (true)
            {
                //iterate through both players
                for (int player = 0; player < NUMBER_PLAYERS; player++)
                {
                    visited[playerPositions[player, 0], playerPositions[player, 1]] = true;
                    char currentMove = default(char);

                    if (playerMoveIndexes[player] < playerMoves[player].Length)
                        currentMove = playerMoves[player][playerMoveIndexes[player]];

                    playerMoveIndexes[player]++;

                    if (currentMove == 'L' || currentMove == 'R')
                    {
                        playerDirections[player] += (currentMove == 'R') ? 1 : 3;
                        playerDirections[player] %= 4;
                        //we will process again this player
                        player--;
                        continue;
                    }
                    else
                    {
                        int newCol = playerPositions[player, 0] + directionsCol[playerDirections[player]];
                        int newRow = playerPositions[player, 1] + directionsRow[playerDirections[player]];

                        if (newRow < 0 || newRow >= height)
                        {
                            outside[player] = true;
                            //if the red player crashes on the forbidden wall 
                            //we must take his position just before the crash
                            continue;
                        }

                        if (newCol < 0 || newCol >= width)
                        {
                            newCol += width;
                            newCol %= width;
                        }

                        playerPositions[player, 0] = newCol;
                        playerPositions[player, 1] = newRow;
                    }
                }

                //after each game cycle check if the some player has lost
                bool headOnCrash = (playerPositions[0, 0] == playerPositions[1, 0] &&
                    playerPositions[0, 1] == playerPositions[1, 1]);
                bool redLost = headOnCrash || visited[playerPositions[0, 0], playerPositions[0, 1]] || outside[0];
                bool blueLost = headOnCrash || visited[playerPositions[1, 0], playerPositions[1, 1]] || outside[1];

                if (blueLost || redLost)
                {
                    if (blueLost && redLost) Console.WriteLine("DRAW");
                    else if (blueLost) Console.WriteLine("RED");
                    else if (redLost) Console.WriteLine("BLUE");
                    Console.WriteLine(CalculateFinalDistance(playerPositions[0, 0], playerPositions[0, 1], oldWidth, oldHeight, oldDepth));
                    return;
                }
            }
        }

        private static string ParseCommand(string command)
        {
            StringBuilder commandBuilder = new StringBuilder();
            for (var i = 0; i < command.Length; i++)
            {
                var cmd = command[i];
                if ('0' < cmd && cmd <= '9')
                {
                    i++;
                    var count = cmd - '0';
                    var ch = command[i];
                    for (int j = 0; j < count; j++)
                    {
                        commandBuilder.Append(ch);
                    }
                }
                else
                {
                    commandBuilder.Append(cmd);
                }
            }
            return commandBuilder.ToString();
        }

        private static int CalculateFinalDistance
            (int redCol, int redRow, int oldWidth, int oldHeight, int oldDepth)
        {
            if (redCol > oldWidth + oldDepth + oldWidth / 2)
                redCol = 2 * oldDepth + oldWidth - redCol;

            int colComponent = Math.Abs(redCol - oldWidth / 2);
            int rowComponent = Math.Abs(redRow - oldHeight / 2);

            return colComponent + rowComponent;
        }
    }
}