using System;
using System.Collections.Generic;
using System.Linq;

namespace BooksApp
{
    public class BookService : IBookRepository
    {
        public void Create(Book item)
        {
            if (item != null)
                BooksStorage.Books.Add(item);
        }

        public void Delete(string id)
        {
            Book book = GetById(id);
            if(book != null)
                BooksStorage.Books.Remove(book);
        }

        public Book Find(Func<Book, bool> filter)
        {
            return BooksStorage.Books.Where(filter).FirstOrDefault();
        }

        public IEnumerable<Book> GetAll()
        {
            return BooksStorage.Books;
        }

        public Book GetById(string id)
        {
            return BooksStorage.Books.Where(b => b.ISBN.Equals(id)).FirstOrDefault();
        }

        public void Update(Book item)
        {
            if (item != null)
            {
                Book book = GetById(item.ISBN);
                book.Name = item.Name;
                book.NumberOfPages = item.NumberOfPages;
                book.Publisher = item.Publisher;
                book.Year = item.Year;
                book.Price = item.Price;
                book.Author = item.Author;
            }
        }
    }
}