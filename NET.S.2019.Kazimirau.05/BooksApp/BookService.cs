using System;
using System.Collections.Generic;
using System.Linq;

namespace BooksApp
{
    public class BookService : IBookRepository
    {
        public void Create(Book book)
        {
            if (book != null)
            {
                if (!BooksStorage.Books.Contains(book))
                    BooksStorage.Books.Add(book);
                else
                    throw new ArgumentException("The book is in the BooksStorage!");
            }
        }

        public void Delete(string isbn)
        {
            Book book = GetById(isbn);
            if (book != null)
                BooksStorage.Books.Remove(book);
            else
                throw new ArgumentException("There is no such book in the BooksStorage!");
        }

        public Book Find(Func<Book, bool> filter)
        {
            return BooksStorage.Books.Where(filter).FirstOrDefault();
        }

        public Book FindBookByTag(string tag)
        {
            foreach (var item in BooksStorage.Books)
            {
                if (tag.Equals(item.ISBN) || tag.Equals(item.Name) || tag.Equals(item.Author) || tag.Equals(item.Publisher))
                    return item;
            }
            return null;
        }

        public IEnumerable<Book> GetAll()
        {
            return BooksStorage.Books;
        }

        public Book GetById(string isbn)
        {
            return BooksStorage.Books.Where(b => b.ISBN.Equals(isbn)).FirstOrDefault();
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