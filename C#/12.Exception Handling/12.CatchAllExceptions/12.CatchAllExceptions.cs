using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security;

class CatchAllExceptions
{
    static void Main()
    {
        string filePath = @"..\..\win.ini";

        //string filePath = ""; - test ArgumentException
        //string filePath = null; - test ArgumentNullException

        //test path too long exception:
        //string filePath = "oooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo";

        try
        {
            PrintFileContents(filePath);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error occured during program execution! Details:\r\n{0}", e.Message);
        }
    }

    //this method will read the ocntents of the file and print it on the console
    static void PrintFileContents(string filePath)
    {
        try
        {
            string contents = File.ReadAllText(filePath);
            Console.WriteLine(contents);
        }
        //all the exceptions that may arise during using the method File.ReadAllText()
        catch (ArgumentNullException argNullExc)
        {
            Console.WriteLine("Error! There is no given path to the file! Details:\r\n{0}", argNullExc.Message);
        }
        catch (ArgumentException argExc)
        {
            Console.WriteLine("Error! The path to the file is invalid! Details:\r\n{0}", argExc.Message);
        }
        catch (PathTooLongException pathTooLongExc)
        {
            Console.WriteLine("Error! The path to the file exceeds the limit of 248 characters! Details:{0}", pathTooLongExc);
        }
        catch (UnauthorizedAccessException unathExc)
        {
            Console.WriteLine("Error! Unathorized access to the source file. Details:\r\n{0}", unathExc.Message);
        }
        catch (NotSupportedException notSupExc)
        {
            Console.WriteLine("Error! The format of the path to the file is not supported! Details:\r\n{0}", notSupExc.Message);
        }
        catch (SecurityException secExc)
        {
            Console.WriteLine("Error! The current user does not have the permission to access the source file! Details:\r\n{0}", secExc.Message);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Error! The file {0} was not found", filePath);
        }
        catch (DriveNotFoundException)
        {
            Console.WriteLine("Error! The drive of the file {0} cannot be accessed", filePath);
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Error! The directory of the file {0} cannot be accessed", filePath);
        }
    }
}
