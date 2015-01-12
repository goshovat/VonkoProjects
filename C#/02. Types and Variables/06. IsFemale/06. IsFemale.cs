using System;

class IsFemale
{
    static void Main()
    {
        bool isFemale;
        Console.WriteLine("Write your gender (male/female)");
        string vonkoGender = Console.ReadLine();
        if (vonkoGender == "female")
        {
            isFemale = true;
        }
        else
        {
            isFemale = false;
        }
        Console.WriteLine(isFemale);
    }
}

