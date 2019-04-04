using System;
using System.Collections.Generic;

namespace Books.WebApp.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(string id);
        T Find(Func<T, bool> filter);
        void Create(T item);
        void Update(T item);
        void Delete(string id);
    }
}
