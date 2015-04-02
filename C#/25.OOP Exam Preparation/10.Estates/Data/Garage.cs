using Estates.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estates.Data
{
    public class Garage : Estate, IGarage
    {
        public int Width { get; set; }

        public int Height { get; set; }

         public Garage()
            : base(EstateType.Garage)
        {
        }

         public override string ToString()
         {
             StringBuilder result = new StringBuilder(base.ToString());
             result.AppendFormat(", Width: {0},", this.Width);
             result.AppendFormat(" Height: {0}", this.Height);

             return result.ToString();
         }
    }
}
