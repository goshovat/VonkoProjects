using System;

class ReadArrangeWords
{
    static void Main(string[] args)
    {
        string input = "vonko, gosho, stamat,pesho,airis,ani,kurvata";

        try
        {
            string[] arrangedWords = ArrangeWords(input);

            Console.WriteLine("Two words in lexicographical order:");
            foreach (string word in arrangedWords)
            {
                Console.WriteLine(word);
            }
            Console.WriteLine();
        }
        catch (ApplicationException applExc)
        {
            Console.WriteLine("Error! Details:\n{0}", applExc.StackTrace);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error occured during program execution! Details:\n{0}", e.StackTrace);
        }
    }

    static string[] ArrangeWords(string input)
    {
        if (input == null)
            throw new ApplicationException("You have given input with null value.");

        char[] separators = { ',', ' ' };

        string[] words = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        bool hasSwapped = true;

        //we will arrange the words using bubble sort algorithm
        while (hasSwapped)
        {
            hasSwapped = false;

            for (int i = 0; i < words.Length - 1; i++)
            {
                if (words[i].CompareTo(words[i + 1]) > 0)
                {
                    string temp = words[i];
                    words[i] = words[i + 1];
                    words[i + 1] = temp;

                    hasSwapped = true;
                }
            }
        }

        return words;
    }
}

