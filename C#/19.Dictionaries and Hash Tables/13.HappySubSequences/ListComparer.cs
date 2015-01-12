using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappySubSequences
{
    class ListComparer<T> : IComparer<List<T>>
    {
        public int Compare(List<T> list1, List<T> list2)
        {
            if (list1.Count != list2.Count)
            {
                if (list1.Count < list2.Count)
                    return 1;
                if (list1.Count > list2.Count)
                    return -1;
                else
                    return 0;
            }
            //}
            //if the lists are of equal lengths we will compare them like strings
            else
            {
                return string.Compare(
                    string.Join(",", list1), string.Join(",", list2));
            }
        }
    }
}
