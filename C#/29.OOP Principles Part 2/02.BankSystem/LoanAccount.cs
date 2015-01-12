namespace BankSystem
{
    using System;

    public class LoanAccount : Account
    {
        public const decimal LOAN_INTEREST_RATE = 0.0039M;

        public LoanAccount(Customer customer, decimal startBalance)
            : base(customer, startBalance, LOAN_INTEREST_RATE) { }

        public override decimal CalculateInterest(int months)
        {
            if (base.Customer.GetType().Name == "Individual")
                return Math.Max(months - 3, 0) * base.InterestRate;
            else
                return Math.Max(months - 2, 0) * base.InterestRate;
        }

        public override string ToString()
        {
            return string.Format("Loan Account, balance {0}", base.Balance);
        }
    }
}