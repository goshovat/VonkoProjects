namespace Humans
{
    using System;

    public class Student : Human
    {
        public int Grade { get; private set; }

        public Student(string firstName, string lastName, int grade)
            :base(firstName, lastName)
        {
            if (grade < 2 || grade > 6)
                throw new ArgumentException("Inappropriate value for grade.");

            this.Grade = grade;
        }

        public override string ToString()
        {
            return string.Format("Student: {0} {1} grade: {2}", 
                base.FirstName, base.LastName, this.Grade);
        }
    }
}
