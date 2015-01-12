using System;
using System.Collections.Generic;
using System.IO;

namespace FileSystemTree
{
    public class File
    {
        private FileInfo value;
        private string name;
        private Folder parent;
        //the size in megabytes
        private double size;

        public File(FileInfo file)
            : this(file, null)
        {
        }

        public File(FileInfo file, Folder parent)
        {
            if (file == null)
                throw new ApplicationException("Error! The value of the given FileInfo object is null!");

            this.value = file;
            this.name = file.Name;
            this.parent = parent;
            this.size = file.Length / 1000000;
        }

        public string Name
        {
            get { return this.name; }
        }

        public Folder Parent
        {
            get { return this.parent; }
        }

        public double Size
        {
            get { return this.size; }
        }
    }
}
