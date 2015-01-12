namespace Employees
{
    using System;
    using System.Collections.Generic;

    class Employees
    {
        static void Main()
        {
            int numberPositions = int.Parse(Console.ReadLine());

            //get the information for the jobs
            for (int i = 0; i < numberPositions; i++)
            {
                string jobInput = Console.ReadLine();
                string[] jobInputEntities = jobInput.Split('-');

                string jobName = jobInputEntities[0].Trim();
                int jobRating = int.Parse(jobInputEntities[1].Trim());

                if (!Employee.jobs.ContainsKey(jobName))
                    Employee.jobs.Add(jobName, jobRating);
            }

            int numberEmployees = int.Parse(Console.ReadLine());
            List<Employee> employees = new List<Employee>();

            //get the info of the employees
            for (int i = 0; i < numberEmployees; i++)
            {
                string employeeInput = Console.ReadLine();
                string[] employeeEntities = employeeInput.Split('-');

                string employeeNames = employeeEntities[0].Trim();
                string[] employeeNamesArr = employeeNames.Split(' ');
                string firstName = employeeNamesArr[0];
                string lastName = employeeNamesArr[1];
                string job = employeeEntities[1].Trim();

                employees.Add(
                    new Employee(firstName, lastName, job));
            }

            employees.Sort();

            //print the employees
            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee);
            }
        }
    }
}
