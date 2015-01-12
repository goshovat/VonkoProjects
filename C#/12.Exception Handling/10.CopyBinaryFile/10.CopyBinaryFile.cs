using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

class CopyBinaryFile
{
    static void Main()
    {
        string pathToOriginalFile = @"..\..\Photoes2008.rar";
        string pathToNewCopy = @"..\..\NewPhotoes.rar";

        try
        {
            byte[] bytes = ReadBinaryFile(pathToOriginalFile);
            WriteBytesIntoNewFile(pathToNewCopy, bytes);
        }
        //the exceptions from the rading method will be captured here, because the method needs to return array initialized after the stream is created
        catch (FileNotFoundException fnfe)
        {
            Console.WriteLine("The source file is missing. Details:\r\n{0}", fnfe.Message);
        }
        catch (DirectoryNotFoundException dirnfe)
        {
            Console.WriteLine("The directory of the source file cannot be accessed. Details:\r\n", dirnfe.Message);
        }
        catch (DriveNotFoundException dnfe)
        {
            Console.WriteLine("The drive of the source file cannot be accessed. Details:\r\n", dnfe.Message);
        }
        catch (IOException ioExc)
        {
            Console.WriteLine("There is error while reading bytes from the source file. Details:\r\n", ioExc.Message);
        }
        //capturing all other kinds of exceptions that are not realted to the streams
        catch (Exception e)
        {
            Console.WriteLine("Error occured during program execution! Details:\r\n{0}", e.StackTrace);
        }  
    }

    ////this method will read the original binary file and store its bytes in an array
    static byte[] ReadBinaryFile(string pathToOriginalFile)
    {
        List<byte> bytesList = new List<byte>();

        FileStream reader = new FileStream(pathToOriginalFile, FileMode.Open, FileAccess.Read);
        int len = (int)reader.Length;
        byte[] buffer = new byte[len];

        using (reader)
        {
            Console.WriteLine("Start reading old file");
            reader.Read(buffer, 0, len);
            Console.WriteLine("End reading of old file");
        }

        return buffer;
    }

    static void WriteBytesIntoNewFile(string pathToNewCopy, byte[] bytes)
    {
        try
        {
            FileStream writer = new FileStream(pathToNewCopy, FileMode.Create, FileAccess.Write);
            Console.WriteLine(bytes.Length);

            using (writer)
            {
                Console.WriteLine("Start copying the file. Please wait few minutes...");

                writer.Write(bytes, 0, bytes.Length);

                Console.WriteLine("File copied.");
            }
        }
        catch (DirectoryNotFoundException dirnfe)
        {
            Console.WriteLine("The directory of the new file cannot be accessed. Details:\r\n", dirnfe.Message);
        }
        catch (DriveNotFoundException dnfe)
        {
            Console.WriteLine("The drive of the new file cannot be accessed. Details:\r\n", dnfe.Message);
        }
        catch (IOException ioExc)
        {
            Console.WriteLine("There is error while copying bytes into the destination file. Details:\r\n", ioExc.Message);
        }
    }
}