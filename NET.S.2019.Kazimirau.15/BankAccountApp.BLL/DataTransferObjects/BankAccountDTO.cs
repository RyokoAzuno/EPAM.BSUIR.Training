using BankAccountApp.DAL.Interfaces;

namespace BankAccountApp.BLL.DataTransferObjects
{
    public enum AccountTypeDTO
    {
        Base,
        Gold,
        Platinum
    }

    /// <summary>
    /// Data transfer object class
    /// </summary>
    public class BankAccountDTO : IEntity
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
        public AccountTypeDTO Type { get; set; }

        // Bank account status
        public bool IsOpened { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}\nOwner: {FirstName} {SecondName}\nBalance: {Balance}\nPoints: {BonusPoints}\nType: {Type}\nStatus: {IsOpened}";
        }
    }
}
