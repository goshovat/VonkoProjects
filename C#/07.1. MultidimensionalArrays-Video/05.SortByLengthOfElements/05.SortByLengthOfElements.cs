using System;

class SortByLengthOfElements
{
    static void Main()
    {
        string[] testArray = { "gosho", "pp", "ivan", "sameca", "s" };

        Array.Sort(testArray, (a, b) => (a.Length).CompareTo(b.Length));

        Console.WriteLine(string.Join(",", testArray));
    }
}
