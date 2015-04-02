using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DocumentSystem
{
    public class DocumentSystem
    {
        private static IList<IDocument> documents = new List<IDocument>();

        static void Main()
        {
            IList<string> allCommands = ReadAllCommands();
            ExecuteCommands(allCommands);
        }

        private static IList<string> ReadAllCommands()
        {
            List<string> commands = new List<string>();
            while (true)
            {
                string commandLine = Console.ReadLine();
                if (commandLine == "")
                {
                    // End of commands
                    break;
                }
                commands.Add(commandLine);
            }
            return commands;
        }

        private static void ExecuteCommands(IList<string> commands)
        {
            foreach (var commandLine in commands)
            {
                int paramsStartIndex = commandLine.IndexOf("[");
                string cmd = commandLine.Substring(0, paramsStartIndex);
                int paramsEndIndex = commandLine.IndexOf("]");
                string parameters = commandLine.Substring(
                    paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
                ExecuteCommand(cmd, parameters);
            }
        }

        private static void ExecuteCommand(string cmd, string parameters)
        {
            string[] cmdAttributes = parameters.Split(
                new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            if (cmd == "AddTextDocument")
            {
                AddTextDocument(cmdAttributes);
            }
            else if (cmd == "AddPDFDocument")
            {
                AddPdfDocument(cmdAttributes);
            }
            else if (cmd == "AddWordDocument")
            {
                AddWordDocument(cmdAttributes);
            }
            else if (cmd == "AddExcelDocument")
            {
                AddExcelDocument(cmdAttributes);
            }
            else if (cmd == "AddAudioDocument")
            {
                AddAudioDocument(cmdAttributes);
            }
            else if (cmd == "AddVideoDocument")
            {
                AddVideoDocument(cmdAttributes);
            }
            else if (cmd == "ListDocuments")
            {
                ListDocuments();
            }
            else if (cmd == "EncryptDocument")
            {
                EncryptDocument(parameters);
            }
            else if (cmd == "DecryptDocument")
            {
                DecryptDocument(parameters);
            }
            else if (cmd == "EncryptAllDocuments")
            {
                EncryptAllDocuments();
            }
            else if (cmd == "ChangeContent")
            {
                ChangeContent(cmdAttributes[0], cmdAttributes[1]);
            }
            else
            {
                throw new InvalidOperationException("Invalid command: " + cmd);
            }
        }

        private static void AddTextDocument(string[] attributes)
        {
            AddDocument(new TextDocument(), attributes);
        }

        private static void AddPdfDocument(string[] attributes)
        {
            AddDocument(new PDFDocument(), attributes);
        }

        private static void AddWordDocument(string[] attributes)
        {
            AddDocument(new WordDocument(), attributes);
        }

        private static void AddExcelDocument(string[] attributes)
        {
            AddDocument(new ExcelDocument(), attributes);
        }

        private static void AddAudioDocument(string[] attributes)
        {
            AddDocument(new AudioDocument(), attributes);
        }

        private static void AddVideoDocument(string[] attributes)
        {
            AddDocument(new VideoDocument(), attributes);
        }

        private static void AddDocument(IDocument doc, string[] attributes)
        {
            foreach (var attr in attributes)
            {
                string[] pair = attr.Split('=');
                string key = pair[0];
                string value = pair[1];
                doc.LoadProperty(key, value);
            }
            if (doc.Name != null)
            {
                documents.Add(doc);
                Print("Document added: " + doc.Name);
            }
            else
            {
                Print("Document has no name");
            }
        }

        private static void ListDocuments()
        {
            if (documents.Count > 0)
            {
                foreach (var doc in documents)
                {
                    Print(doc.ToString());
                }
            }
            else
            {
                Print("No documents found");
            }
        }

        private static void EncryptDocument(string name)
        {
            bool documentFound = false;
            foreach (var doc in documents)
            {
                if (doc.Name == name)
                {
                    if (doc is IEncryptable)
                    {
                        ((IEncryptable)doc).Encrypt();
                        Print("Document encrypted: " + name);
                    }
                    else
                    {
                        Print("Document does not support encryption: " + name);
                    }
                    documentFound = true;
                }
            }
            if (!documentFound)
            {
                Print("Document not found: " + name);
            }
        }

        private static void DecryptDocument(string name)
        {
             bool documentFound = false;
             foreach (var doc in documents)
             {
                 if (doc.Name == name)
                 {
                     if (doc is IEncryptable)
                     {
                         ((IEncryptable)doc).Decrypt();
                         Print("Document decrypted: " + name);
                     }
                     else
                     {
                         Print("Document does not support decryption: " + name);
                     }
                     documentFound = true;
                 }
             }
             if (!documentFound)
             {
                 Print("Document not found: " + name);
             }
        }

        private static void EncryptAllDocuments()
        {
            bool documentFound = false;
            foreach (var doc in documents)
            {
                if (doc is IEncryptable)
                {
                    ((IEncryptable)doc).Encrypt();
                    documentFound = true;
                }
            }
            if (documentFound)
            {
                Print("All documents encrypted");
            }
            else
            {
                Print("No encryptable documents found");
            }
        }

        private static void ChangeContent(string name, string content)
        {
            bool documentFound = false;
            foreach (var doc in documents)
            {
                if (doc.Name == name)
                {
                    if (doc is IEditable)
                    {
                        ((IEditable)doc).ChangeContent(content);
                        Print("Document content changed: " + doc.Name);
                    }
                    else
                    {
                        Print("Document is not editable: " + doc.Name);
                    }
                    documentFound = true;
                }
            }
            if (!documentFound)
            {
                Print("Document not found: " + name);
            }
        }


        private static void Print(string content)
        {
            //use this proxy in case I need tow rite in a file
            Console.WriteLine(content); 
        }
    }
}
