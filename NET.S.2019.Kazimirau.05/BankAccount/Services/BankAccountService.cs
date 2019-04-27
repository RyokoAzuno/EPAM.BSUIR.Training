using System;
using System.Collections.Generic;
using System.Linq;
using BankAccount.Interfaces;

namespace BankAccount.Services
{
    // Class represents a simple bank account service
    public class BankAccountService : IPrintable
    {
        private readonly IRepository<BankAccount> _bankAccountRepository;

        public BankAccountService(IRepository<BankAccount> bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
        }

        public void Create(BankAccount bankAccount)
        {
            _bankAccountRepository.Add(bankAccount);
        }

        public List<BankAccount> GetAll()
        {
            return _bankAccountRepository.GetAll().ToList();
        }

        public BankAccount Get(int id)
        {
            return _bankAccountRepository.GetById(id);
        }

        public void Close(int id)
        {
            _bankAccountRepository.Remove(id);
        }

        public void Print()
        {
            Console.WriteLine(_bankAccountRepository.ToString());
        }
    }
}
