using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusesSchedule
{
    public class TimeInterval : IComparable
    {
        private string inputString;
        private string arrTime;
        private string depTime;

        public TimeInterval(string inputString)
        {
            this.inputString = inputString;

            string arrTime = null;
            string depTime = null;
            ParseTimes(ref arrTime, ref depTime, inputString);

            this.arrTime = arrTime;
            this.depTime = depTime;
        }

        private void ParseTimes(ref string arrTime, 
            ref string depTime, string inputString)
        {
            StringBuilder arrTimeBuild = new StringBuilder();
            StringBuilder depTimeBuild = new StringBuilder();

            bool dividerMet = false;

            for (int i = 1; i < inputString.Length - 1; i++)
            {
                if (inputString[i] == '-')
                {
                    dividerMet = true;
                }
                else
                {
                    if (!dividerMet)
                        arrTimeBuild.Append(inputString[i]);
                    else
                        depTimeBuild.Append(inputString[i]);
                }
            }

            arrTime = arrTimeBuild.ToString().Trim();
            depTime = depTimeBuild.ToString().Trim();
        }

        public string InputString
        {
            get { return this.inputString; }
        }

        public string ArrTime
        {
            get { return this.arrTime; }
        }

        public string DepTime
        {
            get { return this.depTime; }
        }

        public int CompareTo(object otherObj)
        {
            TimeInterval other = (TimeInterval)otherObj;

            return this.inputString.CompareTo(other.InputString);
        }

        public bool Equals(TimeInterval other)
        {
            return this.CompareTo(other) == 0;
        }

        public override string ToString()
        {
            return this.inputString;
        }
    }
}
