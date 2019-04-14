using System.Collections.Generic;

namespace BooksApp.Interfaces
{
    public interface IRepository<T> where T : class, IEntity
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T newEntity);
        void Update(T entity);
        void Remove(int id);
        void Sort(IComparer<T> comparer);
        T FindByFieldValue(string fieldValue);
    }
}
