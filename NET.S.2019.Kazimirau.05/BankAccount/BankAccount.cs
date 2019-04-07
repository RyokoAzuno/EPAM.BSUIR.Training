namespace BankAccount
{
    public enum AccountType { Base, Gold, Platinum }

    public class BankAccount
    {
        public int Id { get; set; }
        public string Owner { get; set; }
        public decimal Balance { get; set; }
        public int Points { get; set; }
        public AccountType Type { get; set; }

        public BankAccount(string owner, decimal balance, int points, AccountType accType)
        {
            Id = base.GetHashCode();
            Owner = owner;
            Balance = balance;
            Points = points;
            Type = accType; 
        }

        public void Deposit(decimal amount)
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

        public void Withdraw(decimal amount)
        {
            if(Balance - amount >= 0)
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

        public void Close()
        {

        }
    }
}
