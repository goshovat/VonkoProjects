using System;

class SumOfDecreasingNumbers
{
    static void Main()
    {
        decimal sum = 1.0m;
        decimal temp = 1.0m; 
        int i = 2;
        int sign = 1;

        for (; 2 > 1; i++)
        {
            temp = sum;
            sum = sum + (1.0m / i)*sign;

            if ((sum - temp) < 0.001m)
            {               
                break;          
            }
            
        }

       
        Console.WriteLine("The sum of the previous addition is: {0:F6}", temp);
        Console.WriteLine("The sum of the last addition is: {0:F6}", sum);

        decimal nextSum = sum + 1.0m /i;

    }
}

