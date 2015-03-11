namespace GenericList
{
    using System;

    public static class GenericListMain
    {
        static void Main(string[] args)
        {
            GenericList<int> numbers = new GenericList<int>();

            //test Add() and toString()
            numbers.Add(1); 
            numbers.Add(2); 
            numbers.Add(3); 
            numbers.Add(4);
            Console.WriteLine(numbers.IndexOf(4));

            //test Remove() and RemoveAt()
            numbers.Remove(1);
            numbers.RemoveAt(1);

            //test InsertAt()
            numbers.InsertAt(1, 2);
            numbers.InsertAt(2, 3);
            numbers.InsertAt(3, -9);
            numbers.InsertAt(0, 3);
            Console.WriteLine(numbers);

            numbers[1] = 2;

            Console.WriteLine(numbers.Min());
            Console.WriteLine(numbers.Max());

            //test clear
            numbers.Clear();

            try
            {
                numbers.InsertAt(3, 5);
            }
            catch (ArgumentException argExc)
            {
                Console.WriteLine(argExc.Message);
            }

            try 
            { 
                Console.WriteLine(numbers[2]);
            }
            catch (ArgumentException argExc)
            {
                Console.WriteLine(argExc.Message);
            }
        }
    }
}
