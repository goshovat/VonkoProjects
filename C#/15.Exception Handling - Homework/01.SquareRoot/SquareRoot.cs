using System;

class SquareRoot
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Input a real positive number to see it's square root:");
            double number = double.Parse(Console.ReadLine());
            if (number < 0)
                throw new ArgumentException("We cannot find square-root of a negative number.");

            double result = Math.Sqrt(number);
            Console.WriteLine("Result:{0:F2}", result);
        }
        catch (FormatException formtExc)
        {
            Console.WriteLine("Invalid number");
            Console.WriteLine(formtExc.Message);
        }
        catch (OverflowException overflowExc)
        {
            Console.WriteLine("Invalid number");
            Console.WriteLine(overflowExc.Message);
        }
        catch (ArgumentException argExc)
        {
            Console.WriteLine("Invalid number");
            Console.WriteLine(argExc.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Invalid number");
            Console.WriteLine(e.Message);
        }
        finally
        {
            Console.WriteLine("Good bye");
        }
    }
}
