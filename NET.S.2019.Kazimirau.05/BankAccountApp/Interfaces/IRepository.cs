using System.Collections.Generic;

namespace BankAccountApp.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        T GetById(int id);

        void Add(T entity);

        void Remove(int id);
    }
}
