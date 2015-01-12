namespace OneTaskIsNotEnough
{
    using System;

    class OneTaskIsNotEnough
    {
        static void Main()
        {
            SolveFirstTast();

            SolveSecondTask();
        }

        private static void SolveFirstTast()
        {
            int numberLamps = int.Parse(Console.ReadLine());

            const int maxLamps = 2000000;
            int[] lampsToTurnOn = new int[maxLamps + 1];
            int[] lampsToTurnOff = new int[maxLamps + 1];
            for (int i = 1; i <= numberLamps; i++)
            {
                lampsToTurnOff[i] = i;
            }

            int lampsOff = numberLamps;
            int jump = 0;

            while (lampsOff > 0)
            {
                jump++;
                int index = 1;
                while (index <= lampsOff)
                {
                    lampsToTurnOn[index] = jump;
                    index += jump + 1;
                }

                int updatedLampsOff = 0;
                for (int i = 1; i <= lampsOff; i++)
                {
                    if (lampsToTurnOn[i] != jump)
                    {
                        updatedLampsOff++;
                        lampsToTurnOff[updatedLampsOff] = lampsToTurnOff[i];
                    }
                }

                lampsOff = updatedLampsOff;
            }

            Console.WriteLine(lampsToTurnOff[1]);
        }

        private static void SolveSecondTask()
        {
            //two sequences of commands
            for (int sequences = 0; sequences < 2; sequences++)
            {
                string commands = Console.ReadLine();

                int[] verticalMoves = { 1, 0, -1, 0 };
                int[] horizontalMoves = { 0, 1, 0, -1 };

                int currentRow = 0;
                int currentCol = 0;

                int direction = 0;
                for (int i = 0; i < 4; i++)
                {
                    for (int command = 0; command < commands.Length; command++)
                    {
                        switch (commands[command])
                        {
                            case 'S':
                                currentRow += verticalMoves[direction];
                                currentCol += horizontalMoves[direction];
                                break;

                            case 'L':
                                direction += 3;
                                direction = direction % 4;
                                break;

                            case 'R':
                                direction += 1;
                                direction = direction % 4;
                                break;
                        }
                    }
                }

                if (currentRow == 0 && currentCol == 0)
                {
                    Console.WriteLine("bounded");
                }
                else
                {
                    Console.WriteLine("unbounded");
                }
            }
        }
    }
}
