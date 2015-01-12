using System;

class AgeAfter10Years
{
    static void Main()
    {
        //of course it is much easier without DateTime, just if using int
        Console.WriteLine("Input your age:");
        string currentAgeStr = Console.ReadLine();
        int currentAge = int.Parse(currentAgeStr);
        DateTime ageDateTime = new DateTime(currentAge, 11, 23);
        DateTime ageIn10 = ageDateTime.AddYears(10);
        Console.WriteLine("After 10 years you will be: {0}", 
            ageIn10.Year);
    }
}

