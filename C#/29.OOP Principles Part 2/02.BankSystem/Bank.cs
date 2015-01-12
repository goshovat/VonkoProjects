namespace BankSystem
{
    using System;
    using System.Collections.Generic;

    public class Bank : IEnumerable<Account>
    {
        private static Bank instance;

        private HashSet<Account> accounts;

        private Bank() 
        {
            this.accounts = new HashSet<Account>();
        }

        public static Bank Instance 
        { 
            get 
            {
                if (Bank.instance == null)
                    Bank.instance = new Bank();

                    return Bank.instance;
            } 
        }

        #region Acccounts
        public void AddAccount(Account account)
        {
            if (this.accounts.Contains(account))
                throw new ArgumentException("Cannot add an account that is already in the bank.");

            this.accounts.Add(account);
        }
        public void RemoveAccount(Account account)
        {
            if (!this.accounts.Contains(account))
                throw new ArgumentException("Cannot remove an account that is not in the bank.");

            this.accounts.Remove(account);
        }
        #endregion

        public override string ToString()
        {
            return "The Vonko Bank";
        }

        public IEnumerator<Account> GetEnumerator()
        {
            return this.accounts.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
