using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Wintellect.PowerCollections;

namespace PhoneBook
{
    public sealed class PhoneBook
    {
        private static PhoneBook instance;

        /*This phonebook uses data structures that perform quick operations for 
        finding entries. Even with 1000000 entries, the speed of accessing entries will be constant.
        Instead of .NET Dictionary I use the Wintellect Power Collection's MultiDicitonary, allowing
        the entry of multiple values for the same key*/
        private MultiDictionary<string, string> firstNamesTable;
        private MultiDictionary<string, string> lastNamesTable;
        private MultiDictionary<string, string> phonesTable;
        private MultiDictionary<string, string> addressesTable;

        /*the constructor can be called only from within. So we guarantee the class
        will be initiated only once*/
        private PhoneBook()
        {
            this.firstNamesTable = new MultiDictionary<string, string>(true);
            this.lastNamesTable = new MultiDictionary<string, string>(true);
            this.phonesTable = new MultiDictionary<string, string>(true);
            this.addressesTable = new MultiDictionary<string, string>(true);
        }

        public static PhoneBook Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PhoneBook();
                }
                return PhoneBook.instance;
            }
        }

        /*by using the PersonData class it will be convinient to make new entry
        in the phonebook, even if the person is with 10+ number of properties*/
        public void AddEntry(PersonData data)
        {
            string entry = data.ToString();

            this.firstNamesTable.Add(data.FirstName, entry);
            this.lastNamesTable.Add(data.LastName, entry);
            this.phonesTable.Add(data.Phone, entry);
            this.addressesTable.Add(data.Address, entry);
        }

        //methods that find an entry by a given criteria
        public ICollection<string> SearchByFirstName(string firstName)
        {
            if (!this.firstNamesTable.ContainsKey(firstName))
                throw new ApplicationException(string.Format(
                        "Error! The name {0} is not in the phonebook.", firstName
                    ));

            return this.firstNamesTable[firstName];
        }

        public ICollection<string> SearchByLastName(string lastName)
        {
            if (!this.lastNamesTable.ContainsKey(lastName))
                throw new ApplicationException(string.Format(
                        "Error! The name {0} is not in the phonebook.", lastName
                    ));

            return this.lastNamesTable[lastName];
        }

        public ICollection<string> SearchByPhone(string phone)
        {
            if (!this.phonesTable.ContainsKey(phone))
                throw new ApplicationException(string.Format(
                        "Error! The name {0} is not in the phonebook.", phone
                    ));

            return this.phonesTable[phone];
        }

        public ICollection<string> SearchByAddress(string address)
        {
            if (!this.addressesTable.ContainsKey(address))
                throw new ApplicationException(string.Format(
                        "Error! The name {0} is not in the phonebook.", address
                    ));

            return this.addressesTable[address];
        }

        //methods to remove entries
        public void DeleteByFirstName(string firstName)
        {
            if (!firstNamesTable.ContainsKey(firstName))
                throw new ApplicationException(
                    "Error! Cannot delete the entry, because it is not in the phonebook.");

            ICollection<string> entriesToDel = new List<string>(
                firstNamesTable[firstName]);

            foreach (string entry in entriesToDel)
                this.DeleteEntry(entry);
        }

        public void DeleteByLastName(string lastName)
        {
            if (!lastNamesTable.ContainsKey(lastName))
                throw new ApplicationException(
                    "Error! Cannot delete the entry, because it is not in the phonebook.");

            ICollection<string> entriesToDel = new List<string>(
                lastNamesTable[lastName]);

            foreach (string entry in entriesToDel)
                this.DeleteEntry(entry);
        }

        public void DeleteByPhone(string phone)
        {
            if (!phonesTable.ContainsKey(phone))
                throw new ApplicationException(
                    "Error! Cannot delete the entry, because it is not in the phonebook.");

            ICollection<string> entriesToDel = new List<string>(
                phonesTable[phone]);

            foreach (string entry in entriesToDel)
                this.DeleteEntry(entry);
        }

        public void DeleteByAddress(string address)
        {
            if (!addressesTable.ContainsKey(address))
                throw new ApplicationException(
                    "Error! Cannot delete the entry, because it is not in the phonebook.");

            ICollection<string> entriesToDel = new List<string>(
                addressesTable[address]);

            foreach (string entry in entriesToDel)
                this.DeleteEntry(entry);
        }

        //methods that update entries by given criteria
        public void UpdateByFirstName(string firstName, PersonData newData)
        {
            ICollection<string> oldEntries = new List<string>(
                this.firstNamesTable[firstName]);

            foreach(string oldEntry in oldEntries)
                DeleteEntry(oldEntry);


            AddEntry(newData);
        }

        public void UpdateByLastName(string lastName, PersonData newData)
        {
            ICollection<string> oldEntries = new List<string>(
                this.lastNamesTable[lastName]);

            foreach (string oldEntry in oldEntries)
                DeleteEntry(oldEntry);

            AddEntry(newData);
        }

        public void UpdateByPhone(string phone, PersonData newData)
        {
            ICollection<string> oldEntries = new List<string>(
                this.phonesTable[phone]);

            foreach (string oldEntry in oldEntries)
                DeleteEntry(oldEntry);

            AddEntry(newData);
        }

        public void UpdateByAddress(string address, PersonData newData)
        {
            ICollection<string> oldEntries = new List<string>(
                this.addressesTable[address]);

            foreach (string oldEntry in oldEntries)
                DeleteEntry(oldEntry);

            AddEntry(newData);
        }

        /*by the entries will be sorted as strings, if necessary a different criteria
        can by given by using IComparer*/
        public string SortByFirstName()
        {
            StringBuilder builder = new StringBuilder();
            List<string> firstNames = 
                new List<string> (this.firstNamesTable.Keys);
            firstNames.Sort();

            foreach (string name in firstNames)
            {
                ICollection<string> entries = this.firstNamesTable[name];
                foreach (string entry in entries)
                {
                    builder.Append(entry + "\n");
                }
            }
            return builder.ToString();
        }

        public string SortByLastName()
        {
            StringBuilder builder = new StringBuilder();
            List<string> lastNames =
                new List<string>(this.lastNamesTable.Keys);
            lastNames.Sort();

            foreach (string name in lastNames)
            {
                ICollection<string> entries = this.lastNamesTable[name];
                foreach (string entry in entries)
                {
                    builder.Append(entry + "\n");
                }
            }
            return builder.ToString();
        }

        public string SortByPhone()
        {
            StringBuilder builder = new StringBuilder();
            List<string> phones =
                new List<string>(this.phonesTable.Keys);
            phones.Sort();

            foreach (string phone in phones)
            {
                ICollection<string> entries = this.phonesTable[phone];
                foreach (string entry in entries)
                {
                    builder.Append(entry + "\n");
                }
            }
            return builder.ToString();
        }

        public string SortByAddress()
        {
            StringBuilder builder = new StringBuilder();
            List<string> addresses =
                new List<string>(this.addressesTable.Keys);
            addresses.Sort();

            foreach (string address in addresses)
            {
                ICollection<string> entries = this.addressesTable[address];
                foreach (string entry in entries)
                {
                    builder.Append(entry + "\n");
                }
            }
            return builder.ToString();
        }
        
        //contacts will be imported from a file of correct format
        public void Import(string filename)
        {
            StreamReader reader = new StreamReader(filename);

            using (reader)
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    string[] entities = line.Split(new char[] { ';' },
                        StringSplitOptions.RemoveEmptyEntries);

                    if (entities.Length != 4)
                        throw new ApplicationException(string.Format(
                            "Error! Cannot import frmo file {0} because of incorrect data", filename));

                    string firstName = entities[0].Trim();
                    string lastName = entities[1].Trim();
                    string phone = entities[2].Trim();
                    string address = entities[3].Trim();

                    this.AddEntry(new PersonData(firstName, lastName, phone, address));

                    line = reader.ReadLine();
                }
            }
        }

        /*in the project folder a text file will be created with the given name
        and all entries will be written inside*/
        public void Export(string fileName)
        {
            string allEntries = this.ToString();

            StreamWriter writer = new StreamWriter(fileName);

            using (writer)
            {
                foreach (string name in this.firstNamesTable.Keys)
                {
                    ICollection<string> entries = this.firstNamesTable[name];
                    foreach (string entry in entries)
                    {
                        writer.WriteLine(entry);
                    }
                }
            }
        }

        public override string ToString()
        {
            //I use string builder because string concatenation is extremely slow operation
            StringBuilder builder = new StringBuilder();
            foreach (KeyValuePair<string, ICollection<string>> pair in this.firstNamesTable)
            {
                foreach (string entry in pair.Value)
                {
                    builder.Append(entry + "\n");
                }
            }
            return builder.ToString();
        }

        //private methods for internal use
        private string[] SplitEntry(string entryToDel)
        {
            return entryToDel.Split(new char[] { ';' },
                StringSplitOptions.RemoveEmptyEntries);
        }

        private void DeleteEntry(string entryToDel)
        {
            string[] entities = SplitEntry(entryToDel);

            string firstName = entities[0].Trim();
            string lastName = entities[1].Trim();
            string phone = entities[2].Trim();
            string address = entities[3].Trim();

            this.firstNamesTable.Remove(firstName);
            this.lastNamesTable.Remove(lastName);
            this.phonesTable.Remove(phone);
            this.addressesTable.Remove(address);
        }
    }
}
