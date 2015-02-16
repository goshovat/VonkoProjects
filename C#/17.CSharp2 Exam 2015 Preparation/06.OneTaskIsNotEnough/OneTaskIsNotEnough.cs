using System;
using System.Collections.Generic;

class OneTaskIsNotEnough
{
    static void Main()
    {
        int numberLamps = int.Parse(Console.ReadLine());
        string commands1 = Console.ReadLine();
        string commands2 = Console.ReadLine();

        ExecuteFirstTask(numberLamps);
        ExecuteSecondTask(commands1);
        ExecuteSecondTask(commands2);

        //// Second task
        //Console.WriteLine(SolveSecondTask(commands1));

        //// Second task again
        //Console.WriteLine(SolveSecondTask(commands2));
    }

    private static void ExecuteFirstTask(int numberLamps)
    {
        int[] allLamps = new int[numberLamps];

        for (int i = 0; i < numberLamps; i++)
        {
            allLamps[i] = i + 1;
        }

        int step = 1;
        while (true)
        {
            int[] lampsRemainedOn = new int[numberLamps];
            int remainedIndex = 0;

            for (int i = 1; i < numberLamps; i++)
            {
                if (i % (step + 1) == 0)
                {
                    //turn off this lamp
                }
                else
                {
                    allLamps[remainedIndex] = allLamps[i];
                    remainedIndex++;
                }
            }
            step++;
            numberLamps = remainedIndex;

            if (numberLamps == 1)
            {
                Console.WriteLine(allLamps[0]);
                break;
            }
        }
    }

    private static void ExecuteSecondTask(string commands)
    {
        string[] directions = new string[] { "forward", "right", "back", "left" };

        int directionIndex = 0;
        string direction = directions[directionIndex];
        int row = 0;
        int col = 0;

        for (int j = 0; j < 4; j++)
        {
            for (int commandIndex = 0; commandIndex < commands.Length; commandIndex++)
            {
                char command = commands[commandIndex];

                switch (command) 
                { 
                    case 'L':
                        directionIndex--;
                        if (directionIndex < 0)
                            directionIndex = 3;

                        direction = directions[directionIndex];
                        break;
                    case 'R':
                        directionIndex++;
                        if (directionIndex > 3)
                            directionIndex = 0;

                        direction = directions[directionIndex];
                        break;
                }

                switch (direction)
                {
                    case "forward":
                        row--;
                        break;
                    case "right":
                        col++;
                        break;
                    case "back":
                        row++;
                        break;
                    case "left":
                        col--;
                        break;
                }
            }
        }

        if (row == 0 && col == 0)
        {
            Console.WriteLine("bounded");
        }
        else
        {
            Console.WriteLine("unbounded");
        }
    }
}