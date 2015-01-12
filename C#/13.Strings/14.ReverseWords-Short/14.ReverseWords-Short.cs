using System;
using System.Text;

class ReverseWords_Short
{
    static void Main(string[] args)
    {
        try
        {
            string sentence = "C# is not C++, not PHP, and not Delphi!";
            string[] words = sentence.Split(new char[] { ' ', '!', ',', '.', '?' }, StringSplitOptions.RemoveEmptyEntries);
            string[] symbols = sentence.Split(new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
                                                'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
                                                '+', '#', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k',
                                                'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
                                                'y', 'z', '1', '2', '3', '4', '5', '6', '7', '8', '9', ')', '(',
                                                '*', '/', '=', '~', '`' }, StringSplitOptions.RemoveEmptyEntries);

            Array.Reverse(words);
            StringBuilder newSentence = new StringBuilder();

            for (int i = 0; i < words.Length; i++)
            {
                newSentence.Append(words[i]);
                newSentence.Append(symbols[i]);
            }

            Console.WriteLine(newSentence.ToString());
        }
        catch (NullReferenceException nulLRefExc)
        {
            Console.WriteLine("Error! You have given a string with null value. Details:\n{0}", nulLRefExc.StackTrace);
        }
        catch (IndexOutOfRangeException indexOutExc)
        {
            Console.WriteLine("Error! Index you tried to access was outside the array. Details:\n{0}", indexOutExc.StackTrace);
        }
        catch (Exception e)
        {
            Console.WriteLine("Something fucked up happened! Details:\n{0}", e.StackTrace);
        }
    }
}
