namespace Brackets
{
    using System;
    using System.Text;

    class Brackets
    {
        static void Main()
        {
            int numberLines = int.Parse(Console.ReadLine());
            string tabString = Console.ReadLine();
            StringBuilder result = new StringBuilder();
            int tabCounter = 0;

            for (int row = 0; row < numberLines; row++)
            {
                string lineInput = Console.ReadLine().Trim();
                if (lineInput == "")
                    continue;

                if (lineInput.Length > 0 && lineInput[0] == '}')
                    tabCounter--;

                AppendTabs(result, tabCounter, tabString);
                //start processing the relevant line
                for (int i = 0; i < lineInput.Length; i++)
                {
                    if (lineInput[i] == '{')
                    {
                        if (i != 0)
                        {
                            result.Append('\n');
                            AppendTabs(result, tabCounter, tabString);
                        }
                        result.Append('{');
                        tabCounter++;

                        if (i != lineInput.Length - 1 && 
                            !IsNextCharBracket(lineInput, i + 1))
                        {
                            result.Append('\n');
                            AppendTabs(result, tabCounter, tabString);
                        }
                    }
                    else if (lineInput[i] == '}')
                    {
                        if (i != 0)
                        {
                            tabCounter--;
                            result.Append('\n');
                            AppendTabs(result, tabCounter, tabString);
                        }
                        result.Append('}');
                        if (i != lineInput.Length - 1 && !IsNextCharBracket(lineInput, i + 1))
                        {
                            result.Append('\n');
                            AppendTabs(result, tabCounter, tabString);
                        }
                    }
                    else if (lineInput[i] == ' ')
                    {
                        if (i != 0 && i != lineInput.Length - 1 && lineInput[i - 1] != ' ' &&
                            !IsPreviousCharBracket(lineInput, i -1) && !IsNextCharBracket(lineInput, i + 1))
                            result.Append(' ');
                    }
                    else
                    {
                        result.Append(lineInput[i]);
                    }
                    //Console.WriteLine(result.ToString());
                }
                //finish the line
                if (result[result.Length - 1] == ' ')
                    result.Remove(result.Length - 1, 1);

                result.Append('\n');
            }

            //Console.WriteLine();
            //Console.WriteLine(new string('-', 50));
            string finalResult = result.ToString().Trim();
            Console.WriteLine(finalResult);
        }

        private static bool IsPreviousCharBracket(string lineInput, int index)
        {
            int i = index;
            while (lineInput[i] == ' ')
            {
                i--;
            }
            if (lineInput[i] == '{' || lineInput[i] == '}')
                return true;
            else
                return false;
        }

        private static bool IsNextCharBracket(string lineInput, int index)
        {
            int i = index;
            while (lineInput[i] == ' ')
            {
                i++;
            }
            if (lineInput[i] == '{' || lineInput[i] == '}')
                return true;
            else
                return false;
        }

        private static void AppendTabs(StringBuilder result, int tabCounter, string tabString)
        {
            for (int i = 0; i < tabCounter; i++)
            {
                result.Append(tabString);
            }
        }
    }
}
