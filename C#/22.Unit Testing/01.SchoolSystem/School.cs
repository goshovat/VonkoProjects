namespace SchoolSystem
{
    using System;
    using System.Collections.Generic;

    public class School
    {
        private Dictionary<int, Student> students;

        public School(string name)
        {
            this.Name = name;
            this.students = new Dictionary<int, Student>();
        }

        public string Name { get; set; }

        public bool ContainsNumber(int number)
        {
            return this.students.ContainsKey(number);
        }

        public void AddStudent(Student student)
        {
            if (students.ContainsKey(student.Number))
                throw new ApplicationException(string.Format(
                    "Error! Cannot add student {0}  with number {1} to the school {2}, because he is already inside.",
                    student.Name, student.Number, this.Name));

            students.Add(student.Number, student);

            int number = int.Parse("15");
        }
    }
}
