using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGroups
{
    public class Student
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public ulong FN { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        private List<byte> marks;
        public List<byte> Marks
        {
            get { return new List<byte>(marks); }
            private set { this.marks = value; }
        }

        public byte GroupNumber { get; set; }

        public Student(string firstName, string lastName, ulong fn,
            string tel, string email, byte groupNumber)
        {
            this.FirstName = firstName.Trim();
            this.LastName = lastName.Trim();
            this.FN = fn;
            this.Tel = tel.Trim();
            this.Email = email.Trim();
            this.Marks = new List<byte>();
            this.GroupNumber = groupNumber;
        }

        public void AddMark(byte mark)
        {
            this.marks.Add(mark);
        }

        public override string ToString()
        {
            return string.Format("Student: {0} {1}, FN: {2} Phone: {3}, Email: {4}, Marks: {5}",
                this.FirstName, this.LastName, this.FN, this.Tel, this.Email, string.Join(", ", this.marks));
        }
    }
}
