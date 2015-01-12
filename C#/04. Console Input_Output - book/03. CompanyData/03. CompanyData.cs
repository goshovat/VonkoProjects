using System;

class CompanyData
{
    static void Main()
    {
        Console.WindowWidth = 100;

        //Here we create the input for the company data:
        Console.WriteLine("Please enter the name of the company: ");
        string companyName = Console.ReadLine();
        Console.WriteLine();

        Console.WriteLine("Please enter the company's address: ");
        string companyAddress = Console.ReadLine();
        Console.WriteLine();

        Console.WriteLine("Please enter the phone number of the company(write only numbers, no spaces in between): ");
        string companyPhone = Console.ReadLine();
        ulong companyPhoneUlong;
        bool parseCompanyPhone = ulong.TryParse(companyPhone, out companyPhoneUlong);
        Console.WriteLine();

        Console.WriteLine("Please enter the fax number of the company: ");
        string companyFax = Console.ReadLine();
        ulong companyFaxUlong;
        bool parseCompanyFax = ulong.TryParse(companyFax, out companyFaxUlong);
        Console.WriteLine();

        Console.WriteLine("Please enter the web site of the company: ");
        string companyWeb = Console.ReadLine();
        Console.WriteLine();

        //Here we create the input for the company manager:
        Console.WriteLine("Enter the company manager's first name: ");
        string managerFirstName = Console.ReadLine();
        Console.WriteLine();

        Console.WriteLine("Enter the manager's last name: ");
        string managerLastName = Console.ReadLine();
        Console.WriteLine();

        Console.WriteLine("Enter the manager's phone number: ");
        string managerPhone = Console.ReadLine();
        ulong managerPhoneUlong;
        bool parseManagerPhone = ulong.TryParse(managerPhone, out managerPhoneUlong);
        Console.WriteLine();

        if ((parseCompanyFax == true) && (parseCompanyPhone == true) && (parseManagerPhone == true))
        {
            Console.WriteLine("The details of the company:");
            Console.WriteLine("Name: {0,-10:G}", companyName);
            Console.WriteLine();
            Console.WriteLine("Address: {0,-10:G}", companyAddress);
            Console.WriteLine();
            Console.WriteLine("Phone number: {0,-10:(0###) ### ###}", companyPhoneUlong);
            Console.WriteLine();
            Console.WriteLine("Fax number: {0,-10:(0###) ### ###}", companyFaxUlong);
            Console.WriteLine();
            Console.WriteLine("Details of the company's manager:");
            Console.WriteLine();
            Console.WriteLine("First Name: {0,-10:G}", managerFirstName);
            Console.WriteLine();
            Console.WriteLine("Last Name: {0,-10:G}", managerLastName);
            Console.WriteLine();
            Console.WriteLine("Phone number: {0,-10:(0###) ### ###}", managerPhoneUlong);
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Please, enter valid numbers");
        }
    }
}

