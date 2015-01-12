using System;
using System.Collections.Generic;

namespace Bank
{
    public abstract class Account : AccountFunctions
    {
        protected Client client;
        protected double balance;
        protected double monthlyInterestPercent;

        public Client Client
        {
            get { return this.client; }
            set { this.client = value; }
        }

        public double Balance
        {
            get { return this.balance; }
            set { this.balance = value; }
        }

        public double MonthlyInterestPercent
        {
            get { return this.monthlyInterestPercent; }
            set { this.monthlyInterestPercent = value; }
        }

        public abstract double CalculateInterest(int months);

        public void Import(double sum)
        {
            this.balance += sum;
        }
    }
}
