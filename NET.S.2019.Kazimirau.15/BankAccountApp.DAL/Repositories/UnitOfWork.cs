using BankAccountApp.DAL.Entities;
using BankAccountApp.DAL.Interfaces;

namespace BankAccountApp.DAL.Repositories
{
    /// <summary>
    /// Class represents a compositing root that pass data to BLL layer
    /// Class-keeper for repositories
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private IRepository<BankAccount> _bankAccountRepository;
        //private IStorage<BankAccount> _bankAccountStorage;

        public UnitOfWork(IRepository<BankAccount> bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
        }

        public IRepository<BankAccount> BankAccounts
        {
            get
            {
                //if (_bankAccountRepository == null)
                //{
                //    _bankAccountRepository = new BankAccountRepository(_bankAccountStorage);
                //}

                return _bankAccountRepository;
            }
        }
    }
}
