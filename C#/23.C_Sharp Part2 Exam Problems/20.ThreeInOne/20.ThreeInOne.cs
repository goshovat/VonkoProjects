namespace ThreeInOne
{
    using System;

    public class ThreeInOne
    {
        private static void Main()
        {
            SolveFirstTask();

            SolveSecondTask();

            SolveThirdTask();
        }

        private static void SolveFirstTask()
        {
            string[] points = Console.ReadLine().Split(
                new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            int numberWinners = 0;
            int indexWinner = 0;
            int maxPoints = 0;

            for (int player = 0; player < points.Length; player++)
            {
                int currentPoints = int.Parse(points[player]);
                if (currentPoints <= 21 && currentPoints > maxPoints)
                {
                    maxPoints = currentPoints;
                    numberWinners = 1;
                    indexWinner = player;
                }
                else if (currentPoints == maxPoints)
                {
                    numberWinners++;
                }
            }

            if (numberWinners == 1)
                Console.WriteLine(indexWinner);
            else
                Console.WriteLine(-1);
        }

        private static void SolveSecondTask()
        {
            string[] cakesInput = Console.ReadLine().Split(
                    new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries
                );
            int[] cakes = new int[cakesInput.Length];

            for (int cake = 0; cake < cakesInput.Length; cake++)
            {
                cakes[cake] = int.Parse(cakesInput[cake]);
            }
            Array.Sort(cakes, (a, b) => b - a);
            int totalPeople = int.Parse(Console.ReadLine()) + 1;
            int myCount = 0;

            for (int cake = 0; cake < cakes.Length; cake++)
            {
                if (cake % totalPeople == 0)
                {
                    myCount += cakes[cake];
                }
            }

            Console.WriteLine(myCount);
        }

        private static void SolveThirdTask()
        {
            string[] input = Console.ReadLine().Split();
            int currentGold = int.Parse(input[0]);
            int currentSilver = int.Parse(input[1]);
            int currentBronze = int.Parse(input[2]);
            int targetGold = int.Parse(input[3]);
            int targetSilver = int.Parse(input[4]);
            int targetBronze = int.Parse(input[5]);
            int operations = 0;

            while (true)
            {
                if (currentGold >= targetGold && 
                    currentSilver >= targetSilver && currentBronze >= targetBronze)
                {
                    Console.WriteLine(operations);
                    return;
                }

                operations++;

                if (currentGold < targetGold)
                {
                    if (currentSilver - targetSilver >= 11)
                    {
                        currentSilver -= 11;
                        currentGold++;
                        continue;
                    }
                    else if (currentBronze - targetBronze >= 11)
                    {
                        currentBronze -= 11;
                        currentSilver++;
                        continue;
                    }
                }
                else if (currentSilver < targetSilver)
                {
                    if (currentGold > targetGold)
                    {
                        currentGold--;
                        currentSilver += 9;
                        continue;
                    }
                    else if (currentBronze - targetBronze >= 11)
                    {
                        currentBronze -= 11;
                        currentSilver++;
                        continue;
                    }
                }
                else if (currentBronze < targetBronze)
                {
                    if (currentSilver > targetSilver)
                    {
                        currentSilver--;
                        currentBronze += 9;
                        continue;
                    }
                    else if (currentGold > targetGold)
                    {
                        currentGold--;
                        currentSilver += 9;
                        continue;
                    }
                }

                Console.WriteLine(-1);
                return;
            }

        }

        private static bool IsSumReached(
            int currentGold, int currentSilver, int currentBronze, int targetGold, int targetSilver, int targetBronze)
        {
            if (currentGold >= targetGold && currentSilver >= targetSilver && currentBronze >= targetBronze)
                return true;
            else
                return false;
        }
    }
}
