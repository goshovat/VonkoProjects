using System;

class GetLargestNumber
{
    static void Main()
    {
        Console.WriteLine("Enter three integers to see the biggest one of them: ");
        Console.WriteLine("The first number is: ");
        int firstNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("The second number is: ");
        int secondNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("The third number is: ");
        int thirdNumber = int.Parse(Console.ReadLine());

        int maxNumber = GetMax(GetMax(firstNumber, secondNumber), thirdNumber);
        Console.WriteLine("The max number is: {0}", maxNumber);
    }

    static int GetMax(int firstNumber, int secondNumber)
    {
        int maxNumber = firstNumber;
        if (secondNumber > firstNumber)
        {
            maxNumber = secondNumber;
        }

        return maxNumber;
    }
}
