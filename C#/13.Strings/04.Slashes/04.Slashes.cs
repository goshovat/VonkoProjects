using System;

class Slashes
{
    static void Main()
    {
        string originalText = "Ariana\\ Zagorka\\ Heineken\\ Staropramen\\ Radler";

        char[] splitSymbols = {'\\', ' '};

        try
        {
            if (originalText == null)
                throw new ApplicationException("The text you gave is with null value!");
            if (splitSymbols == null)
                throw new ApplicationException("The split symbols you gave are null!");

            string[] arrayText = originalText.Split(splitSymbols, StringSplitOptions.RemoveEmptyEntries);

            foreach (string beer in arrayText)
            {
                Console.WriteLine(beer);
            }
        }
        catch (ApplicationException appExc)
        {
            Console.WriteLine("Error! Details:\n{0}", appExc.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error occured during program execution. Details:\n{0}", e.Message);
        }
    }
}
