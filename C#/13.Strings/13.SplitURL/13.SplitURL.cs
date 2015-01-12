using System;

class SplitURL
{
    static void Main()
    {
        string url = "http://www.devbg.org/forum/index.php";

        try
        {
            ExtractComponents(url);
        }
        catch (ApplicationException applExc)
        {
            Console.WriteLine("Error! Details:\n{0}", applExc.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error occured during program execution! Details:\n{0}", e.Message);
        }
    }

    static void ExtractComponents(string url)
    {
        if (url == null)
            throw new ApplicationException("The value of the url you have given is null.");

        char[] separators = {'/', ':' };
        string[] components = url.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        if (components.Length == 2)
        {
            Console.WriteLine("[protocol] = {0}", components[0]);
            Console.WriteLine("[resource] = {0}", components[1]);
        }
        else
        {
            Console.WriteLine("[protocol] = {0}", components[0]);
            Console.WriteLine("[server] = {0}", components[1]);

            if (components.Length == 4)
                Console.WriteLine("[resource] = {0}", components[2] + '/' + components[3]);
            else
                Console.WriteLine("[resource] = {0}", components[2]);
        }
    }
}

