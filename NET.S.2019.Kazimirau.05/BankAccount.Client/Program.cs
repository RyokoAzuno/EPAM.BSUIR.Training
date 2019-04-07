using System;

namespace BankAccount.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount acc1 = new BankAccount("Jane Doe", 200.50m, 20, AccountType.Gold);
            BankAccount acc2 = new BankAccount("John Doe", 1500.50m, 50, AccountType.Platinum);

            Console.WriteLine(acc1);
            Console.WriteLine();
            Console.WriteLine(acc2);
        }
    }
}
