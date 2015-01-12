namespace FeaturingWithGrishko
{
    using System;

    class FeaturingWithGrishko
    {
        static void Main(string[] args)
        {
            char[] letters = Console.ReadLine().ToCharArray();
            int count = 0;
            Array.Sort(letters);

            do
            {
                if (!HasSameLetters(letters))
                {
                    count++;
                }
            }
            while (NextPermutation(letters));

            Console.WriteLine(count);
        }

        /// <summary>
        /// Transform array of chars to next permutation.
        /// Rearranges the elements into the next lexicographically greater permutation.
        /// </summary>
        /// <param name="array">The array of elements to be sorted</param>
        /// <returns>
        /// true if the function could rearrange the object as a lexicographically greater permutation.
        /// Otherwise, the function returns false to indicate that the arrangement is not greater than the previous, but the lowest possible (sorted in ascending order).
        /// </returns>
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

        private static void Swap(char[] word, int index1, int index2)
        {
            char temp = word[index1];
            word[index1] = word[index2];
            word[index2] = temp;
        }

        private static bool HasSameLetters(char[] word)
        {
            for (int i = 0; i < word.Length - 1; i++)
            {
                if (word[i] == word[i + 1])
                    return true;
            }
            return false;
        }
    }
}
