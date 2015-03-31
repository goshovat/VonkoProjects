using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public abstract class Machine : IMachine
    {
        private string name;
        private IPilot pilot;
        private double healthPoints;
        private double attackPoints;
        private double defensePoints;
        private List<string> targets;

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("The Machine must have a name.");

                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get { return this.pilot; }
            set { this.pilot = value; }
        }

        public double HealthPoints
        {
            get
            { return this.healthPoints; }
            set
            {
                if (this.healthPoints < 0)
                    throw new ArgumentException("The HealthPoints cannot be negative.");

                this.healthPoints = value;
            }
        }

        public double AttackPoints
        {
            get { return this.attackPoints; }
            protected set
            {
                //if (value < 0)
                //    throw new ArgumentException("The AttackPoints cannot be negative");

                this.attackPoints = value;
            }
        }

        public double DefensePoints
        {
            get { return this.defensePoints; }
            protected set
            {
                //if (value < 0)
                //    throw new ArgumentException("The DefensePoints cannot be negative");

                this.defensePoints = value;
            }
        }

        public IList<string> Targets
        {
            get { return this.targets; }
        }

        public Machine(string name, double healthPoints, double attackPoints, double defensePoints, IPilot pilot)
        {
            this.Name = name;
            this.Pilot = pilot;
            this.HealthPoints = healthPoints;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.targets = new List<string>();
        }

        public void Attack(string target)
        {
            this.targets.Add(target);
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("- {0}", this.Name).AppendLine();
            result.AppendFormat(" *Type: {0}", this.GetType().Name).AppendLine();
            result.AppendFormat(" *Health: {0}", this.HealthPoints).AppendLine();
            result.AppendFormat(" *Attack: {0}", this.AttackPoints).AppendLine();
            result.AppendFormat(" *Defense: {0}", this.DefensePoints).AppendLine();
            result.AppendFormat(" *Targets: {0}",
                this.Targets.Count == 0 ? "None" : string.Join(", ", this.Targets)).AppendLine();

            return result.ToString();
        }
    }
}
