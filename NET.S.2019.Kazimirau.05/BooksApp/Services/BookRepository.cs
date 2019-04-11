using BooksApp.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BooksApp.Services
{
    public class BookRepository : IRepository<Book>
    {
        private BookStorage _db;

        public BookRepository()
        {
            _db = new BookStorage();
        }

        /// <summary>
        /// Add new book into BookStorage
        /// </summary>
        /// <param name="book"> Book to add </param>
        public void Add(Book newEntity)
        {
            if (newEntity != null)
            {
                var results = new List<ValidationResult>();
                var context = new ValidationContext(newEntity);
                if (!Validator.TryValidateObject(newEntity, context, results, true))
                {
                    foreach (var error in results)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }
                else
                {
                    if (!_db.Books.Contains(newEntity))
                        _db.Add(newEntity);
                    else
                        throw new ArgumentException("Duplicated book!");
                }
            }
        }

        /// <summary>
        /// Find a book by using a special filter(pridicate)
        /// </summary>
        /// <param name="filter"> Filter(pridicate) to find a book </param>
        /// <returns> Book from BookStorage </returns>
        public IEnumerable<Book> Find(Func<Book, bool> predicate)
        {
            return _db.Books.Where(predicate);
        }

        /// <summary>
        /// Get all books from BookStorage
        /// </summary>
        /// <returns> Collection of books </returns>
        public IEnumerable<Book> GetAll()
        {
            return _db.Books;
        }

        /// <summary>
        /// Get a book by Id
        /// </summary>
        /// <param name="id"> Id </param>
        /// <returns> Book from BookStorage </returns>
        public Book GetById(int id)
        {
            Book book = _db.Books.Where(b => b.Id.Equals(id)).FirstOrDefault();
            if (book == null)
                throw new NullReferenceException("There is no such book in the BookStorage!");

            return book;
        }
        /// <summary>
        /// Update(edit) a book
        /// </summary>
        /// <param name="book"> Book to update </param>
        public void Update(Book book)
        {
            _db.Update(book);
            //if (book != null)
            //{
            //    var results = new List<ValidationResult>();
            //    var context = new ValidationContext(book);
            //    if (!Validator.TryValidateObject(book, context, results, true))
            //    {
            //        foreach (var error in results)
            //        {
            //            Console.WriteLine(error.ErrorMessage);
            //        }
            //    }
            //    else
            //    {
            //        Book b = GetById(book.Id);
            //        _db.Remove(b);
            //        b.Name = book.Name;
            //        b.NumberOfPages = book.NumberOfPages;
            //        b.Publisher = book.Publisher;
            //        b.Year = book.Year;
            //        b.Price = book.Price;
            //        b.Author = book.Author;
            //        _db.Add(b);
            //    }
            //}
        }

        /// <summary>
        /// Remove a book with a given id from BookStorage
        /// </summary>
        /// <param name="id"> Id </param>
        public void Remove(int id)
        {
            Book book = GetById(id);
            if (book != null)
                _db.Remove(book);
            else
                throw new ArgumentException("There is no such book in the BookStorage!");
        }

        public void Sort(IComparer<Book> comparer)
        {
            _db.SortByTag(comparer);
        }

        public Book FindByFieldValue(string fieldValue)
        {
            foreach (var item in GetAll())
            {
                if (fieldValue.Equals(item.ISBN) || fieldValue.Equals(item.Name) || fieldValue.Equals(item.Author) || fieldValue.Equals(item.Publisher))
                    return item;
            }
            return null;
        }

        public override string ToString()
        {
            return _db.ToString();
        }
    }
}
