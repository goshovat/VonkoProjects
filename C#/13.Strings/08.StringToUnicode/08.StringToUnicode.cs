using System;
using System.Text;

class StringToUnicode
{
    static void Main()
    {
        string originalString = "Вонко";

        try
        {
            string result = TransformString(originalString);
            Console.WriteLine("The transofrmed string is:\n{0}", result);
        }
        catch (NullReferenceException nullRef)
        {
            Console.WriteLine("Error! You have given a null string! Details:\n{0}", nullRef.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error occured during program execution! Details:\n{0}", e.Message);
        }
    }

    static string TransformString(string originalString)
    {
        StringBuilder stringBuild = new StringBuilder();

        for (int i = 0; i < originalString.Length; i++)
        {
            stringBuild.Append(String.Format("\\u{0:x4}", (ushort)originalString[i]));
        }

        return stringBuild.ToString();
    }
}
