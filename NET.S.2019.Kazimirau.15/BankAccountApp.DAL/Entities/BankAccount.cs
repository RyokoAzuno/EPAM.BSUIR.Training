using BankAccountApp.DAL.Interfaces;

namespace BankAccountApp.DAL.Entities
{
    /// <summary>
    /// Represents bank account's type
    /// </summary>
    public enum AccountType
    {
        Base,
        Gold,
        Platinum
    }

    /// <summary>
    /// Bank account class
    /// </summary>
    public class BankAccount : IEntity
    {
        // Unique identifier
        public int Id { get; set; }

        // Bank account owner's first name
        public string FirstName { get; set; }

        // Bank account owner's second name
        public string SecondName { get; set; }

        // Current amount of money
        public decimal Balance { get; set; }

        // Bonus points
        public int BonusPoints { get; set; }

        // Bank account type
        public AccountType Type { get; set; }

        // Bank account status
        public bool IsOpened { get; set; }
    }
}
