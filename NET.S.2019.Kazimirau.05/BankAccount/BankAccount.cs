using System;

namespace BankAccount
{
    /// <summary>
    /// Represent a type of bank account
    /// </summary>
    public enum AccountType { Base, Gold, Platinum }

    /// <summary>
    /// Simle class which represents a bank account and operations with it
    /// </summary>
    public class BankAccount
    {
        public int Id { get; set; }
        public string Owner { get; set; }
        public decimal Balance { get; set; }
        public int Points { get; set; }
        public AccountType Type { get; set; }
        private bool _isOpened;

        // Constructor
        public BankAccount(string owner, decimal balance, int points, AccountType accType)
        {
            Id = base.GetHashCode();
            Owner = owner;
            Balance = balance;
            Points = points;
            Type = accType;
            _isOpened = true;
        }

        /// <summary>
        /// Add amount of money to bank account
        /// </summary>
        /// <param name="amount"> Amount of money to add </param>
        public void Deposit(decimal amount)
        {
            if (amount < 0)
                throw new ArgumentException("Amount must be greater than zero!");

            if (_isOpened)
            {
                Balance += amount;
                switch (Type)
                {
                    case AccountType.Base: Points += 5; break;
                    case AccountType.Gold: Points += 10; break;
                    case AccountType.Platinum: Points += 15; break;
                    default: break;
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
                throw new ArgumentException("Amount must be greater than zero!");

            if (_isOpened)
            {
                if (Balance - amount >= 0)
                {
                    Balance -= amount;
                    switch (Type)
                    {
                        case AccountType.Base: Points -= 2; break;
                        case AccountType.Gold: Points -= 4; break;
                        case AccountType.Platinum: Points -= 5; break;
                        default: break;
                    }
                }
            }
        }

        /// <summary>
        /// Close a bank account
        /// </summary>
        public void Close()
        {
            _isOpened = false;
        }

        /// <summary>
        /// Reperesent a bank object as a string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Id: {Id}\nOwner: {Owner}\nBalance: {Balance}\nPoints: {Points}\nType: {Type}";
        }
    }
}
