using System;

class EncountersOfSubstring
{
    static void Main()
    {
        string text = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in5 days.";
        string wordToCheck = null;
        //string wordToCheck = "in";

        try
        {
            int encounters = CheckEncounters(text, wordToCheck);

            Console.WriteLine("The word is encounterd {0} times", encounters);
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

    static int CheckEncounters(string text, string wordToCheck)
    {
        if (text == null)
            throw new ApplicationException("The text you gave to the method is with null value!");
        if (wordToCheck == null)
            throw new ApplicationException("The word you gave to the method is with null value!");

        int encounters = 0;

        //we want to check he encounters regardless of casing
        text = text.ToLower();
        wordToCheck = wordToCheck.ToLower();

        int index = text.IndexOf(wordToCheck);


        while (index != -1)
        {
            encounters++;
            index = text.IndexOf(wordToCheck, index + 1);
        }

        return encounters;
    }
}