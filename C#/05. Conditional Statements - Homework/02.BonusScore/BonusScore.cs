using System;

class BonusScore
{
    static void Main()
    {
        //little bit different solution than the standart one
        Console.WriteLine("Enter scores between 1 and 9 to calculate the bonus:");
        int input = int.Parse(Console.ReadLine());

        switch (input)
        {
            case 1:
            case 2:
            case 3:
                Console.WriteLine("The scores with the bonus are: {0}", input * 10);
                break;
            case 4:
            case 5:
            case 6:
                Console.WriteLine("The scores with the bonus are: {0}", input * 100);
                break;
            case 7:
            case 8:
            case 9:
                Console.WriteLine("The scores with the bonus are: {0}", input * 1000);
                break;
            default:
                Console.WriteLine("Invalid score");
                break;
        }
    }
}
