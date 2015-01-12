using System;
using System.Collections.Generic;

namespace Bank
{
    public class Bank
    {
        private static Bank instance;
        private string name;

        private List<Account> accounts;

        static Bank()
        {
            Bank.instance = new Bank("Gangsta Bank");
        }

        private Bank(string name) 
        {
            this.accounts = new List<Account>();
            this.name = name;
        }

        public static Bank Instance
        {
            get { return Bank.instance; }
        }

        public string Name
        {
            get { return this.name; }
        }

        public void AddAccount(Account account)
        {
            if (this.accounts.Contains(account))
                throw new ApplicationException("Error! Cannot add the account, because it is already in the bank.");

            this.accounts.Add(account);
        }

        public void RemoveAccount(Account account)
        {
            if (this.accounts.IndexOf(account) == -1)
            {
                throw new ApplicationException("Error! Cannot remove non-existing account.");
            }
            else
            {
                this.accounts.Remove(account);
            }
        }
    }
}
