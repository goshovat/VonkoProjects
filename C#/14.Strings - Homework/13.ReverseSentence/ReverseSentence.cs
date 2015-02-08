using System;
using System.Text;

class ReverseSentence
{
    static void Main()
    {
        string sentence = "C# is not C++, not PHP, and not Delphi!";
        string[] words = sentence.Split(new char[] { ' ', '!', ',', '.', '?' }, StringSplitOptions.RemoveEmptyEntries);
        string[] symbols = sentence.Split(new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
                                                'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
                                                '+', '#', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k',
                                                'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
                                                'y', 'z', '1', '2', '3', '4', '5', '6', '7', '8', '9', ')', '(',
                                                '*', '/', '=', '~', '`' }, StringSplitOptions.RemoveEmptyEntries);

        //we need to reverse the words but to keep the spaces and signs onn the same positions
        Array.Reverse(words);
        StringBuilder newSentence = new StringBuilder();

        for (int i = 0; i < words.Length; i++)
        {
           newSentence.Append(words[i]);
           newSentence.Append(symbols[i]);
        }

        Console.WriteLine(newSentence.ToString());
    }
}
