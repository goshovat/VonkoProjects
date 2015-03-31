using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public class Fighter : Machine, IFighter
    {
        public bool StealthMode
        {
            get;
            protected set;
        }

        public void ToggleStealthMode()
        {
            if (!this.StealthMode)
            {
                this.StealthMode = true;
            }
            else
            {
                this.StealthMode = false;
            }
        }

        public Fighter(string name, double attackPoints, double defensePoints, bool stealthMode, IPilot pilot = null)
            :base(name, 200, attackPoints, defensePoints, pilot)
        {
            this.StealthMode = stealthMode;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());

            result.AppendFormat(" *Stealth: {0}", this.StealthMode ? "ON" : "OFF").AppendLine();

            return result.ToString().Trim();
        }
    }
}
