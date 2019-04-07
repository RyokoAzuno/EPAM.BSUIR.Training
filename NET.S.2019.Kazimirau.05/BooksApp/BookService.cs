using System;
using System.Collections.Generic;
using System.Linq;

namespace BooksApp
{
    public class BookService : IBookRepository
    {
        private BooksStorage _db;
        byte[] _booksInBytes;

        public BookService()
        {
            _db = new BooksStorage();
            _booksInBytes = _db.Serialize();
        }

        public Book this[int index]
        {
            get { return _db[index]; }
            set { _db[index] = value; }
        }

        public void Create(Book book)
        {
            if (book != null)
            {
                if (!_db.Books.Contains(book))
                    _db.Books.Add(book);
                else
                    throw new ArgumentException("The book is in the BooksStorage!");
            }
        }

        public void Delete(string isbn)
        {
            Book book = GetById(isbn);
            if (book != null)
                _db.Books.Remove(book);
            else
                throw new ArgumentException("There is no such book in the BooksStorage!");
        }

        public Book Find(Func<Book, bool> filter)
        {
            return _db.Books.Where(filter).FirstOrDefault();
        }

        public Book FindBookByTag(string tag)
        {
            foreach (var item in _db.Books)
            {
                if (tag.Equals(item.ISBN) || tag.Equals(item.Name) || tag.Equals(item.Author) || tag.Equals(item.Publisher))
                    return item;
            }
            return null;
        }

        public IEnumerable<Book> GetAll()
        {
            return _db.Books;
        }

        public Book GetById(string isbn)
        {
            return _db.Books.Where(b => b.ISBN.Equals(isbn)).FirstOrDefault();
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

        public byte[] StoreBooksInMemory()
        {
            return _booksInBytes;
        }

        public IEnumerable<Book> RestoreBooksFromMemory()
        {
            return _db.Deserialize(_booksInBytes);
        }

        public void SortByTag(IComparer<Book> tag)
        {
            _db.SortByTag(tag);
        }

        public override string ToString()
        {
            return _db.ToString();
        }
    }
}