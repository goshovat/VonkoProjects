namespace VersionAttribute
{
    using System;

    [Version(2.34)]
    class VersionAtributeMain
    {
        static void Main()
        {
            Type type = typeof(VersionAtributeMain);

            object[] attributes = type.GetCustomAttributes(false);

            foreach (VersionAttribute attr in attributes)
            {
                Console.WriteLine(attr.Version);
            }
        }
    }
}
