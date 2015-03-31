using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public class Tank : Machine, ITank
    {
        public bool DefenseMode
        {
            get; protected set;
        }

        public void ToggleDefenseMode()
        {
            if (!this.DefenseMode)
            {
                base.DefensePoints += 30;
                base.AttackPoints -= 40;
                this.DefenseMode = true;
            }
            else
            {
                base.DefensePoints -= 30;
                base.AttackPoints += 40;
                this.DefenseMode = false;
            }
        }

        public Tank(string name, double attackPoints, double defensePoints, IPilot pilot = null)
            :base(name, 100, attackPoints, defensePoints, pilot)
        {
            this.ToggleDefenseMode();
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());

            result.AppendFormat(" *Defense: {0}", this.DefenseMode ? "ON" : "OFF");

            return result.ToString().Trim();
        }
    }
}
