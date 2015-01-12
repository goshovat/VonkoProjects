using System;
using System.Collections.Generic;

namespace Humans
{
    abstract class Human:IComparable<Human>
    {
        protected string givenName;
        protected string familyName;

        public string GivenName
        {
            get { return this.givenName; }
        }

        public string FamilyName
        {
            get { return this.familyName; }
        }

        abstract public void PrintPersonInfo();

        abstract public int CompareTo(Human other);
    }
}
