using System;

class TheBiggestOfFiveNumbers
{
    static void Main()
    {
        Console.WriteLine("Enter five numbers and check their sum: ");

        string firsNumber = Console.ReadLine();
        double FirstNumberDouble;
        bool parseFirstNumber = double.TryParse(firsNumber, out FirstNumberDouble);
        Console.WriteLine();

        string secondNumber = Console.ReadLine();
        double secondNumberDouble;
        bool parseSecondNumber = double.TryParse(secondNumber, out secondNumberDouble);
        Console.WriteLine();

        string thirdNumber = Console.ReadLine();
        double thirdNumberDouble;
        bool parseThirdNumber = double.TryParse(thirdNumber, out thirdNumberDouble);
        Console.WriteLine();

        string fourthNumber = Console.ReadLine();
        double fourthNumberDouble;
        bool parseFourthNumber = double.TryParse(fourthNumber, out fourthNumberDouble);
        Console.WriteLine();

        string fifthNumber = Console.ReadLine();
        double fifthNumberDouble;
        bool parseFifthNumber = double.TryParse(fifthNumber, out fifthNumberDouble);
        Console.WriteLine();

        if ((parseFirstNumber == true) && (parseSecondNumber == true)
            && (parseThirdNumber == true) && (parseFourthNumber == true) && (parseFifthNumber == true))
        {
            double[] arr = new double[] { FirstNumberDouble, secondNumberDouble, thirdNumberDouble, fourthNumberDouble, fifthNumberDouble};
            
            for (int i = 0; i < 4; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    double temp = arr[i];
                    arr[i] = arr[i+1];
                    arr[i+1] = temp;
                }
            }

            Console.WriteLine("The biggest number is: {0}", arr[4]);
        }
        else
        {
            Console.WriteLine("Please enter proper numbers: ");
            Console.WriteLine();
            Main();
        }
    }
}

