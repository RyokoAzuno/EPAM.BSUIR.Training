using System.Collections.Generic;

namespace BooksApp.Interfaces
{
    public interface IStorage<T> where T: class
    {
        void Save();
        IEnumerable<T> Load();
    }
}
