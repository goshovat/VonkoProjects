namespace SubstringExtension
{
    using System;
    using System.Text;

    class SubstringExtensionMain
    {
        static void Main()
        {
            StringBuilder stringBuild = new StringBuilder("Gosho");
            StringBuilder result1 = stringBuild.Substring(1);
            Console.WriteLine(result1.ToString());

            StringBuilder result2 = stringBuild.Substring(1, 3);
            Console.WriteLine(result2.ToString());
        }
    }
}
