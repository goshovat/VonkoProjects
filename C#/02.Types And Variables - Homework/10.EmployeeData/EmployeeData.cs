using System;

class EmployeeData
{
    static void Main()
    {
        string firstName = "Ivan";
        string lastName = "Mihov";
        byte age = 25;
        char gender = 'm';
        int id = 27560007;
        int employeeNumber = 27560001;
        Console.WriteLine(
            "First name: {0}, Last Name: {1}, Age: {2}", firstName, lastName, age);
        Console.WriteLine("Gender: {0}, Personal ID: {1}, Employee Number: {2}",
            gender == 'm' ? "Male" : "Female", id, employeeNumber);
    }
}
