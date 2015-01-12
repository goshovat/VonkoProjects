namespace BankSystem
{
    using System;

    class BankSystemMain
    {
        static void Main(string[] args)
        {
            Bank theBank = Bank.Instance;

            Customer vonko = new Individual("Vonko Mihov");
            Customer goshkoCompany = new Company("Goshko Co");

            Account depositAccountInd = new DepositAccount(vonko, 2500);
            Account loanAccountInd = new LoanAccount(vonko, 1500);
            Account mortgageAccountInd = new MortgageAccount(vonko, 25000);
            Account depositAccountCom = new DepositAccount(goshkoCompany, 10000);
            Account loanAccountCom = new LoanAccount(goshkoCompany, 5000);
            Account mortgageAccountCom = new MortgageAccount(goshkoCompany, 45000);

            theBank.AddAccount(depositAccountInd);
            theBank.AddAccount(loanAccountInd);
            theBank.AddAccount(mortgageAccountInd);
            theBank.AddAccount(depositAccountCom);
            theBank.AddAccount(loanAccountCom);
            theBank.AddAccount(mortgageAccountCom);

            loanAccountInd.Deposit(250);
            mortgageAccountCom.Deposit(3200);

            foreach(Account account in theBank)
            {
                decimal calclulatedInterest = account.CalculateInterest(13);
                Console.WriteLine("Calclulated interest: {0}, new balance: {1}",
                    calclulatedInterest, account.Balance + account.Balance * calclulatedInterest);
            }
        }
    }
}
