using System;

class BooleanVariable
{
    static void Main()
    {
        bool isFemale;
        Console.WriteLine("Write your gender (male/female)");
        string myGender = Console.ReadLine();
        if (myGender == "female")
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
