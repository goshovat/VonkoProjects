using System;
using System.Collections.Generic;

class GenericMethod
{
    static void Main()
    {
        Console.WriteLine("Test the method that calculates minimum value: ");
        TestMinimum(0);
        TestMinimum(2.2, 3.1, -9.5, -99.54, -100);

        decimal[] array = { 1.6m, 5.7m, -9.8m, -8m, 99m, 1000m };
        TestMinimum(array);
        Console.WriteLine();

        Console.WriteLine("Test the method that calculates maximum value: ");
        TestMaximum(0);
        TestMaximum(2, 3, -9, -99, -100);
        TestMaximum(array);
        Console.WriteLine();

        Console.WriteLine("Test the method that calculates average value: ");
        TestAverage(0);
        TestAverage(2.1, 3.5, -9.2, -99.6, -100.7);
        TestAverage(array);
        Console.WriteLine();

        Console.WriteLine("Test the method that calculates sum: ");
        TestSum(0);
        TestSum(2, 3, -9, -99, -100);
        TestSum(array);
        Console.WriteLine();

        Console.WriteLine("Test the method that calculates product: ");
        TestProduct(0);
        TestProduct(2, 3, -9, -99, -100);
        TestProduct(array);
    }

    //method that finds the minimum value
    static T CalculateMinimum<T>(params T[] numbers)
    {
        dynamic minimum = int.MaxValue;

        foreach (dynamic number in numbers)
        {
            if (number < minimum)
            {
                minimum = number;
            }
        }

        return minimum;
    }

    //method that finds the maximum value
    static T CalculateMaximum<T>(params T[] numbers)
    {
        dynamic maximum = int.MinValue;

        foreach (dynamic number in numbers)
        {
            if (number > maximum)
            {
                maximum = number;
            }
        }

        return maximum;
    }

    //methods that calculates average
    static T CalculateAverage<T>(params T[] numbers)
    {
        dynamic minimum = CalculateMinimum(numbers);
        dynamic maximum = CalculateMaximum(numbers);

        dynamic average = (minimum + maximum) / 2;

        return average;
    }

    //method that calculates sum
    static T CalculateSum<T>(params T[] numbers)
    {
        dynamic result = 0;

        foreach (dynamic number in numbers)
        {
            result += number;
        }

        return result;
    }

    //method that calculates product
    static T CalculateProduct<T>(params T[] numbers)
    {
        dynamic result = 1;

        foreach (dynamic number in numbers)
        {
            result *= number;
        }

        return result;
    }

    //the test methods
    static void TestMinimum<T>(params T[] numbers)
    {
        dynamic result = CalculateMinimum(numbers);
        Console.WriteLine("The minimum from {0} is: ", string.Join(",", numbers));
        if (result != int.MaxValue)
            Console.WriteLine(result);
        else
            Console.WriteLine(0);
    }

    static void TestMaximum<T>(params T[] numbers)
    {
        dynamic result = CalculateMaximum(numbers);
        Console.WriteLine("The maximum from {0} is: ", string.Join(",", numbers));
        if (result != int.MinValue)
            Console.WriteLine(result);
        else
            Console.WriteLine(0);
    }

    static void TestAverage<T>(params T[] numbers)
    {
        dynamic result = CalculateAverage(numbers);
        Console.WriteLine("The average from {0} is: ", string.Join(",", numbers));
        Console.WriteLine(result);
    }

    static void TestSum<T>(params T[] numbers)
    {
        dynamic result = CalculateSum(numbers);
        Console.WriteLine("The sum from {0} is: ", string.Join(",", numbers));
        Console.WriteLine(result);
    }

    static void TestProduct<T>(params T[] numbers)
    {
        dynamic result = CalculateProduct(numbers);
        Console.WriteLine("The product from {0} is: ", string.Join(",", numbers));
        Console.WriteLine(result);
    }
}

