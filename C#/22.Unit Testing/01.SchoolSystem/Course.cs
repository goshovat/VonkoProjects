namespace SchoolSystem
{
    using System;
    using System.Collections.Generic;

    public class Course
    {
        private Dictionary<string, Student> students;

        public Course(string name)
        {
            this.Name = name;
            this.students = new Dictionary<string, Student>();
        }

        public string Name { get; set; }
        public int Count
        {
            get { return students.Count; }
        }

        public void AddStudent(Student student)
        {
            if (this.students.ContainsKey(student.Name))
                throw new ArgumentException(string.Format(
                    "Error! Cannot add student {0} to the course {1}, because he is already inside.",
                    student.Name, this.Name));

            if (students.Count >= 29)
                throw new ApplicationException(string.Format(
                    "Error! Cannot add another student in the course {0}, because the students are already 30.",
                    this.Name));

            this.students.Add(student.Name, student);
        }

        public void RemoveStudent(Student student)
        {
            if (!this.students.ContainsKey(student.Name))
                throw new ApplicationException(string.Format(
                    "Error! Cannot remove student {0} from the course {1}, because he is not enlisted.",
                    student.Name, this.Name));

            this.students.Remove(student.Name);
        }
    }
}
