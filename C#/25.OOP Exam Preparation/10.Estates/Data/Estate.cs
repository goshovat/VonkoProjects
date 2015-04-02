using Estates.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Estates.Data
{
    public abstract class Estate : IEstate
    {
        public string Name { get; set; }

        public EstateType Type { get; set; }

        public double Area { get; set; }

        public string Location { get; set; }

        public bool IsFurnished { get; set; }

        public Estate(EstateType type) 
        {
            this.Type = type;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendFormat("{0}: ", this.GetType().Name);
            result.AppendFormat("Name = {0}, ", this.Name);
            result.AppendFormat("Area = {0}, ", this.Area);
            result.AppendFormat("Location = {0}, ", this.Location);
            result.AppendFormat("Furnitured = {0}", this.IsFurnished ? "Yes" : "No");

            return result.ToString();
        }
    }
}
