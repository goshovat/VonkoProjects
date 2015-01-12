using System;
using System.Collections.Generic;

namespace SchoolModel
{
    public class Klass
    {
        private string id;
        private List<Student> students = new List<Student>();

        public Klass()
            : this("Unnamed")
        {

        }

        public Klass(string id)
        {
            this.id = id;
        }

        //properties of the Klass
        public string ID
        {
            get { return this.id; }
        }

        //methods of the class
        public void AddNewStudent(Student student)
        {
            if (this.students.Contains(student))
                throw new ApplicationException(string.Format("Error! The student {0} is already in class {1}",
                    student.Name, this.ID));

            this.students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            if (!this.students.Contains(student))
                throw new ApplicationException(string.Format("Error! The student {0} is not in class {1}",
                    student.Name, this.ID));

            this.students.Remove(student);
        }

        public void ShowStudents()
        {
            Console.WriteLine("The students in the class {0} are:", this.id);
            foreach (Student student in this.students)
            {
                Console.WriteLine(student.Name);
            }
            Console.WriteLine(new string('-', 50));
            Console.WriteLine();
        }
    }
}
