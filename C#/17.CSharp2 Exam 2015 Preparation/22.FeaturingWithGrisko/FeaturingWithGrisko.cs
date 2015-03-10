using System;

class FeaturingWithGrisko
{
    static void Main()
    {
        char[] letters = Console.ReadLine().ToCharArray();
        int count = 0;

        Array.Sort(letters);

        do 
        {
            if (IsMatch(letters)) 
            {
                count++;
            }
        }
        while (NextPermutation(letters));

        Console.WriteLine(count);
    }

    private static bool NextPermutation(char[] array)
    {
        for (int i = array.Length - 2; i >= 0; i--)
        { 
            if (array[i] < array[i + 1])
            {
                int indexToSwap = array.Length - 1;
                while (array[i] >= array[indexToSwap])
                    indexToSwap--;

                char temp = array[i];
                array[i] = array[indexToSwap];
                array[indexToSwap] = temp;

                Array.Reverse(array, i + 1, array.Length - 1 - i);

                return true;
            }
        }

        return false;
    }

    private static bool IsMatch(char[] letters)
    {
        for (int i = 0; i < letters.Length - 1; i++)
        {
            if (letters[i] == letters[i + 1])
                return false;
        }
        return true;
    }
}

