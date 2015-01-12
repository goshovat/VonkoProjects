using System;

namespace Bank
{
    class BankTest
    {
        static void Main()
        {
            //create THE bank
            Bank gansgstaBank = Bank.Instance;
                  
            //create accounts
            DepositAccount vonkoDepositAccount, drugsDepositAccount;
            CreditAccount vonkoCreditAccount, drugsCreditAccount;           
            MortgageAccount vonkoMortgageAccount, drugsMortgageAccount;

            CreateAccounts(out vonkoDepositAccount, out drugsDepositAccount, out vonkoCreditAccount, 
                out drugsCreditAccount, out vonkoMortgageAccount, out drugsMortgageAccount);

            try
            {
                CalculateInterests(vonkoDepositAccount, drugsDepositAccount, vonkoCreditAccount,
                    drugsCreditAccount, vonkoMortgageAccount, drugsMortgageAccount);

                vonkoMortgageAccount.Import(3452);
                vonkoDepositAccount.Withdraw(4500);
            }
            catch (ApplicationException applExc)
            {
                Console.WriteLine(applExc.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }

       
        private static void CreateAccounts(out DepositAccount vonkoDepositAccount, out DepositAccount drugsDepositAccount, out CreditAccount vonkoCreditAccount,
            out CreditAccount drugsCreditAccount, out MortgageAccount vonkoMortgageAccount, out MortgageAccount drugsMortgageAccount)
        {
            //for the accounts first we need clients
            PhysicalClient vonko = new PhysicalClient("Vonko");
            CompanyClient drugsCompany = new CompanyClient("Afghan Crops Incorporated",
                "Importing various plants from Afghanistan");

            vonkoDepositAccount = new DepositAccount(vonko, 2452);
            drugsDepositAccount = new DepositAccount(drugsCompany, 53433);

            vonkoCreditAccount = new CreditAccount(vonko, -1546);
            drugsCreditAccount = new CreditAccount(drugsCompany, -60000);

            vonkoMortgageAccount = new MortgageAccount(vonko, -20000);
            drugsMortgageAccount = new MortgageAccount(drugsCompany, -120000);
        }

        private static void CalculateInterests(DepositAccount vonkoDepositAccount, DepositAccount drugsDepositAccount, CreditAccount vonkoCreditAccount,
            CreditAccount drugsCreditAccount, MortgageAccount vonkoMortgageAccount, MortgageAccount drugsMortgageAccount)
        {
            Console.WriteLine("The total interest of physical deposit account with balance {0} is {1:F2}.", 
                vonkoDepositAccount.Balance, vonkoDepositAccount.CalculateInterest(8));
            Console.WriteLine("The total interest of company deposit account with balance {0} is {1:F2}.",
               drugsDepositAccount.Balance, drugsDepositAccount.CalculateInterest(8));

            Console.WriteLine("The total interest of physical credit account with balance {0} is {1:F2}.",
               vonkoCreditAccount.Balance, vonkoCreditAccount.CalculateInterest(8));
            Console.WriteLine("The total interest of company credit account with balance {0} is {1:F2}.",
               drugsCreditAccount.Balance, drugsCreditAccount.CalculateInterest(8));

            Console.WriteLine("The total interest of physical mortgage account with balance {0} is {1:F2}.",
              vonkoMortgageAccount.Balance, vonkoMortgageAccount.CalculateInterest(8));
            Console.WriteLine("The total interest of company mortgage account with balance {0} is {1:F2}.",
               drugsMortgageAccount.Balance, drugsMortgageAccount.CalculateInterest(13));
        }
    }
}
