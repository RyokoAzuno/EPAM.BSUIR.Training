using System;
using System.Collections.Generic;
using System.Linq;
using BankAccount.Interfaces;

namespace BankAccount.Services
{
    public class BankAccountRepository : IRepository<BankAccount>
    {
        private List<BankAccount> _db;

        public BankAccountRepository() => _db = new List<BankAccount>();

        public void Add(BankAccount bankAccount)
        {
            if (bankAccount != null)
                _db.Add(bankAccount);
        }

        public IEnumerable<BankAccount> GetAll() => _db;

        public BankAccount GetById(int id)
        {
            BankAccount bankAccount = _db.Where(a => a.Id.Equals(id)).FirstOrDefault();

            if (bankAccount != null)
                return bankAccount;

            throw new NullReferenceException("There is no bank account with given Id!");
        }

        public void Remove(int id)
        {
            BankAccount bankAccount = _db.Where(a => a.Id.Equals(id)).FirstOrDefault();

            if (bankAccount != null)
                _db.Remove(bankAccount);
        }
    }
}
