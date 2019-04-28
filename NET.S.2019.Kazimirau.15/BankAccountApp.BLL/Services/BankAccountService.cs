using BankAccountApp.BLL.DataTransferObjects;
using BankAccountApp.BLL.Interfaces;
using BankAccountApp.DAL.Entities;
using BankAccountApp.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace BankAccountApp.BLL.Services
{
    public class BankAccountService : IBankAccountService
    {
        private IUnitOfWork _db;

        public BankAccountService(IUnitOfWork unitOfWork)
        {
            _db = unitOfWork;
        }

        public void Close(int id)
        {
            _db.BankAccounts.GetById(id).IsOpened = false;
            _db.Commit();
        }

        public void CreateNew(BankAccountDTO bankAccountDTO)
        {
            if(bankAccountDTO == null)
            {
                throw new ArgumentNullException("Bank account can't be null!!");
            }

            BankAccount bankAccount = new BankAccount
            {
                Id = bankAccountDTO.Id,
                FirstName = bankAccountDTO.FirstName,
                SecondName = bankAccountDTO.SecondName,
                Balance = bankAccountDTO.Balance,
                BonusPoints = bankAccountDTO.BonusPoints,
                Type = (AccountType)bankAccountDTO.Type,
                IsOpened = bankAccountDTO.IsOpened 
            };

            _db.BankAccounts.Create(bankAccount);
            _db.Commit();
        }

        public void Deposit(int id, decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Amount must be greater than zero!");
            }

            BankAccount bankAccount = _db.BankAccounts.GetById(id);

            if(bankAccount == null)
            {
                throw new ArgumentNullException("Bank account doesn't exist!!");
            }


            if (bankAccount.IsOpened)
            {
                bankAccount.Balance += amount;
                switch (bankAccount.Type)
                {
                    case AccountType.Base:
                        {
                            bankAccount.BonusPoints += (int)bankAccount.Type;
                            break;
                        }

                    case AccountType.Gold:
                        {
                            bankAccount.BonusPoints += (int)bankAccount.Type;
                            break;
                        }

                    case AccountType.Platinum:
                        {
                            bankAccount.BonusPoints += (int)bankAccount.Type;
                            break;
                        }

                    default:
                        break;
                }
            }

            _db.Commit();
        }

        public BankAccountDTO Show(int id)
        {
            BankAccount bankAccount = _db.BankAccounts.GetById(id);

            if (bankAccount == null)
            {
                throw new ArgumentNullException("Bank account doesn't exist!!");
            }

            BankAccountDTO bankAccountDTO = new BankAccountDTO
            {
                Id = bankAccount.Id,
                FirstName = bankAccount.FirstName,
                SecondName = bankAccount.SecondName,
                Balance = bankAccount.Balance,
                BonusPoints = bankAccount.BonusPoints,
                Type = (AccountTypeDTO)bankAccount.Type,
                IsOpened = bankAccount.IsOpened
            };

            return bankAccountDTO;
        }

        public IEnumerable<BankAccountDTO> ShowAll()
        {
            IEnumerable<BankAccount> bankAccounts = _db.BankAccounts.GetAll();
            List<BankAccountDTO> bankAccountsDTO = new List<BankAccountDTO>();
            IEnumerator<BankAccount> enumerator = bankAccounts.GetEnumerator();

            while(enumerator.MoveNext())
            {
                bankAccountsDTO.Add(new BankAccountDTO {
                    Id = enumerator.Current.Id,
                    FirstName = enumerator.Current.FirstName,
                    SecondName = enumerator.Current.SecondName,
                    Balance = enumerator.Current.Balance,
                    BonusPoints = enumerator.Current.BonusPoints,
                    Type = (AccountTypeDTO)enumerator.Current.Type,
                    IsOpened = enumerator.Current.IsOpened
                });
            }

            return bankAccountsDTO;
        }

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
                    switch (bankAccount.Type)
                    {
                        case AccountType.Base:
                            {
                                bankAccount.BonusPoints -= (int)bankAccount.Type / 2;
                                break;
                            }

                        case AccountType.Gold:
                            {
                                bankAccount.BonusPoints -= (int)bankAccount.Type / 2;
                                break;
                            }

                        case AccountType.Platinum:
                            {
                                bankAccount.BonusPoints -= (int)bankAccount.Type / 3;
                                break;
                            }

                        default:
                            break;
                    }
                }
            }

            _db.Commit();
        }
    }
}
