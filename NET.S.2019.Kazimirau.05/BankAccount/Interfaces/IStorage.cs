using System.Collections.Generic;

namespace BankAccount.Interfaces
{
    public interface IStorage<T> where T: class
    {
        void Save();
        IEnumerable<T> Load();
    }
}
