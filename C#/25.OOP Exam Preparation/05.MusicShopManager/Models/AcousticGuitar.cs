using MusicShopManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShopManager.Models
{
    internal class AcousticGuitar : Guitar, IAcousticGuitar
    {
        private bool caseIncluded;
        private StringMaterial stringMaterial;

        public bool CaseIncluded
        {
            get { return this.caseIncluded; }
            protected set
            {
                this.caseIncluded = value;
            }
        }

        public StringMaterial StringMaterial
        {
            get { return this.stringMaterial; }
            protected set
            {
                this.stringMaterial = value;
            }
        }

        internal AcousticGuitar(string make, string model, decimal price, string color,
            string body, string fingerboard, bool caseIncluded, StringMaterial strings)
            : base(make, model, price, color, false, body, fingerboard, 6)
        {
            this.CaseIncluded = caseIncluded;
            this.StringMaterial = strings;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());

            result.AppendLine(string.Format("Case included: {0}", this.CaseIncluded ? "yes" : "no"));
            result.AppendLine(string.Format("String material: {0}", this.StringMaterial));

            return result.ToString();
        }
    }
}
