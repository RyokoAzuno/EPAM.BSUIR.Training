using System;
using System.Collections.Generic;
using BankAccountApp.BLL.DataTransferObjects;
using BankAccountApp.BLL.Interfaces;
using BankAccountApp.CCL.Mappers;
using BankAccountApp.DAL.Entities;
using BankAccountApp.DAL.Interfaces;

namespace BankAccountApp.BLL.Services
{
    /// <summary>
    /// Class that represents bank account service
    /// </summary>
    public class BankAccountService : IBankAccountService
    {
        private IUnitOfWork _db;

        public BankAccountService(IUnitOfWork unitOfWork)
        {
            _db = unitOfWork;
        }

        /// <summary>
        /// Close bank account by Id
        /// </summary>
        /// <param name="id"></param>
        public void Close(int id)
        {
            BankAccount bankAccount = _db.BankAccounts.GetById(id);
            bankAccount.IsOpened = false;
            _db.BankAccounts.Update(bankAccount);
        }

        /// <summary>
        /// Open again bank account by Id
        /// </summary>
        /// <param name="id"></param>
        public void Open(int id)
        {
            BankAccount bankAccount = _db.BankAccounts.GetById(id);
            bankAccount.IsOpened = true;
            _db.BankAccounts.Update(bankAccount);
        }

        /// <summary>
        /// Create new bank account 
        /// </summary>
        /// <param name="bankAccountDTO"></param>
        public void CreateNew(BankAccountDTO bankAccountDTO)
        {
            if (bankAccountDTO == null)
            {
                throw new ArgumentNullException("Bank account can't be null!!");
            }

            BankAccount bankAccount = CustomMapper<BankAccountDTO, BankAccount>.Map(bankAccountDTO); ////new BankAccount

            _db.BankAccounts.Create(bankAccount);
        }

        /// <summary>
        /// Add amount of money to the bank account by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="amount"></param>
        public void Deposit(int id, decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Amount must be greater than zero!");
            }

            BankAccount bankAccount = _db.BankAccounts.GetById(id);

            if (bankAccount == null)
            {
                throw new ArgumentNullException("Bank account doesn't exist!!");
            }

            if (bankAccount.IsOpened)
            {
                bankAccount.Balance += amount;
                bankAccount.BonusPoints += CalculateBonusPoints(bankAccount.Type, amount);
                _db.BankAccounts.Update(bankAccount);
            }
        }

        /// <summary>
        /// Get bank account by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BankAccountDTO Get(int id)
        {
            BankAccount bankAccount = _db.BankAccounts.GetById(id);

            if (bankAccount == null)
            {
                throw new ArgumentNullException("Bank account doesn't exist!!");
            }

            BankAccountDTO bankAccountDTO = CustomMapper<BankAccount, BankAccountDTO>.Map(bankAccount); ////new BankAccountDTO

            return bankAccountDTO;
        }

        /// <summary>
        /// Get all bank accounts
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BankAccountDTO> GetAll()
        {
            IEnumerable<BankAccount> bankAccounts = _db.BankAccounts.GetAll();
            IEnumerable<BankAccountDTO> bankAccountsDTO = CustomMapper<BankAccount, BankAccountDTO>.Map(bankAccounts);

            return bankAccountsDTO;
        }

        /// <summary>
        /// Withdraw amount of money from a bank account by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="amount"></param>
        public void Withdraw(int id, decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Amount must be greater than zero!");
            }

            BankAccount bankAccount = _db.BankAccounts.GetById(id);

            if (bankAccount == null)
            {
                throw new ArgumentNullException("Bank account doesn't exist!!");
            }

            if (bankAccount.IsOpened)
            {
                if (bankAccount.Balance - amount >= 0)
                {
                    bankAccount.Balance -= amount;
                    int bonusPoints = CalculateBonusPoints(bankAccount.Type, amount);

                    if (bankAccount.BonusPoints - bonusPoints < 0)
                    {
                        bankAccount.BonusPoints = 0;
                    }
                    else
                    {
                        bankAccount.BonusPoints -= bonusPoints;
                    }

                    _db.BankAccounts.Update(bankAccount);
                }
            }
        }

        /// <summary>
        /// Calculate bonus points system
        /// </summary>
        /// <param name="accountType"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        private int CalculateBonusPoints(AccountType accountType, decimal amount)
        {
            int result = 0;

            switch (accountType)
            {
                case AccountType.Base:
                    {
                        result = (int)(amount * 0.05m);
                        break;
                    }

                case AccountType.Gold:
                    {
                        result = (int)(amount * 0.1m);
                        break;
                    }

                case AccountType.Platinum:
                    {
                        result = (int)(amount * 0.15m);
                        break;
                    }

                default:
                    break;
            }

            return result;
        }
    }
}
