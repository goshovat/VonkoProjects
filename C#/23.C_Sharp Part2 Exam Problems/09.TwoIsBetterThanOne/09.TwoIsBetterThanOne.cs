namespace TwoIsBetterThanOne
{
    using System;
    using System.Linq;
    using System.Text;

    class TwoIsBetterThanOne
    {
        private static char[] luckyDigits = new char[] {'3', '5'};
        static ulong lowerBound;
        static ulong upperBound;
        static char[] currentNumber;
        private static int luckyNumbers = 0;

        private static int smallestNumber = 0;

        static void Main()
        {
            //first task
            CountLuckyNumbers();
            Console.WriteLine(luckyNumbers);
            //second task
            GetSmallestNumber();
            Console.WriteLine(smallestNumber);
        }

        private static void CountLuckyNumbers()
        {
            string[] input = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            lowerBound = ulong.Parse(input[0]);
            upperBound = ulong.Parse(input[1]);

            int maxLen = Math.Max(input[0].Length, input[1].Length);
            int minLen = Math.Min(input[0].Length, input[1].Length);

            for (int currentLen = minLen; currentLen <= maxLen; currentLen++)
            {
                currentNumber = new char[currentLen];
                GenerateNumbers(0, currentLen);
            }
        }

        private static void GenerateNumbers(int index, int currentLen)
        {
            if (index == currentLen)
            {
                if (IsLuckyNumber())
                {
                    luckyNumbers++;                   
                }
                return;
            }

            for (int i = 0; i < luckyDigits.Length; i++)
            {
                currentNumber[index] = luckyDigits[i];
                GenerateNumbers(index + 1, currentLen);
            }
        }

        private static bool IsLuckyNumber()
        {
            StringBuilder numberStr = new StringBuilder();
            for (int i = 0; i < currentNumber.Length; i++)
            {
                if (currentNumber[i] != currentNumber[currentNumber.Length - 1 - i])
                {
                    return false;
                }
                numberStr.Append(currentNumber[i]);
            }
            ulong number = ulong.Parse(numberStr.ToString());

            if (number < lowerBound || number > upperBound)
                return false;

            return true;
        }

        private static void GetSmallestNumber()
        {
            string[] secondTaskList = Console.ReadLine().Split(',');
            int percent = int.Parse(Console.ReadLine());

            int[] numbersList = 
                secondTaskList.Select(n => int.Parse(n)).ToArray();

            Array.Sort(numbersList);
            smallestNumber = numbersList[(percent * numbersList.Length - 1) / 100];
        }
    }
}
