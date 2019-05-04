using System;
using System.Collections.Generic;
using System.Linq;
using BankAccountApp.DAL.Entities;
using BankAccountApp.DAL.Interfaces;

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

        /// <summary>
        /// Get all bank accounts
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BankAccount> GetAll() => _bankAccounts;

        /// <summary>
        /// Get bank account by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BankAccount GetById(int id)
        {
            BankAccount bankAccount = _bankAccounts.Where(a => a.Id.Equals(id)).FirstOrDefault();

            if (bankAccount != null)
            {
                return bankAccount;
            }

            throw new NullReferenceException("There is no bank account with given Id!");
        }

        /// <summary>
        /// Create new bank account
        /// </summary>
        /// <param name="bankAccount"></param>
        public void Create(BankAccount bankAccount)
        {
            if (bankAccount != null)
            {
                if (_bankAccounts.Select(acc => acc.Id).Contains(bankAccount.Id))
                {
                    int id = _bankAccounts.Max(b => b.Id) + 1;
                    bankAccount.Id = id;
                }
                
                _bankAccounts.Add(bankAccount);
            }
        }

        /// <summary>
        /// Update current bank account
        /// </summary>
        /// <param name="bankAccount"></param>
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

        /// <summary>
        /// Delete bank account by id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            BankAccount bankAccount = _bankAccounts.Where(a => a.Id.Equals(id)).FirstOrDefault();

            if (bankAccount != null)
            {
                _bankAccounts.Remove(bankAccount);
            }
        }

        /// <summary>
        /// Method represents Bank account as a string
        /// </summary>
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
