namespace InvalidRangeException
{
    using System;

    class nvalidRangeExceptionMain
    {
        static void Main(string[] args)
        {
            try
            {
                TestClass testClass = new TestClass(100, default(DateTime));
            }
            catch (InvalidRangeException<DateTime> indxExc)
            {
                Console.WriteLine(indxExc.Message);
                Console.WriteLine(indxExc.StackTrace);
                Console.WriteLine(indxExc.InnerException.Message);
                Console.WriteLine(indxExc.InnerException.StackTrace);
            }
            catch (InvalidRangeException<int> indxExc)
            {
                Console.WriteLine(indxExc.Message);
                Console.WriteLine(indxExc.StackTrace);
            }
        }
    }
}
