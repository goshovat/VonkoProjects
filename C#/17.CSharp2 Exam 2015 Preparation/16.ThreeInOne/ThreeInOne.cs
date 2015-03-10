using System;
using System.Collections.Generic;
using System.Linq;

class ThreeInOne
{
    static void Main()
    {
        SolveFirstTask();

        SolveSecondTask();

        SolveThirdTask();
    }

    private static void SolveFirstTask()
    {
        int[] points = Console.ReadLine().Split(',')
            .Select(n => int.Parse(n)).ToArray();

        int maxWinPoints = 0;
        int winPlayerCounts = 0;
        int winIndex = 0;

        for (int i = 0; i < points.Length; i++)
        {
            if (points[i] <= 21 && points[i] > maxWinPoints)
            {
                maxWinPoints = points[i];
                winPlayerCounts = 1;
                winIndex = i;
            }
            else if (points[i] == maxWinPoints)
            {
                winPlayerCounts++;
            }
        }

        if (winPlayerCounts == 1)
            Console.WriteLine(winIndex);
        else
            Console.WriteLine(-1);
    }

    private static void SolveSecondTask()
    {
        int[] sizes = Console.ReadLine().Split(',')
            .Select(n => int.Parse(n)).ToArray();
        int numberFriends = int.Parse(Console.ReadLine());

        //key is the cake size, value - the count
        SortedDictionary<int, int> cakes = new SortedDictionary<int, int>();
        for (int i = 0; i < sizes.Length; i++)
        {
            if (!cakes.ContainsKey(sizes[i]))
                cakes.Add(sizes[i], 1);
            else
                cakes[sizes[i]]++;
        }

        int myCakes = 0;
        while (cakes.Count > 0)
        {
            for (int i = 0; i < numberFriends + 1; i++)
            {
                int currentCakeSize = cakes.Last().Key;

                if (i == 0)
                    myCakes += currentCakeSize;

                if (cakes.Last().Value > 1)
                    cakes[currentCakeSize]--;
                else
                    cakes.Remove(currentCakeSize);

                if (cakes.Count == 0)
                    break;
            }
        }
        Console.WriteLine(myCakes);
    }

    private static void SolveThirdTask()
    {

        int[] coins = Console.ReadLine().Split(' ')
            .Select(n => int.Parse(n)).ToArray();

        int g1 = coins[0];
        int s1 = coins[1];
        int b1 = coins[2];
        int g2 = coins[3];
        int s2 = coins[4];
        int b2 = coins[5];

        int operations = 0;

        while (true)
        {
            if (b1 < b2)
            {
                if (s1 - 1 >= s2)
                {
                    s1--;
                    b1 += 9;
                    operations++;
                }
                else if (g1 - 1 >= g2)
                {
                    g1--;
                    s1 += 9;
                    operations++;
                }
                else
                {
                    Console.WriteLine(-1);
                    break;
                }
            }
            else if (s1 < s2)
            {
                if (g1 - 1 >= g2)
                {
                    g1--;
                    s1 += 9;
                    operations++;
                }
                else if (b1 - 11 >= b2)
                {
                    b1 -= 11;
                    s1++;
                    operations++;
                }
                else
                {
                    Console.WriteLine(-1);
                    break;
                }
            }
            else if (g1 < g2)
            {
                if (s1 - 11 >= s2)
                {
                    s1 -= 11;
                    g1++;
                    operations++;
                }
                else if (b1 - 11 >= b2)
                {
                    b1 -= 11;
                    s1++;
                    operations++;
                }
                else
                {
                    Console.WriteLine(-1);
                    break;
                }
            }
            else
            {
                Console.WriteLine(operations);
                break;
            }
        }
    }
}
