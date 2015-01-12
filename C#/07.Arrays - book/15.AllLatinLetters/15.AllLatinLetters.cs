using System;

class AllLatinLetters
{
    static void Main()
    {
        char[] alphabetArray = new char[26];

        //fill and print the array of the latin alphabet
        Console.WriteLine("The Latin alphabet: ");
        for (int i = 0; i < 26; i++)
        {
            alphabetArray[i] = Convert.ToChar(i + 65);
            Console.Write(alphabetArray[i] + " ");
        }
        Console.WriteLine();

        //get the input word and print its indexes 
        Console.WriteLine("Write a word: ");
        string inputWord = Console.ReadLine();

        char[] inputWordArr = inputWord.ToCharArray();

        Console.WriteLine("The indexes of your word are: ");

        for (int i = 0; i < inputWordArr.Length; i++)
        {
            char currentSign = Char.ToUpper(inputWordArr[i]);

            int currentIndex = Array.IndexOf(alphabetArray, currentSign);

            Console.Write(currentIndex + " ");
        }

        Console.WriteLine();
    }
}

