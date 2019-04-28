﻿using BankAccountApp.DAL.Entities;
using BankAccountApp.DAL.Interfaces;

namespace BankAccountApp.DAL.Repositories
{
    // Class represents a compositing root that pass data to BLL layer
    public class UnitOfWork : IUnitOfWork
    {
        private IRepository<BankAccount> _bankAccountRepository;
        private IStorage<BankAccount> _bankAccountStorage;

        public UnitOfWork(IStorage<BankAccount> bankAccountStorage)
        {
            _bankAccountStorage = bankAccountStorage;
        }

        public IRepository<BankAccount> BankAccounts
        {
            get
            {
                if (_bankAccountRepository == null)
                {
                    _bankAccountRepository = new BankAccountRepository(_bankAccountStorage);
                }

                return _bankAccountRepository;
            }
        }

        /// <summary>
        /// Save changes to storage
        /// </summary>
        public void Commit()
        {
            _bankAccountStorage.Save();
        }
    }
}