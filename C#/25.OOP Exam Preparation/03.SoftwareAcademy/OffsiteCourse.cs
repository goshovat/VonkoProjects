using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareAcademy
{
    public class OffsiteCourse : Course, IOffsiteCourse
    {
        private string town;

        public OffsiteCourse(string name, ITeacher teacher, string town)
            : base(name, teacher)
        {
            this.Town = town;
        }

        public string Town
        {
            get { return this.town; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("The lab of a local course cannot be null");

                this.town = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendFormat("OffsiteCourse: Name={0};", this.Name);

            if (this.Teacher != null)
                result.AppendFormat(" Teacher={0};", this.Teacher.Name);

            if (this.topics.Count > 0)
                result.AppendFormat(" Topics=[{0}];", string.Join(", ", this.topics));

            result.AppendFormat(" Town={0}", this.Town);

            return result.ToString();
        }
    }
}
