namespace SchoolSystem
{
    using System;

    public class Student : Human
    {
        public Student(string name, int classNumber) 
        {
            if (classNumber < 0)
                throw new ArgumentException("The class number of a student must be positive");

            base.Name = name;
            this.ClassNumber = classNumber;
        }

        public int ClassNumber { get; private set; }

        public override string ToString()
        {
            return string.Format("Student: {0}", base.Name);
        }
    }
}
