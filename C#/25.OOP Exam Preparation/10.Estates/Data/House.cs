using Estates.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estates.Data
{
    public class House : Estate, IHouse
    {
        public int Floors { get; set; }

        public House()
            : base(EstateType.House)
        {

        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());
            result.AppendFormat(", Floors: {0}", this.Floors);

            return result.ToString();
        }
    }
}
