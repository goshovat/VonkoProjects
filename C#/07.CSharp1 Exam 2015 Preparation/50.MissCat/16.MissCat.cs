using System;

class MissCat
{
    static void Main()
    {
        int judges = int.Parse(Console.ReadLine());

        int votes1 = 0, votes2 = 0, votes3 = 0, votes4 = 0, votes5 = 0, votes6 = 0,
            votes7 = 0, votes8 = 0, votes9 = 0, votes10 = 0, votes0 = 0;

        int[] votesArr = new int[] {votes0, votes1, votes2, votes3, votes4, votes5, votes6,
                                        votes7, votes8, votes9, votes10};


        for (int i = 0; i < judges; i++)
        {
            int input = int.Parse(Console.ReadLine());

            votesArr[input]++; 
        }

        int max = 0;
        int winnerCatIndex = 0;
        int currentValue = 0;

        for (int i = 0; i < votesArr.Length; i++)
        {
           currentValue = votesArr[i];

           if (currentValue > max)
           {
               max = currentValue;
           }
        }

        winnerCatIndex = Array.IndexOf(votesArr, max);

        Console.WriteLine(winnerCatIndex);
    }
}



