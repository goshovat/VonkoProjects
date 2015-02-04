using System;

class Printing
{
    private const int SHEETS_PER_REALM = 500;

    static void Main()
    {
        int numberStudents = int.Parse(Console.ReadLine());
        int papersPerStudent = int.Parse(Console.ReadLine());
        decimal priceOfRealm = decimal.Parse(Console.ReadLine());

        int totalSheets = numberStudents * papersPerStudent;

        int wholeRealms = totalSheets / SHEETS_PER_REALM;
        decimal moneyWholeRealms = wholeRealms * priceOfRealm;

        int remainderRealms = totalSheets % SHEETS_PER_REALM;
        decimal partRemainder = 0;

        if (remainderRealms > 0)
            partRemainder = ((decimal)remainderRealms) / 500;

        decimal moneyRemainderRealms = partRemainder * priceOfRealm;

        Console.WriteLine("{0:F2}", moneyWholeRealms + moneyRemainderRealms);
    }
}