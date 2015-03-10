using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Employee
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Position { get; set; }
}

class Employees
{
    static void Main()
    {
        Dictionary<string, int> positions = new Dictionary<string, int>();
        List<Employee> employees = new List<Employee>();

        int countPos = int.Parse(Console.ReadLine());

        for (int i = 0; i < countPos; i++)
        {
            string[] posEnitiies = Console.ReadLine().Split(
                new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

            if (!positions.ContainsKey(posEnitiies[0].Trim()))
                positions.Add(posEnitiies[0].Trim(), int.Parse(posEnitiies[1]));
        }

        int countEmp = int.Parse(Console.ReadLine());
        for (int i = 0; i < countEmp; i++)
        {
            string[] empEnitiies = Console.ReadLine().Split(
               new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

            string[] names = empEnitiies[0].Trim().Split();
            int empRating = positions[empEnitiies[1].Trim()];

            Employee curEmp = new Employee()
            {
                FirstName = names[0].Trim(),
                LastName = names[1].Trim(),
                Position = empRating
            };

            employees.Add(curEmp);
        }


        var sortedEmpl = employees.OrderByDescending(e => e.Position)
            .ThenBy(e => e.LastName).ThenBy(e => e.FirstName);

        foreach (var emp in sortedEmpl)
            Console.WriteLine("{0} {1}", emp.FirstName, emp.LastName);
    }
}
