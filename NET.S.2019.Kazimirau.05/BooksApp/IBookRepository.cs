using System;
using System.Collections.Generic;

namespace BooksApp
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAll();
        Book GetById(string id);
        Book Find(Func<Book, bool> filter);
        void Create(Book item);
        void Update(Book item);
        void Delete(string id);
    }
}
