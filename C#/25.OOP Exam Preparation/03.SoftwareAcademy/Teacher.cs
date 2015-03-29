using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAcademy
{
    public class Teacher : ITeacher
    {
        private string name;
        private ICollection<ICourse> courses;

        public Teacher(string name)
        {
            this.Name = name;
            this.courses = new List<ICourse>();
        }

        public string Name
        {
            get
            { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("The name of a teacher cannot be set to null.");

                this.name = value;
            }
        }

        public void AddCourse(ICourse course)
        {
            if (course == null)
                throw new ArgumentException("A teacher cannot get null course");

            this.courses.Add(course);

            if (course.Teacher != this)
                course.Teacher = this;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("Teacher: Name={0}", this.Name);

            if (this.courses.Count > 0) 
            {
                var coursesNames = courses.Select(c => c.Name);
               result.AppendFormat("; Courses=[{0}]", string.Join(", ", coursesNames.ToArray()));
            }

            return result.ToString();
        }
    }
}
