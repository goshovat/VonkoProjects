namespace GenomeDecoder
{
    using System;
    using System.Text;

    class GenomeDecoder
    {
        static void Main()
        {
            string[] measures = Console.ReadLine().Split(' ');
            string numberLinesString = measures[0];
            //determine padright
            int lettersPerLine = int.Parse(numberLinesString);
            int charsPerSet = int.Parse(measures[1]);

            string encodedGenome = Console.ReadLine();

            StringBuilder decodedGenome = DecodeGenome(encodedGenome);

            //Console.WriteLine(decodedGenome.ToString());

            string FormattedGenome =
                GetFormattedGenome(decodedGenome, lettersPerLine, charsPerSet);

            Console.Write(FormattedGenome);
        }

        private static StringBuilder DecodeGenome(string encodedGenome)
        {
            StringBuilder result = new StringBuilder();
            int currentSymbolCount = 1;
            string currentNumber = "";

            foreach (char symbol in encodedGenome)
            {
                if (symbol == 'A' || symbol == 'G' || symbol == 'C' || symbol == 'T')
                {
                    if (currentNumber != "")
                    {
                        currentSymbolCount = int.Parse(currentNumber);
                    }

                    for (int j = 0; j < currentSymbolCount; j++)
                    {
                        result.Append(symbol);
                    }
                    currentSymbolCount = 1;
                    currentNumber = "";
                }
                else
                {
                    currentNumber += symbol;
                }
            }
            return result;
        }

        private static string GetFormattedGenome(
            StringBuilder decodedGenome, int lettersPerLine, int charsPerSet)
        {
            StringBuilder finalResult = new StringBuilder();
            double numberLinesDouble = (double)decodedGenome.Length / lettersPerLine;
            int numberLines = (int)Math.Ceiling(numberLinesDouble);

            string numberLinesString = numberLines.ToString();
            int padRightCount = numberLinesString.Length;
            int currentSymbolCount = 0;

            for (int row = 1; row <= numberLines; row++)
            {
                finalResult.Append(row.ToString().PadLeft(padRightCount) + " ");

                for (int symbolPerRow = 0; symbolPerRow < lettersPerLine; symbolPerRow++)
                {
                    if (symbolPerRow % charsPerSet == 0 && symbolPerRow != 0)
                        finalResult.Append(' ');

                    if (currentSymbolCount < decodedGenome.Length)
                    {
                        finalResult.Append(decodedGenome[currentSymbolCount]);
                        currentSymbolCount++;
                    }
                    else
                    {
                        break;
                    }
                }
                finalResult.Append('\n');
            }
            return finalResult.ToString();
        }
    }
}
