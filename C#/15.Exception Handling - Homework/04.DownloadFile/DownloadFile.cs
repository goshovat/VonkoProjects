using System;
using System.Net;

class DownloadFile
{
    static void Main()
    {
        string address = "http://www.devbg.org/img/Logo-BASD.jpg";
        string destinationFileName = "BASD.jpg";

        try
        {
            Console.WriteLine("Download started.");
            DownloadFileFromWeb(address, destinationFileName);
            Console.WriteLine("Download finished");
        }
        catch (ArgumentException argNull)
        {
            Console.WriteLine("ArgNull" + argNull.Message);
        }
        catch (WebException webExcept)
        {
            Console.WriteLine("Problem with internet connection. " + webExcept.Message);
        }
        catch (NotSupportedException notSuppExcept)
        {
            Console.WriteLine("Not support" + notSuppExcept.Message);
        }
    }

    static void DownloadFileFromWeb(string address, string destinatonFileName)
    {
        WebClient client = new WebClient();
        client.DownloadFile(address, destinatonFileName);
    }
}
