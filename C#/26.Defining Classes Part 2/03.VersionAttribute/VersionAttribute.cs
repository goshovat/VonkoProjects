namespace VersionAttribute
{
    using System;
    using System.Linq;

    [AttributeUsage(AttributeTargets.Struct | 
        AttributeTargets.Class | AttributeTargets.Interface
        | AttributeTargets.Enum | AttributeTargets.Method)]
    public class VersionAttribute : System.Attribute
    {
        private int major;
        private int minor;

        public VersionAttribute(double versionNumber) 
        {
            if (versionNumber < 0)
                throw new ArgumentException("The version number cannot be negative");

            int major = (int)versionNumber;
            int minor = 0;

            string numberString = versionNumber.ToString();
            int pointIndex = numberString.IndexOf('.');

            if (pointIndex != -1)
                minor = int.Parse(numberString.Substring(pointIndex + 1));

            this.major = major;
            this.minor = minor;
        }

        public string Version
        {
            get { return this.major + "." + this.minor; }
        }
    }
}
