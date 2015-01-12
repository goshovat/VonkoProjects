namespace PHPVariables
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class PHPVariables
    {
        const char ESCAPING_SYMBOL = '\\';

        static void Main()
        {
            SortedSet<string> variables = new SortedSet<string>();

            string currentLine = Console.ReadLine().Trim();
            bool isInComment = false;
            while (currentLine != "?>")
            {
                currentLine = Console.ReadLine();
                if (currentLine == "")
                    continue;

                ProcessPHPLine(currentLine, variables, ref isInComment);
            }

            Console.WriteLine(variables.Count);
            PrintVariablesSorted(variables);
        }

        private static void ProcessPHPLine
            (string currentLine, SortedSet<string> variables, ref bool isInComment)
        {
            bool isInString = false;
            char stringQuote = default(char);
            bool inVariable = false;
            StringBuilder currentVariable = new StringBuilder();

            for (int symbol = 0; symbol < currentLine.Length; symbol++)
            {
                if (inVariable)
                {
                    if (char.IsLetter(currentLine[symbol]) || char.IsDigit(currentLine[symbol])
                          || currentLine[symbol] == '_')
                    {
                        currentVariable.Append(currentLine[symbol]);
                    }
                    else
                    {
                        inVariable = false;

                        if (currentVariable.ToString() != "")
                            variables.Add(currentVariable.ToString());

                        currentVariable.Clear();
                    }
                }
                //check if we go in a variable
                if (!isInComment && currentLine[symbol] == '$')
                {
                    inVariable = true;
                    continue;
                }
                //we go in string
                else if (currentLine[symbol] == '\'' || currentLine[symbol] == '"')
                {
                    if (isInString && currentLine[symbol] == stringQuote)
                    {
                        stringQuote = default(char);
                        isInString = false;
                        continue;
                    }

                    if (!isInString && currentLine[symbol] == '\'')
                        stringQuote = '\'';
                    else if (!isInString && currentLine[symbol] == '"')
                        stringQuote = '"';

                    isInString = true;
                }
                //handle escaping
                if (isInString && currentLine[symbol] == '\\')
                {
                    symbol++;
                    continue;
                }
                //single-line comments
                else if (!isInString && currentLine[symbol] == '#')
                {
                    break;
                }
                else if (!isInString && currentLine[symbol] == '/' && 
                    symbol < currentLine.Length - 1 && currentLine[symbol + 1] == '/')
                {
                    break;
                }
                //openning of multi-line comments
                else if (!isInString && currentLine[symbol] == '/' && 
                    symbol < currentLine.Length - 1 && currentLine[symbol + 1] == '*')
                {
                    isInComment = true;
                    symbol++;
                }
                //closing multi-line comments
                else if (isInComment && currentLine[symbol] == '*' && 
                    symbol < currentLine.Length - 1 && currentLine[symbol + 1] == '/')
                {
                    isInComment = false;
                    symbol++; //we have checked the next symbol and we don't need it
                }
            }
        }

        private static void PrintVariablesSorted(SortedSet<string> variables)
        {
            foreach (string variable in variables)
            {
                Console.WriteLine(variable);
            }
        }
    }
}
