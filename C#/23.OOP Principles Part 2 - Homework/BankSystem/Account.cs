namespace BankSystem
{
    using System;

    public abstract class Account : IAccountable
    {
        public Customer Customer { get; private set; }
        public decimal Balance { get; protected set; }
        public decimal InterestRate { get; private set; }

        protected Account(Customer customer, decimal startBalance, decimal interestRate)
        {
            if (startBalance <= 0)
                throw new ArgumentException("The start balance must be positive");

            this.Customer = customer;
            this.Balance = startBalance;
            this.InterestRate = interestRate;
        }

        public void Deposit(decimal sumToDeposit)
        {
            if (sumToDeposit <= 0)
                throw new ArgumentException("The sum to deposit must be positive.");

            this.Balance += sumToDeposit;
        }

        public virtual decimal CalculateInterest(int months)
        {
            if (months < 0)
                throw new ArgumentException("The months must be posiitve.");

            return months * this.InterestRate;
        }
    }
}
