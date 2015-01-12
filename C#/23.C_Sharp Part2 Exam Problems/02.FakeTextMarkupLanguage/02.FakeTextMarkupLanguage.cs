namespace FakeTextMarkupLanguage
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class FakeTextMarkupLanguage
    {
        static List<string> tags = new List<string>();

        private const string UPPER_OPEN = "<upper>";
        private const string LOWER_OPEN = "<lower>";
        private const string TOGGLE_OPEN = "<toggle>";
        private const string DEL_OPEN = "<del>";
        private const string REV_OPEN = "<rev>";

        private const string UPPER_CLOSE = "</upper>";
        private const string LOWER_CLOSE = "</lower>";
        private const string TOGGLE_CLOSE = "</toggle>";
        private const string DEL_CLOSE = "</del>";
        private const string REV_CLOSE = "</rev>";

        private static int delTagsOpen = 0;
        private static LinkedList<int> revTagsStarts = new LinkedList<int>();

        static StringBuilder result = new StringBuilder();

        static void Main()
        {
            int numberOfLines = int.Parse(Console.ReadLine());


            //the reading, interpreting and writing in a result string
            for (int rows = 0; rows < numberOfLines; rows++)
            {
                string input = Console.ReadLine();
                ProcessLine(input);
                result.Append('\n');
            }

            Console.WriteLine(result.ToString().Trim());
        }

        private static string ProcessLine(string lineInput)
        {
            //the processing of the line
            for (int i = 0; i < lineInput.Length; i++)
            {
                //we are outside any tag
                if (lineInput[i] == '<')
                {
                    //opening tag
                    if (lineInput[i + 1] != '/')
                    {
                        string tag = ExtractTag(lineInput, ref i);

                        if (tag == DEL_OPEN)
                        {
                            delTagsOpen++;
                        }
                        else if (tag == REV_OPEN)
                        {
                            revTagsStarts.AddLast(result.Length);
                        }
                        else
                        {
                            tags.Add(tag);
                        }
                    }
                    //we have just passed closing tag and we need to remove it from the stack
                    else
                    {
                        string tag = ExtractTag(lineInput, ref i);
                        if (tag == DEL_CLOSE)
                        {
                            delTagsOpen--;
                        }
                        else if (tag == REV_CLOSE)
                        {
                            int lastRevStartIndex = revTagsStarts.Last.Value;
                            ReverseSubstring(lastRevStartIndex, result.Length - 1);
                            revTagsStarts.RemoveLast();
                        }
                        else
                        {
                            tags.RemoveAt(tags.Count - 1);
                        }
                    }
                }
                else
                {
                    //process the text between the tags
                    if (delTagsOpen == 0)
                    {
                        char currentChar = ProcessChars(lineInput[i]);
                        result.Append(currentChar);
                    }
                }
            }
            return result.ToString();
        }

        private static string ExtractTag(string lineInput, ref int currentPosition)
        {
            StringBuilder tag = new StringBuilder();
            while (true)
            {
                tag.Append(lineInput[currentPosition]);

                if (lineInput[currentPosition] == '>')
                    break;

                currentPosition++;
            }
            return tag.ToString();
        }

        private static void ReverseSubstring(int startIndex, int endIndex)
        {
            for (int i = startIndex; i < startIndex + (endIndex - startIndex + 1) / 2; i++)
            {
                char temp = result[i];
                result[i] = result[endIndex - i + startIndex];
                result[endIndex - i + startIndex] = temp;
            }
        }

        private static char ProcessChars(char inputChar)
        {
            if (char.IsLetter(inputChar))
            {
                for (int i = tags.Count - 1; i >= 0; i--)
                {
                    string currentTag = tags[i];

                    if (currentTag == UPPER_OPEN)
                    {
                        inputChar = char.ToUpper(inputChar);
                    }
                    else if (currentTag == LOWER_OPEN)
                    {
                        inputChar = char.ToLower(inputChar);
                    }
                    //remains the toggle tag
                    else if (currentTag == TOGGLE_OPEN)
                    {
                        if (char.IsUpper(inputChar))
                            inputChar = char.ToLower(inputChar);
                        else if (char.IsLower(inputChar))
                            inputChar = char.ToUpper(inputChar);
                    }
                }
            }
       
            return inputChar;
        }
    }
}
