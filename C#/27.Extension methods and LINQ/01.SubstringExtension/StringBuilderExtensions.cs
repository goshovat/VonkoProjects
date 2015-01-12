namespace SubstringExtension
{
    using System;
    using System.Text;

    public static class StringBuilderExtensions
    {
        public static StringBuilder Substring(this StringBuilder stringBuild, int index)
        {
            if (index >= stringBuild.Length)
                throw new ArgumentException("The index must be withing the length of the StringBuilder.");

            StringBuilder result = new StringBuilder();

            for (int i = index; i < stringBuild.Length; i++)
                result.Append(stringBuild[i]);

            return result;
        }

        public static StringBuilder Substring(this StringBuilder stringBuild, int index, int length) 
        {
            if (index >= stringBuild.Length)
                throw new ArgumentException("The index must be withing the length of the StringBuilder.");

            if (index + length >= stringBuild.Length)
                throw new ArgumentException("Index and Length must refer to a location within the StringBuilder.");

            StringBuilder result = new StringBuilder();

            for (int i = index; i < index + length; i++)
                result.Append(stringBuild[i]);

            return result;
        }
    }
}
