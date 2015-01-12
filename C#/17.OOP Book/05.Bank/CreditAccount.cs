using System;

namespace Bank
{
    class CreditAccount : Account
    {
        public CreditAccount(Client client, double balance)
        {
            base.client = client;
            base.balance = balance;
            //the interestPercent of the credit accounts is set by the bank
            base.monthlyInterestPercent = 0.0036;
        }

        public override double CalculateInterest(int months)
        {
            if (months < 0)
                throw new ApplicationException(string.Format("Error! Invalid number of months: {0} for {1}'s account calculations.",
                    months, this.client.Name));

            if (base.client.GetType().Name == "Bank.PhysicalClient")
            {
                //for the first 3 months no interest is calculated
                months = Math.Max(0, months - 3);

                double interest = months * base.monthlyInterestPercent;
                return interest;
            }
            else
            {
                //for the first 2 months no interest is calculated
                months = Math.Max(0, months - 2);

                double interest = months * base.monthlyInterestPercent;
                return interest;
            }
        }
    }
}
