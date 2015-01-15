using System;

class BankAccountData
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
        ulong creditCard1 = 6011016011016011;
        ulong creditCard2 = 80110160110986061;
        ulong creditCard3 = 6011000000000004;
        Console.WriteLine("Full Name: {0}\r", fullName);
        Console.WriteLine("Name of the Bank: {0}\r", bankName);
        Console.WriteLine("IBAN: {0}\r", iban);
        Console.WriteLine("BIC: {0}\r", bic);
        Console.WriteLine("Credit Card 1: {0}\r", creditCard1);
        Console.WriteLine("Credit Card 2: {0}\r", creditCard2);
        Console.WriteLine("Credit Card 3: {0}\r", creditCard3);
    }
}


