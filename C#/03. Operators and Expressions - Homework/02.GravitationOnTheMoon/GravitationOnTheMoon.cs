using System;

class GravitationOnTheMoon
{
    static void Main()
    {
        Console.WriteLine("Input weight on earth: ");
        double earthWeight = double.Parse(Console.ReadLine());
        double moonWeight = 0.17 * earthWeight;
        Console.WriteLine("The weight on moon is: {0:N3}", moonWeight);
    }
}

