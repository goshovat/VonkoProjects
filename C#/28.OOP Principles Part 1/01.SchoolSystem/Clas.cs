namespace SchoolSystem
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Clas
    {
        private Dictionary<int, Student> students;
        private HashSet<Teacher> teachers;

        public Clas(string identifier)
        {
            this.students = new Dictionary<int, Student>();
            this.teachers = new HashSet<Teacher>();
            this.Identifier = identifier;
        }
        public string Identifier { get; private set; }
        public string OptionalComment { get; set; }

        #region Teachers
        public void AddTeacher(Teacher teacher)
        {
            if (this.teachers.Contains(teacher))
                throw new ArgumentException("Cannot add a teacher that is already assigned to a class.");

            this.teachers.Add(teacher);
        }
        public void RemoveTeacher(Teacher teacher)
        {
            if (!this.teachers.Contains(teacher))
                throw new ArgumentException("Cannot remove a teacher that is not assigned to the class.");

            this.teachers.Remove(teacher);
        }
        public string ShowTeachers()
        {
            StringBuilder result = new StringBuilder();
            result.Append(string.Format("Teachers in {0} class: ", this.Identifier));
            foreach (Teacher teacher in this.teachers)
                result.Append(teacher.ToString() + ' ');

            return result.ToString();
        }
        #endregion

        #region 
        public void AddStudent(Student student)
        {
            if (this.students.ContainsKey(student.ClassNumber))
                throw new ArgumentException("Cannot add a student that is already in a class.");

            this.students.Add(student.ClassNumber, student);
        }
        public void ExpellStudent(Student student)
        {
            if (!this.students.ContainsKey(student.ClassNumber))
                throw new ArgumentException("Cannot expell a student that is not in the class.");

            this.students.Remove(student.ClassNumber);
        }
        public string ShowStudents()
        {
            StringBuilder result = new StringBuilder();
            result.Append(string.Format("Students in {0}: ", this.Identifier));
            foreach (int classNumber in this.students.Keys)
                result.Append(this.students[classNumber].ToString() + ' ');

            return result.ToString();
        }
        #endregion

        public override string ToString()
        {
            return string.Format("Class: {0}", this.Identifier);
        }
    }
}
