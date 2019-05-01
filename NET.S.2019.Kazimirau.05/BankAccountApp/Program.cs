using BankAccountApp.Interfaces;
using BankAccountApp.Models;
using BankAccountApp.Services;
using BankAccountApp.Storages;
using System;
using System.Collections.Generic;

namespace BankAccountApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount acc1 = new BankAccount("Jane Doe", 2000.50m, 20, AccountType.Gold, true);
            BankAccount acc2 = new BankAccount("John Doe", 15000.50m, 50, AccountType.Platinum, true);
            BankAccount acc3 = new BankAccount("Steve McQueen", 500.50m, 10, AccountType.Base, true);
            BankAccount acc4 = new BankAccount("Alice Cooper", 500.50m, 10, AccountType.Base, false);
            List<BankAccount> bankAccounts = new List<BankAccount>();
            bankAccounts.AddRange(new[] { acc1, acc2, acc3, acc4 });

            IStorage<BankAccount> storage = new JsonStorage(bankAccounts);
            storage.Save();
            IRepository<BankAccount> repository = new BankAccountRepository(storage);
            BankAccountService service = new BankAccountService(repository);
            //service.Create(acc1);
            //service.Create(acc2);
            //service.Create(acc3);
            service.Print();
            
            Console.WriteLine();
        }
    }
}
