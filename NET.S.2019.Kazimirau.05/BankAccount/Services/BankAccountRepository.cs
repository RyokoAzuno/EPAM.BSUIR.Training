using BankAccount.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankAccount.Services
{
    // Simulate bank account repository
    public class BankAccountRepository : IRepository<BankAccount>
    {
        private List<BankAccount> _bankAccounts;
        private IStorage<BankAccount> _bankAccountStorage;

        public BankAccountRepository(IStorage<BankAccount> bankAccountStorage)
        {
            _bankAccountStorage = bankAccountStorage;
            _bankAccounts = _bankAccountStorage.Load().ToList();
        }

        public void Add(BankAccount bankAccount)
        {
            if (bankAccount != null)
                _bankAccounts.Add(bankAccount);
        }

        public IEnumerable<BankAccount> GetAll() => _bankAccounts;

        public BankAccount GetById(int id)
        {
            BankAccount bankAccount = _bankAccounts.Where(a => a.Id.Equals(id)).FirstOrDefault();

            if (bankAccount != null)
                return bankAccount;

            throw new NullReferenceException("There is no bank account with given Id!");
        }

        public void Remove(int id)
        {
            BankAccount bankAccount = _bankAccounts.Where(a => a.Id.Equals(id)).FirstOrDefault();

            if (bankAccount != null)
                _bankAccounts.Remove(bankAccount);
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
