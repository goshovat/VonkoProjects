using System;

class IndexOfLetters
{
    static void Main()
    {
        char[] allLetters = new char[26];

        for (int i = 0; i < 26; i++)
        {
            allLetters[i] = Convert.ToChar(i + 65);
        }

        //get the input word
        string word = Console.ReadLine();

        char[] wordArray = word.ToCharArray();

        for (int i = 0; i < wordArray.Length; i++)
        {
            char currentLetter = Char.ToUpper(wordArray[i]);
            int currentIndex = Array.IndexOf(allLetters, currentLetter);
            Console.Write(currentIndex + " ");
        }

        Console.WriteLine();
    }
}
