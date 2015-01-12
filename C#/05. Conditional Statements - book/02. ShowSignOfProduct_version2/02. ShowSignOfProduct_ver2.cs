using System;

class ShowSignOfProduct_ver2
{
    static void Main()
    {
        Console.WriteLine("Enter how many numbers you will check: ");
        string inputHowMany = Console.ReadLine();
        int howMany = int.Parse(inputHowMany);
        int negativeCount = 0;
        bool isProductZero = false;

        int[] arr = new int[howMany];

        for (int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine("Enter a number: ");
            string inputNumber = Console.ReadLine();
            arr[i] = int.Parse(inputNumber);

            if (arr[i] < 0)
            {
                negativeCount++;
            }
            else if (arr[i] == 0)
            {
                isProductZero = true;
            }
        }

        if (isProductZero)
        {
            Console.WriteLine("The product is zero!");
        }
        else if (negativeCount % 2 != 0)
        {
            Console.WriteLine("The product is negative!");
        }
        else
        {
            Console.WriteLine("The product is positive!");
        }
    }
}

