using System;

class BankAccount
{
    static void Main()
    {
        string firstName = "Ivan";
        string middleName = "Hristov";
        string lastName = "Mihov";
        string fullName = firstName + " " + middleName + " " + lastName;
        string bankName = "First Investment Bank";
        string bic = "FINVBGSF";
        string iban = "BG06 RZBB 9155 1060 2664 18";
        long creditCard1 = 6011016011016011;
        long creditCard2 = 80110160110986061;
        long creditCard3 = 6011000000000004;
        Console.WriteLine("Full Name: {0}", fullName);
        Console.WriteLine();
        Console.WriteLine("Name of the Bank: {0}", bankName);
        Console.WriteLine();
        Console.WriteLine("IBAN: {0}",iban);
        Console.WriteLine();
        Console.WriteLine("BIC: {0}", bic);
        Console.WriteLine();
        Console.WriteLine("Credit Card 1: {0}", creditCard1);
        Console.WriteLine();
        Console.WriteLine("Credit Card 2: {0}", creditCard2);
        Console.WriteLine();
        Console.WriteLine("Credit Card 3: {0}", creditCard3);
    }
}

