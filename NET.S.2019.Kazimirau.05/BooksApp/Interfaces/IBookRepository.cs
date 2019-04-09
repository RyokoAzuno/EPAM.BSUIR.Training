using System;
using System.Collections.Generic;

namespace BooksApp
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAll();
        Book GetByISBN(string isbn);
        Book Find(Func<Book, bool> filter);
        Book FindBookByTag(string tag);
        void Create(Book book);
        void Update(Book book);
        void Delete(string isbn);
        void SortByTag(IComparer<Book> tag);
    }
}
