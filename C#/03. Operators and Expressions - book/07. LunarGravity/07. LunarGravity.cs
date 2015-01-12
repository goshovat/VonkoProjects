using System;

class LunarGravity
{
    static void Main()
    {
        Console.WriteLine("Write you weight on Earth in kg: ");
        string inputWeight = Console.ReadLine();
        double earthWeight = Convert.ToDouble(inputWeight);
        double moonWeight = 17.0 / 100 * earthWeight;
        Console.WriteLine("Your weight on the Moon will be: " + moonWeight+"kg");
    }
}
