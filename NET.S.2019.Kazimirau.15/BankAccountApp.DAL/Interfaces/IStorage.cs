using System.Collections.Generic;

namespace BankAccountApp.DAL.Interfaces
{
    public interface IStorage<T> where T : class
    {
        void Save();

        IEnumerable<T> Load();
    }
}
