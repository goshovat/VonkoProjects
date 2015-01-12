namespace They_are_Green
{
    using System;

    class They_are_Green
    {
        static void Main()
        {
            int numberLetters = int.Parse(Console.ReadLine());
            char[] letters = new char[numberLetters];
            for (int i = 0; i < numberLetters; i++)
                letters[i] = Console.ReadLine().Trim()[0];

                Array.Sort(letters);
            int totalCount = 0;

            do
            {
                if (!HasConsecutiveLetters(letters))
                {
                    totalCount++;
                }
            }
            while (HasAnotherPermutation(letters));

            Console.WriteLine(totalCount);
        }

        private static bool HasConsecutiveLetters(char[] letters)
        {
            for (int i = 0; i < letters.Length - 1; i++)
            {
                if (letters[i] == letters[i + 1])
                    return true;
            }
            return false;
        }

        private static bool HasAnotherPermutation(char[] letters)
        {
            for (int i = letters.Length - 2; i >= 0; i--) 
            {
                if (letters[i] < letters[i + 1])
                {
                    int indexToSwapWith = letters.Length - 1;
                    while (letters[i] >= letters[indexToSwapWith])
                        indexToSwapWith--;

                    char temp = letters[i];
                    letters[i] = letters[indexToSwapWith];
                    letters[indexToSwapWith] = temp;

                    Array.Reverse(letters, i + 1, letters.Length - i - 1);
                    return true;
                }
            }
            return false;
        }
    }
}
