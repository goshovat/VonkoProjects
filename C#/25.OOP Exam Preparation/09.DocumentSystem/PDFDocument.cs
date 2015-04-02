using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentSystem
{
    public class PDFDocument : EncryptableBinaryDocument, IEncryptable
    {
        public int? Pages { get; protected set; }

        public override void LoadProperty(string key, string value)
        {
            if (key == "pages")
            {
                this.Pages = int.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("pages", this.Pages));
        }
    }
}
