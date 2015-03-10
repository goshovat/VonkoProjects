using System;
using System.Collections.Generic;
using System.Text;

class MultiverseCommunication
{
    static void Main()
    {
        int wordsCount = int.Parse(Console.ReadLine());
        List<string> words = new List<string>();
        
        int maxLen = 0;
        for (int i = 0; i < wordsCount; i++)
        {
            string word = Console.ReadLine();
            words.Add(word);

            if (word.Length > maxLen)
                maxLen = word.Length;
        }

        //move the words
        for (int i = 0; i < wordsCount; i++)
        {
            string word = words[i];
            int len = word.Length;
            int newPos = len % (wordsCount + 1);

            words.Insert(newPos, word);

            if (newPos >= i)
                words.RemoveAt(i);
            else
                words.RemoveAt(i + 1);
        }

        StringBuilder result = new StringBuilder();

        for (int index = 0; index < maxLen; index++)
        {
            for (int i = 0; i < wordsCount; i++)
            {
                string word = words[i];
                if (index < word.Length)
                    result.Append(word[index]);
            }
        }

        Console.WriteLine(result.ToString());
    }
}

