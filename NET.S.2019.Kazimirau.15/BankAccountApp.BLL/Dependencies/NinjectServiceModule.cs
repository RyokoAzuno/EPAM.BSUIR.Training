using BankAccountApp.BLL.Interfaces;
using BankAccountApp.BLL.Services;
using BankAccountApp.DAL.Entities;
using BankAccountApp.DAL.Interfaces;
using BankAccountApp.DAL.Repositories;
using BankAccountApp.DAL.Storages;
using Ninject.Modules;

namespace BankAccountApp.BLL.Dependencies
{
    /// <summary>
    /// Class resolver
    /// </summary>
    public class NinjectServiceModule : NinjectModule
    {
        public override void Load()
        {
            ////BankAccount acc1 = new BankAccount
            ////{
            ////    Id = 1,
            ////    FirstName = "Jane",
            ////    SecondName = "Doe",
            ////    Balance = 2000.50m,
            ////    BonusPoints = 20,
            ////    Type = AccountType.Gold,
            ////    IsOpened = true
            ////};
            ////BankAccount acc2 = new BankAccount
            ////{
            ////    Id = 2,
            ////    FirstName = "John",
            ////    SecondName = "Doe",
            ////    Balance = 15000.50m,
            ////    BonusPoints = 50,
            ////    Type = AccountType.Platinum,
            ////    IsOpened = true
            ////};
            ////BankAccount acc3 = new BankAccount
            ////{
            ////    Id = 3,
            ////    FirstName = "Steve",
            ////    SecondName = "McQueen",
            ////    Balance = 500.50m,
            ////    BonusPoints = 10,
            ////    Type = AccountType.Base,
            ////    IsOpened = true
            ////};
            ////BankAccount acc4 = new BankAccount
            ////{
            ////    Id = 4,
            ////    FirstName = "Alice",
            ////    SecondName = "Cooper",
            ////    Balance = 500.50m,
            ////    BonusPoints = 10,
            ////    Type = AccountType.Base,
            ////    IsOpened = false
            ////};
            ////List<BankAccount> bankAccounts = new List<BankAccount>();
            ////bankAccounts.AddRange(new[] { acc1, acc2, acc3, acc4 });

            ////IStorage<BankAccount> storage = new JsonStorage(bankAccounts);
            ////storage.Save();

            Bind<IUnitOfWork>().To<UnitOfWork>()
                               .WithConstructorArgument(Bind<IStorage<BankAccount>>().To<BinaryStorage>());
            Bind<IBankAccountService>().To<BankAccountService>();
        }
    }
}
