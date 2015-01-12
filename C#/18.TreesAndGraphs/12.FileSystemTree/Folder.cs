using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemTree
{
    public class Folder
    {
        private DirectoryInfo value;
        private string name;
        private Folder parent;
        private Folder[] childFolders;
        private File[] files;

        public Folder(string path)
            : this(path, null)
        {

        }

        public Folder(string path, Folder parent)
        {
            if (path == null)
                throw new ApplicationException("Error! The value of the given file path is null.");

            //test this with invalid path and null
            this.value = new DirectoryInfo(path);


            this.name = value.Name;
            this.parent = parent;
        }

        //properties of the class
        public string Name
        {
            get { return this.name; }
        }

        public Folder Parent
        {
            get { return this.parent; }
        }

        public int NumberSubFolders
        {
            get { return this.childFolders.Length; }
        }

        public int NumberFiles
        {
            get { return this.files.Length; }
        }

        //methods of the class
        public Folder[] GetChildFolders()
        {
            if (!this.value.Exists)
                throw new ApplicationException(string.Format("Error! Does not exist a folder '{0}'.",
                    value.FullName));

            DirectoryInfo[] folders = this.value.GetDirectories();

            this.childFolders = new Folder[folders.Length];

            for (int i = 0; i < folders.Length; i++)
            {
                this.childFolders[i] = new Folder(folders[i].FullName, this);
            }

            return this.childFolders;
        }

        public File[] GetFiles()
        {
            if (!this.value.Exists)
                throw new ApplicationException(string.Format("Error! Does not exist a folder '{0}'.",
                    value.FullName));

            FileInfo[] files = this.value.GetFiles();
            this.files = new File[this.value.GetFiles().Length];

            for (int i = 0; i < files.Length; i++)
            {
                this.files[i] = new File(files[i], this);
            }

            return this.files;
        }

        public double GetFilesTotalSize()
        {
            double totalSize = 0;

            if (this.files == null)
                this.GetFiles();

            foreach (File file in this.files)
            {
                totalSize += file.Size;
            }

            return totalSize;
        }
    }
}
