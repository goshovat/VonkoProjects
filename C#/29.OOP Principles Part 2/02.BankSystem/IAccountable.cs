namespace BankSystem
{
    using System;

    public interface IAccountable
    {
        void Deposit(decimal sumToDeposit);

        decimal CalculateInterest(int months);
    }
}
