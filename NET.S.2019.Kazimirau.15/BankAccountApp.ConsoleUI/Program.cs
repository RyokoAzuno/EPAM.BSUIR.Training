using BankAccountApp.BLL.DataTransferObjects;
using BankAccountApp.BLL.Dependencies;
using BankAccountApp.BLL.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankAccountApp.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel(new NinjectServiceModule());
            IBankAccountService bankService = kernel.Get<IBankAccountService>();
            BankAccountDTO acc1 = new BankAccountDTO
            {
                Id = 5,
                FirstName = "Test",
                SecondName = "Name",
                Balance = 3000.50m,
                BonusPoints = 25,
                Type = AccountTypeDTO.Gold,
                IsOpened = true
            };
            BankAccountDTO acc2 = new BankAccountDTO
            {
                Id = 6,
                FirstName = "James",
                SecondName = "Doe",
                Balance = 13040.50m,
                BonusPoints = 60,
                Type = AccountTypeDTO.Platinum,
                IsOpened = true
            };
            BankAccountDTO acc3 = new BankAccountDTO
            {
                Id = 7,
                FirstName = "Steve",
                SecondName = "McQueen",
                Balance = 500.50m,
                BonusPoints = 10,
                Type = AccountTypeDTO.Base,
                IsOpened = true
            };
            BankAccountDTO acc4 = new BankAccountDTO
            {
                Id = 8,
                FirstName = "Alice",
                SecondName = "Cooper",
                Balance = 500.50m,
                BonusPoints = 10,
                Type = AccountTypeDTO.Base,
                IsOpened = false
            };

            //bankService.CreateNew(acc1);
            //bankService.CreateNew(acc2);
            //bankService.CreateNew(acc3);
            //bankService.CreateNew(acc4);

            List<BankAccountDTO> bankAccounts = bankService.GetAll().ToList();
            bankAccounts.ForEach(Console.WriteLine);

            Console.WriteLine();
            //bankService.Close(4);
            Console.WriteLine(bankService.Get(4));

            Console.WriteLine();
            //bankService.Deposit(1, 999.43m);
            bankService.Withdraw(1, 230.40m);
            Console.WriteLine(bankService.Get(1));
        }
    }
}
