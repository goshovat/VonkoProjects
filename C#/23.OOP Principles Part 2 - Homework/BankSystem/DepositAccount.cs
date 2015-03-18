namespace BankSystem
{
    using System;

    public class DepositAccount : Account, IWithdrawable
    {
        public const decimal DEPOSIT_INTEREST_RATE = 0.0023M;

        public DepositAccount(Customer customer, decimal startBalance)
            : base(customer, startBalance, DEPOSIT_INTEREST_RATE) { }

        public void Withdraw(decimal sumToWitdraw)
        {
            if (sumToWitdraw < 0)
                throw new ArgumentException("The sum to withdraw must be positive");

            base.Balance -= sumToWitdraw;
        }
        public override decimal CalculateInterest(int months)
        {
            if (base.Balance > 0 && base.Balance < 1000)
                return 0;
            else return base.CalculateInterest(months);
        }
        public override string ToString()
        {
            return string.Format("Deposit Account, balance {0}", base.Balance);
        }
    }
}
