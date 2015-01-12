using System;
using System.Collections.Generic;

namespace TreeMultiSet
{
    class StringComparer : IComparer<string>
    {
        public int Compare(string s1, string s2)
        {
            return string.Compare(s1, s2, true);
        }
    }
}
