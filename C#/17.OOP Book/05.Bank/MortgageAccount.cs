using System;

namespace Bank
{
    public class MortgageAccount : Account
    {   
        public MortgageAccount(Client client, double balance)
        {
            base.client = client;
            base.balance = balance;
            //the interestPercent of the mortgage accounts is set by the bank
            base.monthlyInterestPercent = 0.003;
        }

        public override double CalculateInterest(int months)
        {
            if (months < 0)
                throw new ApplicationException(string.Format("Error! Invalid number of months: {0} for {1}'s account calculations.",
                    months, this.client.Name));

            if (base.client.GetType().Name == "Bank.PhysicalClient")
            {
                //for the first 6 months no interest is calculated
                months = Math.Max(0, months - 6);

                double interest = months * base.monthlyInterestPercent;
                return interest;
            }
            else
            {
                //for companies the first 12 months the percentage of interest is half
                int promotionMonths = Math.Min(months, 12);

                double interest = promotionMonths * base.monthlyInterestPercent;

                if (months > 12)
                {
                    interest += (months - promotionMonths) * base.monthlyInterestPercent;
                }

                return interest;
            }
        }
    }
}
