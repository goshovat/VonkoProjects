using System;

class IntegerCalculations
{
    static void Main()
    {
        Console.WriteLine("Test the method that calculates minimum value: ");
        TestMinimum();
        TestMinimum(2, 3, -9, -99, -100);

        int[] array = { 1, 5, -9, -8, 99, 1000 };
        TestMinimum(array);
        Console.WriteLine();

        Console.WriteLine("Test the method that calculates maximum value: ");
        TestMaximum();
        TestMaximum(2, 3, -9, -99, -100);
        TestMaximum(array);
        Console.WriteLine();

        Console.WriteLine("Test the method that calculates average value: ");
        TestAverage();
        TestAverage(2, 3, -9, -99, -100);
        TestAverage(array);
        Console.WriteLine();

        Console.WriteLine("Test the method that calculates sum: ");
        TestSum();
        TestSum(2, 3, -9, -99, -100);
        TestSum(array);
        Console.WriteLine();

        Console.WriteLine("Test the method that calculates product: ");
        TestProduct();
        TestProduct(2, 3, -9, -99, -100);
        TestProduct(array);
    }

    //method that finds the minimum value
    static int CalculateMinimum(params int[] numbers)
    {
        int minimum = int.MaxValue;

        foreach (int number in numbers)
        {
            if (number < minimum)
            {
                minimum = number;
            }
        }
        return minimum;
    }

    //method that finds the maximum value
    static int CalculateMaximum(params int[] numbers)
    {
        int maximum = int.MinValue;

        foreach (int number in numbers)
        {
            if (number > maximum)
            {
                maximum = number;
            }
        }
        return maximum;
    }

    //methods that calculates average
    static int CalculateAverage(params int[] numbers)
    {
        int minimum = CalculateMinimum(numbers);
        int maximum = CalculateMaximum(numbers);

        int average = (minimum + maximum) / 2;
        return average;
    }

    //method that calculates sum
    static int CalculateSum(params int[] numbers)
    {
        int result = 0;

        foreach (int number in numbers)
        {
            result += number;
        }
        return result;
    }

    //method that calculates product
    static int CalculateProduct(params int[] numbers)
    {
        int result = 1;

        foreach (int number in numbers)
        {
            result *= number;
        }
        return result;
    }

    //the test methods
    static void TestMinimum(params int[] numbers)
    {
        int result = CalculateMinimum(numbers);
        Console.WriteLine("The minimum from {0} is: ", string.Join(",", numbers));
        if (result != int.MaxValue)
            Console.WriteLine(result);
        else
            Console.WriteLine(0);
    }

    static void TestMaximum(params int[] numbers)
    {
        int result = CalculateMaximum(numbers);
        Console.WriteLine("The maximum from {0} is: ", string.Join(",", numbers));
        if (result != int.MinValue)
            Console.WriteLine(result);
        else
            Console.WriteLine(0);
    }

    static void TestAverage(params int[] numbers)
    {
        int result = CalculateAverage(numbers);
        Console.WriteLine("The average from {0} is: ", string.Join(",", numbers));
        Console.WriteLine(result);
    }

    static void TestSum(params int[] numbers)
    {
        int result = CalculateSum(numbers);
        Console.WriteLine("The sum from {0} is: ", string.Join(",", numbers));
        Console.WriteLine(result);
    }

    static void TestProduct(params int[] numbers)
    {
        int result = CalculateProduct(numbers);
        Console.WriteLine("The product from {0} is: ", string.Join(",", numbers));
        Console.WriteLine(result);
    }
}
