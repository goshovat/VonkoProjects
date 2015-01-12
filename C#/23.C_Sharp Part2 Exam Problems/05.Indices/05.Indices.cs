namespace Indices
{
    using System;
    using System.Text;

    class Indices
    {
        private const int DEFAULT_START_INDEX = 0;
        static void Main()
        {
            int numberElements = int.Parse(Console.ReadLine());
            string[] array = Console.ReadLine().Split(' ');

            PrintSequence(array);
        }

        private static void PrintSequence(string[] array)
        {
            StringBuilder sequence = new StringBuilder();
            bool[] visited = new bool[array.Length];
            int currentIndex = DEFAULT_START_INDEX;
            int startCycle = -1;

            while (true)
            {
                if (currentIndex >= array.Length || currentIndex < 0)
                {
                    break;
                }
                if (visited[currentIndex])
                {
                    startCycle = currentIndex;
                    break;
                }
                sequence.Append(currentIndex);
                sequence.Append(" ");
                visited[currentIndex] = true;
                currentIndex = int.Parse(array[currentIndex]);
            }

            if (startCycle >= 0)
            {
                int index = sequence.ToString().IndexOf((" " + startCycle + " ").ToString());

                if (index < 0)
                {
                    sequence.Insert(0, "(");
                }
                else
                {
                    sequence[index] = '(';
                }
                sequence[sequence.Length - 1] = ')';
            }
            Console.WriteLine(sequence.ToString().Trim());
        }

    }
}
