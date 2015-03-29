using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAcademy
{
    public abstract class Course : ICourse
    {
        private string name;
        private ITeacher teacher;
        protected List<string> topics;

        public Course(string name, ITeacher teacher)
        {
            this.Name = name;
            this.Teacher = teacher;
            this.topics = new List<string>();
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("The course's name cannot be null");

                this.name = value;
            }
        }

        public ITeacher Teacher
        {
            get { return this.teacher; }
            set
            {
                this.teacher = value;
            }
        }

        public void AddTopic(string topic)
        {
            if (string.IsNullOrWhiteSpace(topic))
                throw new ArgumentException("The topic cannot be null");

            this.topics.Add(topic);
        }
    }
}
