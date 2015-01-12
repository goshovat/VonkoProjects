namespace MovingLetters
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class MovingLetters
    {
        static void Main()
        {
            string[] words = Console.ReadLine().Split(' ');
         
            int longest = 0;
            for (int i = 0; i < words.Length; i++)
            {
                if (longest < words[i].Length)
                    longest = words[i].Length;
            }

            StringBuilder letters = ExtractLetters(words, longest);
            string movedLetters = MoveLetters(letters);
            Console.WriteLine(movedLetters);
        }

        private static StringBuilder ExtractLetters(string[] words, int longest)
        {
            StringBuilder letters = new StringBuilder();
            for (int index = 0; index < longest; index++)
            {
                for (int j = 0; j < words.Length; j++)
                {
                    string currentWord = words[j];
                    if (currentWord.Length > index)
                    {
                        int currentLetter = currentWord.Length - 1 - index;
                        letters.Append(currentWord[currentLetter]);
                    }              
                }
            }
            return letters;
        }

        private static string MoveLetters(StringBuilder letters)
        {
            for (int i = 0; i < letters.Length; i++)
            {
                char cached = letters[i];
                int code = char.ToUpper(letters[i]) - 'A' + 1;
                int newIndex = (code + i) % letters.Length;
                letters.Remove(i, 1);
                letters.Insert(newIndex, cached);            
            }
            return string.Join("", letters);
        }
    }
}
