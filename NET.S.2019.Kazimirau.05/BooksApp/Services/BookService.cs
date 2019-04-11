using BooksApp.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace BooksApp
{
    // Class represents a service for working with Book objects
    public class BookService : ISerializable
    {
        private readonly IRepository<Book> _bookRepository;
        // Path to AppData folder
        private string _relativePath;

        // Constructor
        public BookService(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
            // Get relative path to save our xml file.
            // Environment.CurrentDirectory - current working directory (i.e. \bin\Debug)
            // This will get the current PROJECT directory
            _relativePath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName; //AppDomain.CurrentDomain.BaseDirectory;
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
        public List<Book> Find(Func<Book, bool> predicate)
        {
            return _bookRepository.Find(predicate).ToList();
        }

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

        /// <summary>
        /// Save all books to Xml file
        /// </summary>
        public void ToXML()
        {
            // Constuct Xml structure
            var xEle = new XElement("Books",
                        from book in _bookRepository.GetAll()
                        select new XElement("Book",
                            new XAttribute("Id", book.Id),
                            new XElement("ISBN", book.ISBN),
                            new XElement("Author", book.Author),
                            new XElement("Name", book.Name),
                            new XElement("Publisher", book.Publisher),
                            new XElement("Year", book.Year),
                            new XElement("Pages", book.NumberOfPages),
                            new XElement("Price", book.Price)
                            ));
            // Save Xml document
            xEle.Save(_relativePath + "\\AppData\\" + "Books.xml");
        }

        /// <summary>
        /// Save all books to Json file
        /// </summary>
        public void ToJSON()
        {
            // !!!!!!!Encoding to UTF8 for cyrillic symbols!!!!!!!!
            File.WriteAllText(_relativePath + "\\AppData\\" + "Books.json", JsonConvert.SerializeObject(_bookRepository.GetAll(), Formatting.Indented), Encoding.UTF8);
        }

        public void SortByTag(IComparer<Book> tag)
        {
            _bookRepository.Sort(tag);
        }

        public override string ToString()
        {
            return _bookRepository.ToString();
        }
    }
}