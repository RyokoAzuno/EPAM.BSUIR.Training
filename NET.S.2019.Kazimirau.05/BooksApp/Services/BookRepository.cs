using BooksApp.Interfaces;
using BooksApp.Loggers;
using BooksApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BooksApp.Services
{
    public class BookRepository : IRepository<Book>
    {
        // Simulated database
        private List<Book> _books;
        private IStorage<Book> _bookStorage;

        public BookRepository(IStorage<Book> bookStorage)
        {
            _bookStorage = bookStorage;
            _books = _bookStorage.Load().ToList();
        }

        /// <summary>
        /// Add new book into BookStorage
        /// </summary>
        /// <param name="book"> Book to add </param>
        public void Add(Book book)
        {
            if (book != null)
            {
                var results = new List<ValidationResult>();
                var context = new ValidationContext(book);
                if (!Validator.TryValidateObject(book, context, results, true))
                {
                    foreach (var error in results)
                    {
                        MyLogger.GetLogger().Info(error.ErrorMessage);
                    }
                }
                else
                {
                    if (!_books.Contains(book))
                    {
                        int id = _books.Max(b => b.Id) + 1;
                        book.Id = id;
                        _books.Add(book);
                        _bookStorage.Save();
                    }
                    else
                    {
                        MyLogger.GetLogger().Info("Duplicated book!");
                        throw new ArgumentException("Duplicated book!");
                    }
                }
            }
        }

        /// <summary>
        /// Get all books from BookStorage
        /// </summary>
        /// <returns> Collection of books </returns>
        public IEnumerable<Book> GetAll()
        {
            return _books;
        }

        /// <summary>
        /// Get a book by Id
        /// </summary>
        /// <param name="id"> Id </param>
        /// <returns> Book from BookStorage </returns>
        public Book GetById(int id)
        {
            Book book = _books.Where(b => b.Id.Equals(id)).FirstOrDefault();

            if (book == null)
            {
                MyLogger.GetLogger().Info("There is no such book in the BookStorage!");
                throw new NullReferenceException("There is no such book in the BookStorage!");
            }

            return book;
        }
        /// <summary>
        /// Update(edit) a book
        /// </summary>
        /// <param name="book"> Book to update </param>
        public void Update(Book book)
        {
            if (book != null)
            {
                var results = new List<ValidationResult>();
                var context = new ValidationContext(book);
                if (!Validator.TryValidateObject(book, context, results, true))
                {
                    foreach (var error in results)
                    {
                        MyLogger.GetLogger().Info(error.ErrorMessage);
                    }
                }
                else
                {
                    Book b = GetById(book.Id);

                    if (b != null)
                    {
                        b.ISBN = book.ISBN;
                        b.Author = book.Author;
                        b.Name = book.Name;
                        b.Publisher = book.Publisher;
                        b.Year = book.Year;
                        b.NumberOfPages = book.NumberOfPages;
                        b.Price = book.Price;
                        _bookStorage.Save();
                    }
                }
            }
        }

        /// <summary>
        /// Remove a book with a given id from BookStorage
        /// </summary>
        /// <param name="id"> Id </param>
        public void Remove(int id)
        {
            Book book = GetById(id);
            if (book != null)
            {
                _books.Remove(book);
                _bookStorage.Save();
            }
            else
            {
                MyLogger.GetLogger().Info("There is no such book in the BookStorage!");
                throw new ArgumentException("There is no such book in the BookStorage!");
            }
        }

        // Sort books via comparer
        public void Sort(IComparer<Book> comparer)
        {
            _books.Sort(comparer);
            _bookStorage.Save();
        }

        // Find a value of the string field
        public Book FindByFieldValue(string fieldValue)
        {
            foreach (var item in GetAll())
            {
                if (fieldValue.Equals(item.ISBN) || fieldValue.Equals(item.Name) || fieldValue.Equals(item.Author) || fieldValue.Equals(item.Publisher))
                    return item;
            }
            return null;
        }

        // Overriding ToString() method
        public override string ToString()
        {
            string result = string.Empty;
            foreach (var book in _books)
            {
                result += $"***\n{book.ToString()}\n";
            }
            return result;
        }
    }
}
