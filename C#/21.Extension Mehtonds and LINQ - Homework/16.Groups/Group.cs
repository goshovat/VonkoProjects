using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Groups
{
    public class Group
    {
        public byte GroupNumber { get; private set; }
        public string DepartmentName { get; private set; }

        public Group(byte groupNumber, string departmentName)
        {
            this.GroupNumber = groupNumber;
            this.DepartmentName = departmentName;
        }

        public override string ToString()
        {
            return string.Format("Group Number:{0}, Department Name: {1}", 
                this.GroupNumber, this.DepartmentName);
        }
    }
}
