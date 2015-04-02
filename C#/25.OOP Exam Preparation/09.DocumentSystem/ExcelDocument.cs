using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentSystem
{
    public class ExcelDocument : OfficeDocuments
    {
        public int? Rows { get; protected set; }
        public int? Cols { get; protected set; }

        public override void LoadProperty(string key, string value)
        {
            if (key == "rows")
            {
                this.Rows = int.Parse(value);
            }
            else if (key == "cols")
            {
                this.Cols = int.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("rows", this.Rows));
            output.Add(new KeyValuePair<string, object>("cols", this.Cols));
            base.SaveAllProperties(output);
        }
    }
}
