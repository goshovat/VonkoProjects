using System;
using System.Collections.Generic;

namespace Humans
{
    class Student : Human
    {
        private byte mark;

        public Student()
            : this("Unknown", "Unknown")
        {
        }

        public Student(string givenName, string familyName)
        {
            base.givenName = givenName;
            base.familyName = familyName;
        }

        public byte Mark
        {
            get { return this.mark; }
            set { this.mark = value; }
        }

        public override int CompareTo(Human otherStudent)
        {
            Student student = (Student)otherStudent;

            if (this.mark > student.Mark)
                return 1;
            else if (this.mark < student.Mark)
                return -1;
            else 
                return 0;
        }

        public override void PrintPersonInfo()
        {
            Console.WriteLine("Student: {0} {1}; Mark-> {2}",
                    this.givenName, this.familyName, this.mark);
        }
    }
}
