using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BankAccountApp.DAL.EFContexts;
using BankAccountApp.DAL.Entities;
using BankAccountApp.DAL.Interfaces;

namespace BankAccountApp.DAL.Repositories
{
    // Class simulates bank account repository
    public class BankAccountEFRepository : IRepository<BankAccount>
    {
        private BankAccountContext _bankAccountStorage;

        public BankAccountEFRepository(string connectionString)
        {
            _bankAccountStorage = new BankAccountContext(connectionString);
        }

        /// <summary>
        /// Get all bank accounts
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BankAccount> GetAll()
        {
            return _bankAccountStorage.BankAccounts;
        }

        /// <summary>
        /// Get bank account by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BankAccount GetById(int id)
        {
            BankAccount bankAccount = _bankAccountStorage.BankAccounts.Where(a => a.Id.Equals(id)).FirstOrDefault();

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
                _bankAccountStorage.BankAccounts.Add(bankAccount);
                _bankAccountStorage.SaveChanges();
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
                _bankAccountStorage.Entry(bankAccount).State = EntityState.Modified;
                _bankAccountStorage.SaveChanges();
            }
        }

        /// <summary>
        /// Delete bank account by id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            BankAccount bankAccount = _bankAccountStorage.BankAccounts.Where(a => a.Id.Equals(id)).FirstOrDefault();

            if (bankAccount != null)
            {
                _bankAccountStorage.BankAccounts.Remove(bankAccount);
                _bankAccountStorage.SaveChanges();
            }
        }

        /// <summary>
        /// Method represents Bank account as a string
        /// </summary>
        public override string ToString()
        {
            string result = string.Empty;
            foreach (var bankAccount in GetAll())
            {
                result += $"***\n{bankAccount}\n";
            }

            return result;
        }
    }
}
