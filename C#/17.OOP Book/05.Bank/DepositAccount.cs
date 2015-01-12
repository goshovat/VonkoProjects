using System;
using System.Collections.Generic;

namespace Bank
{
    class DepositAccount : Account, DepositAccountFunctions
    {
        public DepositAccount(Client client, double balance)
        {
            base.client = client;
            base.balance = balance;
            //the interestPercent of the deposit accounts is set by the bank
            base.monthlyInterestPercent = 0.0028;

            //we add the new account to the bank system
            Bank.Instance.AddAccount(this);
        }

        public override double CalculateInterest(int months)
        {
            if (months < 0)
                throw new ApplicationException(string.Format("Error! Invalid number of months: {0} for {1}'s account calculations.", 
                    months, this.client.Name));

            if (this.balance > 0 && this.balance < 1000)
            {
                return 0;
            }
            else
            {
                double interest = months * base.monthlyInterestPercent;
                return interest;
            }
        }

        public void Withdraw(double sum)
        {
            if (this.balance < sum)
                throw new ApplicationException(string.Format("Error! Cannot witdhraw the sum {0}, from {1}'s deposit account, because the balance is {2}.",
                    sum, base.client.Name, base.balance));

            base.balance -= sum;
        }
    }
}
