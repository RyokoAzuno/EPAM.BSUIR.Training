﻿using BankAccountApp.BLL.DataTransferObjects;
using BankAccountApp.BLL.Interfaces;
using BankAccountApp.CCL.Mappers;
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

            BankAccount bankAccount = CustomMapper<BankAccountDTO, BankAccount>.Map(bankAccountDTO);//new BankAccount

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

            BankAccountDTO bankAccountDTO = CustomMapper<BankAccount, BankAccountDTO>.Map(bankAccount);//new BankAccountDTO

            return bankAccountDTO;
        }

        public IEnumerable<BankAccountDTO> ShowAll()
        {
            IEnumerable<BankAccount> bankAccounts = _db.BankAccounts.GetAll();
            IEnumerable<BankAccountDTO> bankAccountsDTO = CustomMapper<BankAccount, BankAccountDTO>.Map(bankAccounts);

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
