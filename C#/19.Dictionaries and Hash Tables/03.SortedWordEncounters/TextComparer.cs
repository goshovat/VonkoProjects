using System;
using System.Collections.Generic;

namespace SortedWordEncounters
{
    class TextComparer: IEqualityComparer<string>
    {
        public bool Equals(string str1, string str2)
        {
            return string.Compare(str1, str2, true) == 0;
        }

        public int GetHashCode(string str)
        {
            return str.ToLower().GetHashCode();
        }
    }
}
