﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentSystem
{
    public class WordDocument : OfficeDocuments, IEditable
    {
        public int? Chars { get; protected set; }

        public void ChangeContent(string newContent)
        {
            base.Content = newContent;
        }

        public override void LoadProperty(string key, string value)
        {
            if (key == "chars")
            {
                this.Chars = int.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("chars", this.Chars));
        }
    }
}
