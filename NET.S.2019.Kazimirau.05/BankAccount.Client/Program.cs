using BankAccount.Interfaces;
using BankAccount.Services;
using System;

namespace BankAccount.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount acc1 = new BankAccount("Jane Doe", 2000.50m, 20, AccountType.Gold);
            BankAccount acc2 = new BankAccount("John Doe", 15000.50m, 50, AccountType.Platinum);
            BankAccount acc3 = new BankAccount("Steve McQueen", 500.50m, 10, AccountType.Base);

            IRepository<BankAccount> repository = new BankAccountRepository();
            BankAccountService service = new BankAccountService(repository);
            service.Create(acc1);
            service.Create(acc2);
            service.Create(acc3);
            service.Print();
            
            Console.WriteLine();
        }
    }
}
