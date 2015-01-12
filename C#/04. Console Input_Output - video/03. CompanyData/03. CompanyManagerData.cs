using System;

class CompanyManagerData
{
    static void Main()
    {
        Console.WriteLine("Enter the company's name: ");
        string companyName = "Company name:";
        string inputCompany = Console.ReadLine();
        Console.WriteLine();

        Console.WriteLine("Enter the company's address: ");
        string companyAddress = "Company address:";
        string inputAddress = Console.ReadLine();
        Console.WriteLine();

        Console.WriteLine("Enter the company's phone number: ");
        string companyPhone = "Company phone:";
        string inputPhone = Console.ReadLine();
        ulong phone;
        Console.WriteLine();

        Console.WriteLine("Enter the company's fax number: ");
        string companyFax = "Company fax:";
        string inputFax = Console.ReadLine();
        ulong fax;
        Console.WriteLine();

        Console.WriteLine("Enter the company's website: ");
        string companyWeb = "Company web site:";
        string inputWeb = Console.ReadLine();
        Console.WriteLine();

        Console.WriteLine("Enter the manager's first name: ");
        string managerFirstName = "Manager's first name:";
        string inputFirstName = Console.ReadLine();
        Console.WriteLine();

        Console.WriteLine("Enter the manager's last name: ");
        string managerLastName = "Manager's last name:";
        string inpiutLastName = Console.ReadLine();
        Console.WriteLine();

        Console.WriteLine("Enter the manager's age: ");
        string managerAge = "Manager's age:";
        string inputAge = Console.ReadLine();
        byte age;
        Console.WriteLine();

        Console.WriteLine("Enter the manager's phone number: ");
        string managerPhone = "Manager's phone:";
        string inputManagPhone = Console.ReadLine();
        ulong managerPhoneUlong;
        Console.WriteLine();

        if ((ulong.TryParse(inputPhone, out phone)) && (ulong.TryParse(inputFax, out fax))
            && (byte.TryParse(inputAge, out age)) && (ulong.TryParse(inputManagPhone, out managerPhoneUlong)))
        {
            Console.WriteLine("{0,-25} {1,25}", companyName, inputCompany);
            Console.WriteLine("{0,-25} {1,25}", companyAddress, inputAddress);
            Console.WriteLine("{0,-25} {1,25 :(0###) ### ###}", companyPhone, phone);
            Console.WriteLine("{0,-25} {1,25 :(0###) ### ###}", companyFax, fax);
            Console.WriteLine("{0,-25} {1,25}", companyWeb, inputWeb);
            Console.WriteLine("{0,-25} {1,25}", managerFirstName, inputFirstName);
            Console.WriteLine("{0,-25} {1,25}", managerLastName, inpiutLastName);
            Console.WriteLine("{0,-25} {1,25 :F0}", managerAge, age);
            Console.WriteLine("{0,-25} {1,25 :(0###) ### ###}",managerPhone, managerPhoneUlong);
        }
    }
}

