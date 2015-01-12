//write a program that removes from a text file all words listed in given another text file. 
//handle all possible exceptions in your methods.
using System;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;
using System.Security;

namespace Ex12RemoveWordList
{
    class Remove
    {
        static void Main()
        {
            try
            {
                StreamReader reader = new StreamReader(@"..\..\fileToEdit.txt");
                string pattern = @"\b(" + String.Join("|", File.ReadAllLines(@"..\..\wordList.txt")) + @"\b)";
                using (reader)
                {
                    StreamWriter writer = new StreamWriter(@"..\..\finalFile.txt");
                    using (writer)
                    {
                        string line = reader.ReadLine();
                        while (line != null)
                        {
                            writer.WriteLine(Regex.Replace(line, pattern, ""));
                            line = reader.ReadLine();
                        }
                    }
                }
            }
            catch (ArgumentNullException argNull)
            {
                Console.WriteLine(argNull.Message);
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);
            }
            catch (PathTooLongException tooLong)
            {
                Console.WriteLine(tooLong.Message);
            }
            catch (DirectoryNotFoundException notFoundDir)
            {
                Console.WriteLine(notFoundDir.Message);
            }
            catch (UnauthorizedAccessException access)
            {
                Console.WriteLine(access.Message);
            }
            catch (FileNotFoundException notfound)
            {
                Console.WriteLine(notfound.Message);
            }
            catch (NotSupportedException notSupport)
            {
                Console.WriteLine(notSupport.Message);
            }
            catch (SecurityException secEx)
            {
                Console.WriteLine(secEx.Message);
            }
            finally
            {
                Console.WriteLine("Check finalFile.txt and see the result.");
            }
        }
    }

}
