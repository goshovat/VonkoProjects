using System;
using System.Linq;

class AcademyTasks
{
    static void Main()
    {
        int[] tasks = Console.ReadLine().Split(
            new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(n => int.Parse(n)).ToArray();

        int variety = int.Parse(Console.ReadLine());
    }
}
