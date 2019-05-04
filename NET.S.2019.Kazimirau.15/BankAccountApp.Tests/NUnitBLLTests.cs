using BankAccountApp.BLL.DataTransferObjects;
using BankAccountApp.BLL.Interfaces;
using BankAccountApp.BLL.Services;
using BankAccountApp.CCL.Mappers;
using BankAccountApp.DAL.Entities;
using BankAccountApp.DAL.Interfaces;
using BankAccountApp.DAL.Repositories;
using BankAccountApp.DAL.Storages;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace BankAccountApp.Tests
{
    [TestFixture]
    public class NUnitBLLTests
    {
        private List<BankAccountDTO> _bankAccounts;

        [SetUp]
        public void SetUp()
        {
            _bankAccounts = new List<BankAccountDTO>();

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
                IsOpened = true
            };

            _bankAccounts.AddRange(new[] { acc1, acc2, acc3, acc4 });
        }

        [Test]
        public void BankAccountService_Moq_Tests()
        {
            var mockService = new Mock<IBankAccountService>();
            mockService.Setup(s => s.ShowAll()).Returns(_bankAccounts);
            mockService.Setup(s => s.Show(6)).Returns(_bankAccounts.Where(a => a.Id == 6).FirstOrDefault());

            Assert.AreEqual(60, mockService.Object.ShowAll().Where(a => a.Id == 6).FirstOrDefault().BonusPoints);
            Assert.AreEqual(AccountTypeDTO.Base, mockService.Object.ShowAll().Where(a => a.Id == 8).FirstOrDefault().Type);
            Assert.AreEqual(13040.50m, mockService.Object.ShowAll().Where(a => a.Id == 6).FirstOrDefault().Balance);
            Assert.AreEqual("James", mockService.Object.Show(6).FirstName);
        }

        [Test]
        public void BankAccountService_Tests()
        {
            IEnumerable<BankAccount> accs = CustomMapper<BankAccountDTO, BankAccount>.Map(_bankAccounts);
            IStorage<BankAccount> storage = new MemoryStorage(accs);
            storage.Save();
            IUnitOfWork unitOfWork = new UnitOfWork(storage);
            IBankAccountService service = new BankAccountService(unitOfWork);

            BankAccountDTO bankAccount = service.Show(8);
            service.Deposit(bankAccount.Id, 200m);

            Assert.AreEqual(8, bankAccount.Id);
            bankAccount = service.Show(8);
            Assert.AreEqual(700.50m, bankAccount.Balance);
            Assert.AreEqual(20, bankAccount.BonusPoints);

            service.Withdraw(8, 500.50m);
            bankAccount = service.Show(8);
            Assert.AreEqual(200m, bankAccount.Balance);
        }
    }
}
