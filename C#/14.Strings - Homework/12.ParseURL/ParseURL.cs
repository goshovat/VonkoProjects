using System;

class ParseURL
{
    static void Main()
    {
        string url = "http://telerikacademy.com/Courses/Courses/Details/212";
        ExtractComponents(url);
    }

    static void ExtractComponents(string url)
    {
        if (url == null)
            throw new ApplicationException("The value of the url you have given is null.");
        char[] separators = { '/', ':' };
        string[] components = url.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        string resources = components[2];
        for (int i = 3; i < components.Length; i++)
        {
            resources += '/';
            resources += components[i];
        }
        Console.WriteLine("[protocol] = {0}", components[0]);
        Console.WriteLine("[server] = {0}", components[1]);
        Console.WriteLine("[resource] = {0}", resources);
    }
}
