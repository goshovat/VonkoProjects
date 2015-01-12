namespace ConsoleJustification
{
    using System;
    using System.Text;

    class ConsoleJustification
    {
        static int firstWordIndex = 0;

        static void Main()
        {
            int initialLines = int.Parse(Console.ReadLine());
            int symbolsPerLine = int.Parse(Console.ReadLine());
            StringBuilder initialText = new StringBuilder();

            //get the input text
            for (int row = 0; row < initialLines; row++)
            {
                initialText.Append(Console.ReadLine() + " ");
            }
            string[] allWords = initialText.ToString().Split(
                new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            StringBuilder result = JustifyText(allWords, symbolsPerLine);

            Console.WriteLine(result.ToString().Trim());
        }

        private static StringBuilder JustifyText(string[] allWords, int symbolsPerLine)
        {
            StringBuilder result = new StringBuilder();
            int symbolsCurrentLine = 0;

            for (int i = 0; i < allWords.Length; i++)
            {
                //check if we have space for one more word on this line
                if (symbolsCurrentLine + allWords[i].Length <= symbolsPerLine)
                {
                    result.Append(allWords[i]);
                    symbolsCurrentLine += allWords[i].Length;

                    /*if we are not exactly on the end of the line, add one space
                    so to try adding another word*/
                    if (symbolsCurrentLine < symbolsPerLine)
                    {
                        result.Append(' ');
                        symbolsCurrentLine++;
                    }
                }
                //no more place on this row
                else
                {
                    //the last symbol on the row is whitespace, remove it
                    if (result[result.Length - 1] == ' ')
                        result.Remove(result.Length - 1, 1);

                    JustifyLine(result, symbolsPerLine);

                    result.Append('\n');
                    symbolsCurrentLine = 0;
                    firstWordIndex = result.Length;
                    i--;
                }
            }
            if (result[result.Length - 1] == '\n' || result[result.Length - 1] == ' ')
                result.Remove(result.Length - 1, 1);

            JustifyLine(result, symbolsPerLine);

            return result;
        }

        private static void JustifyLine(StringBuilder result, int symbolsPerLine)
        {
            //find where the last line begins
            int index = firstWordIndex;

            int symbolsCurrentLine = result.Length - index;
            bool whiteSpaceFound = true;

            while (whiteSpaceFound)
            {
                whiteSpaceFound = false;
                for (int i = index; i < result.Length; i++)
                {
                    if (result[i] == ' ')
                    {
                        result.Insert(i, ' ');
                        symbolsCurrentLine++;
                        i++;
                        whiteSpaceFound = true;

                        //go to place where there is no inerval
                        while (result[i] == ' ') 
                        {
                            i++;
                        }               
                        i--;
                    }

                    if (symbolsPerLine == symbolsCurrentLine)
                        return;
                }
            }
        }
    }
}
