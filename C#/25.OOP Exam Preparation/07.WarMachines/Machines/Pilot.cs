using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public class Pilot : IPilot
    {
        private string name;
        private List<IMachine> machines;

        public string Name
        {
            get { return this.name; }
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The Pilot must have a name.");
                }
                this.name = value;
            }
        }

        public Pilot(string name)
        {
            this.Name = name;
            this.machines = new List<IMachine>();
        }

        public void AddMachine(IMachine machine)
        {
            if (machine == null)
            {
                throw new ArgumentException("Cannot add null machine to pilot.");
            }
            this.machines.Add(machine);
        }

        public string Report()
        {
            StringBuilder report = new StringBuilder();
            report.AppendFormat(" {0} - {1}", 
                this.Name, this.machines.Count == 0 ? "no machines" :
                this.machines.Count == 1  ? "1 machine" : this.machines.Count + " machines");
            report.AppendLine();

            var orderedMachines = this.machines.OrderBy(m => m.HealthPoints)
                .ThenBy(m => m.Name);

            foreach(var machine in orderedMachines) 
            {
                report.AppendLine(machine.ToString());
            }

            return report.ToString().Trim();
        }
    }
}
