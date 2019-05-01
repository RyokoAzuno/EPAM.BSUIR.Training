using System.Collections.Generic;

namespace BankAccountApp.Interfaces
{
    public interface IStorage<T> where T : class
    {
        void Save();

        IEnumerable<T> Load();
    }
}
