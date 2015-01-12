using System;
using System.Collections.Generic;
using System.IO;

using System.Text;

    class ArrangeNames
    {
        static void Main()
        {
            string sourcePathName = @"..\..\Names.txt";
            string destFileName = @"..\..\NamesArragned.txt";

            try
            {
                List<string> names = ExtractNames(sourcePathName);

                ArrangeWriteNames(names, destFileName);

                Console.WriteLine("Operation succesfully executed.");
            }
            catch (FileNotFoundException fileNotFoundExc)
            {
                Console.WriteLine("Error! The source file was not found. Details:\n{0}", fileNotFoundExc.StackTrace);
            }
            catch (NullReferenceException nullRefExc)
            {
                Console.WriteLine("Error! The list with the names is with null value! Details:\n{0}", nullRefExc.StackTrace);
            }
            catch (IOException ioExc)
            {
                Console.WriteLine("Error occured during operations with the files. Details:\n{0}", ioExc.StackTrace);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something fucked up happened! Details:\n{0}", e.StackTrace);
            }
        }

        //this method will arrange the names and save them in the new file
        private static void ArrangeWriteNames(List<string> names, string destFileName)
        {
            bool hasSwapped = true;

            while (hasSwapped)
            {
                hasSwapped = false;

                for (int i = 0; i < names.Count - 1; i++)
                {
                    if (names[i].CompareTo(names[i + 1]) > 0)
                    {
                        string temp = names[i];
                        names[i] = names[i + 1];
                        names[i + 1] = temp;

                        hasSwapped = true;
                    }
                }
            }

            //now wrtie the names in the destination file
            StreamWriter writer = new StreamWriter(destFileName, false, Encoding.GetEncoding(1251));

            using (writer)
            {
                for (int i = 0; i < names.Count; i++)
                {
                    writer.WriteLine(names[i]);
                }
            }
        }

        //this method will only extract the names from the original file and return them in a list
        private static List<string> ExtractNames(string sourcePathName)
        {
            StreamReader reader = new StreamReader(sourcePathName, Encoding.GetEncoding(1251));
            List<string> names = new List<string>();

            using (reader)
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    names.Add(line.Trim());
                    line = reader.ReadLine();
                }   
            }

            return names;
        }
    }
