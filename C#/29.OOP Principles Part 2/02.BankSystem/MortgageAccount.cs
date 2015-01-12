namespace BankSystem
{
    using System;

    public class MortgageAccount : Account
    {
        public const decimal MORTGAGE_INTEREST_RATE = 0.0036M;

        public MortgageAccount(Customer customer, decimal startBalance)
            : base(customer, startBalance, MORTGAGE_INTEREST_RATE) { }

        public override decimal CalculateInterest(int months)
        {
            if (base.Customer.GetType().Name == "Individual") 
            {
                return Math.Max(months - 6, 0) * base.InterestRate;
            }
            else
            {
                if (months >= 12)
                    return (12M * (base.InterestRate / 2M) + (months - 12) * base.InterestRate);
                else
                    return months * (base.InterestRate / 2);
            }            
        }

        public override string ToString()
        {
            return string.Format("Mortgage Account, balance {0}", base.Balance);
        }
    }
}