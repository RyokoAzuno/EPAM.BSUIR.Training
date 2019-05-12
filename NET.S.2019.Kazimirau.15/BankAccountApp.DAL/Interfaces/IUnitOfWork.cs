using BankAccountApp.DAL.Entities;

namespace BankAccountApp.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<BankAccount> BankAccounts { get; }
    }
}
