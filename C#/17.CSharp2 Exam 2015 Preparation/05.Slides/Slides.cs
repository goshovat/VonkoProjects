using System;

class Slides
{
    private static string[, ,] cube;
    static void Main()
    {
        string[] input1 = Console.ReadLine().Split();
        int width = int.Parse(input1[0]);
        int height = int.Parse(input1[1]);
        int depth = int.Parse(input1[2]);

        cube = new string[width, height, depth];

        for (int row = 0; row < height; row++) 
        {
            string[] currentRow = Console.ReadLine().Trim().Split('|');

            for (int layer = 0; layer < depth; layer++)
            {
                string[] currentLayer = currentRow[layer].Trim().Split(new char[] {')', '('},
                    StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < width; col++)
                {
                    cube[col, row, layer] = currentLayer[col];
                }
            }
        }

        string[] ballCoords = Console.ReadLine().Split();
        int ballWidth = int.Parse(ballCoords[0]);
        int ballHeight = 0;
        int ballDepth = int.Parse(ballCoords[1]);

        int prevBallWidth = ballWidth;
        int prevBallHeight = ballHeight;
        int prevBallDepth = ballDepth;
        //start movig the ball
        while (true)
        {
            //check if the ball exited the right way
            if (ballHeight >= height)
            {
                Console.WriteLine("Yes");
                Console.WriteLine("{0} {1} {2}", 
                    prevBallWidth, prevBallHeight, prevBallDepth);
                break;
            }
            else if (ballWidth < 0 || ballWidth >= width || //???
                ballHeight >= height || ballDepth < 0 || ballDepth >= depth)
            {
                Console.WriteLine("No");
                Console.WriteLine("{0} {1} {2}", 
                    prevBallWidth, prevBallHeight, prevBallDepth);
                break;
            }

            prevBallWidth = ballWidth;
            prevBallHeight = ballHeight;
            prevBallDepth = ballDepth;

            string[] currentCommand = 
                cube[ballWidth, ballHeight, ballDepth].Split();

            if (currentCommand.Length == 1)
            {
                if (currentCommand[0] == "E")
                {
                    ballHeight++;
                }
                else if (currentCommand[0] == "B")
                {
                    Console.WriteLine("No");
                    Console.WriteLine("{0} {1} {2}", 
                        prevBallWidth, prevBallHeight, prevBallDepth);
                    break;
                }
            }
            else
            {
                if (currentCommand[0] == "S")
                {
                    for (int i = 0; i < currentCommand[1].Length; i++) 
                    {
                        switch(currentCommand[1][i]) 
                        {
                            case 'L':
                                ballWidth--;
                                break;
                            case 'R':
                                ballWidth++;
                                break;
                            case 'F':
                                ballDepth--;
                                break;
                            case 'B':
                                ballDepth++;
                                break;
                        }
                    }
                    ballHeight++;
                }
                else if (currentCommand[0] == "T")
                {
                    ballWidth = int.Parse(currentCommand[1]);
                    ballDepth = int.Parse(currentCommand[2]);
                }
            }
        }


    }
}
