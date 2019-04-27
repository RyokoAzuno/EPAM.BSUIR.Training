using BankAccountApp.DAL.Entities;
using BankAccountApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankAccountApp.DAL.Repositories
{
    // Class simulates bank account repository
    public class BankAccountRepository : IRepository<BankAccount>
    {
        private List<BankAccount> _bankAccounts;
        private IStorage<BankAccount> _bankAccountStorage;

        public BankAccountRepository(IStorage<BankAccount> bankAccountStorage)
        {
            _bankAccountStorage = bankAccountStorage;
            _bankAccounts = _bankAccountStorage.Load().ToList();
        }

        public IEnumerable<BankAccount> GetAll() => _bankAccounts;

        public BankAccount GetById(int id)
        {
            BankAccount bankAccount = _bankAccounts.Where(a => a.Id.Equals(id)).FirstOrDefault();

            if (bankAccount != null)
            {
                return bankAccount;
            }

            throw new NullReferenceException("There is no bank account with given Id!");
        }

        public void Create(BankAccount bankAccount)
        {
            if (bankAccount != null)
            {
                _bankAccounts.Add(bankAccount);
            }
        }

        public void Update(BankAccount bankAccount)
        {
            if (bankAccount != null)
            {
                BankAccount b = GetById(bankAccount.Id);

                if (b != null)
                {
                    b.FirstName = bankAccount.FirstName;
                    b.SecondName = bankAccount.SecondName;
                    b.Balance = bankAccount.Balance;
                    b.BonusPoints = bankAccount.BonusPoints;
                    b.Type = bankAccount.Type;
                    b.IsOpened = bankAccount.IsOpened;
                }
            }
        }

        public void Delete(int id)
        {
            BankAccount bankAccount = _bankAccounts.Where(a => a.Id.Equals(id)).FirstOrDefault();

            if (bankAccount != null)
            {
                _bankAccounts.Remove(bankAccount);
            }
        }

        public override string ToString()
        {
            string result = string.Empty;
            foreach (var bankAccount in _bankAccounts)
            {
                result += $"***\n{bankAccount}\n";
            }

            return result;
        }
    }
}
