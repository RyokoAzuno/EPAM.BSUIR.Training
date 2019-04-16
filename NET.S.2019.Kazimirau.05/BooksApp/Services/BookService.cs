using BooksApp.Interfaces;
using BooksApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BooksApp.Services
{
    // Class represents a service for working with Book objects
    public class BookService : IPrintable
    {
        private readonly IRepository<Book> _bookRepository;

        // Constructor
        public BookService(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        /// <summary>
        /// Add new book into BookStorage
        /// </summary>
        /// <param name="book"> Book to add </param>
        public void Create(Book book)
        {
            _bookRepository.Add(book);
        }

        /// <summary>
        /// Remove a book with a given id from BookStorage
        /// </summary>
        /// <param name="id"> Id </param>
        public void Delete(int id)
        {
            _bookRepository.Remove(id);
        }

        /// <summary>
        /// Find a book by using a special filter(pridicate)
        /// </summary>
        /// <param name="filter"> Filter(pridicate) to find a book </param>
        /// <returns> Book from BookStorage </returns>
        //public List<Book> Find(Func<Book, bool> predicate)
        //{
        //    return _bookRepository.Find(predicate).ToList();
        //}

        // Find book by tag-name
        public Book FindBookByTag(string tag)
        {
            return _bookRepository.FindByFieldValue(tag);
        }
        /// <summary>
        /// Get all books from BookStorage
        /// </summary>
        /// <returns> All books from storage </returns>
        public List<Book> GetAll()
        {
            return _bookRepository.GetAll().ToList();
        }

        /// <summary>
        /// Get a book by Id
        /// </summary>
        /// <param name="id"> Id </param>
        /// <returns> Book from BookStorage </returns>
        public Book Get(int id)
        {
            return _bookRepository.GetById(id);
        }
        /// <summary>
        /// Update(edit) given book
        /// </summary>
        /// <param name="book"> Book to update </param>
        public void Update(Book book)
        {
            _bookRepository.Update(book);
        }

        public void SortByTag(IComparer<Book> tag)
        {
            _bookRepository.Sort(tag);
        }

        public void Print()
        {
            Console.WriteLine(_bookRepository.ToString());
        }
    }
}