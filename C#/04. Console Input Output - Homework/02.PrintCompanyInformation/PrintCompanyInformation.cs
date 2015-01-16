using System;

class PrintCompanyInformation
{
    static void Main()
    {
        Console.WriteLine("Enter the company's name: ");
        string companyName = Console.ReadLine();
        Console.WriteLine("Enter the company's address: ");
        string address = Console.ReadLine();
        Console.WriteLine("Enter the company's phone number: ");
        string phone = Console.ReadLine();
        Console.WriteLine("Enter the company's fax number: ");
        ulong fax = ulong.Parse(Console.ReadLine());
        Console.WriteLine("Enter the company's website: ");
        string webSite = Console.ReadLine();
        Console.WriteLine("Enter the manager's first name: ");
        string firstName = Console.ReadLine();
        Console.WriteLine("Enter the manager's last name: ");
        string lastName = Console.ReadLine();
        Console.WriteLine("Enter the manager's age: ");
        byte age = byte.Parse(Console.ReadLine());
        Console.WriteLine("Enter the manager's phone number: ");
        string managerPhone = Console.ReadLine();

        Console.WriteLine("{0}", companyName);
        Console.WriteLine("Address: {0}", address);
        Console.WriteLine("Tel: {0}", phone);
        Console.WriteLine("Fax :{0}", fax);
        Console.WriteLine("Web site: {0}", webSite);
        Console.WriteLine("Manager: {0} {1} (Age: {2}, tel. {3})", 
            firstName, lastName, age, managerPhone);
    }
}
