using System;
using System.Collections.Generic;

namespace Employees
{
    public class Employee : IComparable<Employee>
    {
        public static Dictionary<string, int> jobs = new Dictionary<string, int>();

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Job { get; set; }

        public Employee(string firstName, string lastName, string job)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Job = job;
        }

        public int CompareTo(Employee other)
        {
            if (jobs[this.Job] != jobs[other.Job])
            {
                return -jobs[this.Job].CompareTo(jobs[other.Job]);
            }
            else
            {
                if (this.LastName != other.LastName)
                    return this.LastName.CompareTo(other.LastName);
                else
                    return this.FirstName.CompareTo(other.FirstName);
            }
        }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
}
