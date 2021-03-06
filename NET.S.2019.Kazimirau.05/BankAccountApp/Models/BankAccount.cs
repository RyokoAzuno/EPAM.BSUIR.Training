﻿using System;

namespace BankAccountApp.Models
{
    /// <summary>
    /// Represents bank account's type
    /// </summary>
    public enum AccountType
    {
        Base = 5,
        Gold = 10,
        Platinum = 15
    }

    /// <summary>
    /// Simple class which represents a bank account and operations with it
    /// </summary>
    public class BankAccount
    {
        // Default constructor
        public BankAccount()
        {
        }

        // Constructor with arguments
        public BankAccount(string owner, decimal balance, int points, AccountType accType, bool isOpened)
        {
            Id = this.GetHashCode();
            Owner = owner;
            Balance = balance;
            Points = points;
            Type = accType;
            IsOpened = isOpened;
        }

        // Unique identifier
        public int Id { get; set; }

        // Owner of the bank account
        public string Owner { get; set; }

        // Current amount of money
        public decimal Balance { get; set; }

        // Bonus points
        public int Points { get; set; }

        // Bank account type
        public AccountType Type { get; set; }

        // Bank account status
        public bool IsOpened { get; set; }

        /// <summary>
        /// Add amount of money to bank account
        /// </summary>
        /// <param name="amount"> Amount of money to add </param>
        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Amount must be greater than zero!");
            }

            if (IsOpened)
            {
                Balance += amount;
                switch (Type)
                {
                    case AccountType.Base:
                        {
                            Points += (int)Type;
                            break;
                        }

                    case AccountType.Gold:
                        {
                            Points += (int)Type;
                            break;
                        }

                    case AccountType.Platinum:
                        {
                            Points += (int)Type;
                            break;
                        }

                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Withdraw amount of money from bank account
        /// </summary>
        /// <param name="amount"> Amount of money to withdraw </param>
        public void Withdraw(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Amount must be greater than zero!");
            }

            if (IsOpened)
            {
                if (Balance - amount >= 0)
                {
                    Balance -= amount;
                    switch (Type)
                    {
                        case AccountType.Base:
                            {
                                Points -= (int)Type / 2;
                                break;
                            }

                        case AccountType.Gold:
                            {
                                Points -= (int)Type / 2;
                                break;
                            }

                        case AccountType.Platinum:
                            {
                                Points -= (int)Type / 3;
                                break;
                            }

                        default:
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Close a bank account
        /// </summary>
        public void Close()
        {
            IsOpened = false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Represents a bank object as a string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Id: {Id}\nOwner: {Owner}\nBalance: {Balance}\nPoints: {Points}\nType: {Type}\nStatus: {IsOpened}";
        }
    }
}
