using BankAccountApp.DAL.Entities;
using System.Data.Entity;

namespace BankAccountApp.DAL.EFContexts
{
    public class BankAccountContext : DbContext
    {
        public BankAccountContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<BankAccountContext>());
        }

        public DbSet<BankAccount> BankAccounts { get; set; }
    }
}
