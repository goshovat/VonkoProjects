using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentSystem
{
    public abstract class Document : IDocument
    {
        public string Name { get; protected set; }
        public string Content { get; protected set; }

        public virtual void LoadProperty(string key, string value)
        {
            if (key == "name")
            {
                this.Name = value;
            }
            else if (key == "content")
            {
                this.Content = value;
            }
            else
            {
                throw new ArgumentException("Key '" + key + "' not found");
            }
        }

        public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("name", this.Name));
            output.Add(new KeyValuePair<string, object>("content", this.Content));
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("{0}", this.GetType().Name);
            List<KeyValuePair<string, object>> properties =
            new List<KeyValuePair<string, object>>();
            this.SaveAllProperties(properties);

            if (properties.Count > 0)
            {
                result.Append("[");

                var orderedKeys = properties
                                .Where(p => p.Value != null)
                                .OrderBy(p => p.Key).ToArray();

                for (int i = 0; i < orderedKeys.Length; i++)
                {
                    result.AppendFormat("{0}={1}",
                        orderedKeys[i].Key, orderedKeys[i].Value.ToString());

                    if (i != orderedKeys.Length - 1)
                    {
                        result.Append(";");
                    }
                }

               result.Append("]"); 
            }

            return result.ToString();
        }
    }
}
