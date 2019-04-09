using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace BooksApp
{
    public class BookService : IBookRepository
    {
        private BooksStorage _db;
        private byte[] _booksInBytes;
        private string _relativePath;

        // Constructor
        public BookService()
        {
            _db = new BooksStorage();
            _booksInBytes = _db.SerializeToBytes();
            // Get relative path to save our xml file.
            // Environment.CurrentDirectory - current working directory (i.e. \bin\Debug)
            // This will get the current PROJECT directory
            _relativePath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName; //AppDomain.CurrentDomain.BaseDirectory;
        }
        // Get object by index
        public Book this[int index]
        {
            get { return _db[index]; }
            set { _db[index] = value; }
        }
        /// <summary>
        /// Add new book into BooksStorage
        /// </summary>
        /// <param name="book"> Book to add </param>
        public void Create(Book book)
        {
            if (book != null)
            {
                var results = new List<ValidationResult>();
                var context = new ValidationContext(book);
                if (!Validator.TryValidateObject(book, context, results, true))
                {
                    foreach (var error in results)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }
                else
                {
                    if (!_db.Books.Contains(book))
                        _db.Add(book);
                    else
                        throw new ArgumentException("Duplicated book!");
                }
            }
        }
        /// <summary>
        /// Remove a book with a given isbn from BooksStorage
        /// </summary>
        /// <param name="isbn"> ISBN </param>
        public void Delete(string isbn)
        {
            Book book = GetById(isbn);
            if (book != null)
                _db.Remove(book);
            else
                throw new ArgumentException("There is no such book in the BooksStorage!");
        }
        /// <summary>
        /// Find a book by using a special filter(pridicate)
        /// </summary>
        /// <param name="filter"> Filter(pridicate) to find a book </param>
        /// <returns> Book from BooksStorage </returns>
        public Book Find(Func<Book, bool> filter)
        {
            return _db.Books.Where(filter).FirstOrDefault();
        }
        // Find a book by tag-name
        public Book FindBookByTag(string tag)
        {
            foreach (var item in _db.Books)
            {
                if (tag.Equals(item.ISBN) || tag.Equals(item.Name) || tag.Equals(item.Author) || tag.Equals(item.Publisher))
                    return item;
            }
            return null;
        }
        /// <summary>
        /// Get all books from BooksStorage
        /// </summary>
        /// <returns> Add books </returns>
        public IEnumerable<Book> GetAll()
        {
            return _db.Books;
        }
        /// <summary>
        /// Get a book by ISBN
        /// </summary>
        /// <param name="isbn"> ISBN </param>
        /// <returns> Book from BooksStorage </returns>
        public Book GetById(string isbn)
        {
            Book book = _db.Books.Where(b => b.ISBN.Equals(isbn)).FirstOrDefault();
            if (book == null)
                throw new NullReferenceException();

            return book;
        }
        /// <summary>
        /// Update(edit) given book
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
                        Console.WriteLine(error.ErrorMessage);
                    }
                }
                else
                {
                    Book b = GetById(book.ISBN);
                    _db.Remove(b);
                    b.Name = book.Name;
                    b.NumberOfPages = book.NumberOfPages;
                    b.Publisher = book.Publisher;
                    b.Year = book.Year;
                    b.Price = book.Price;
                    b.Author = book.Author;
                    _db.Update(b);
                }
            }
        }

        /// <summary>
        /// Save all books to Xml file
        /// </summary>
        public void ToXML()
        {
            // Constuct Xml structure
            var xEle = new XElement("Books",
                        from book in _db.Books
                        select new XElement("Book",
                            new XAttribute("ISBN", book.ISBN),
                            new XElement("Author", book.Author),
                            new XElement("Name", book.Name),
                            new XElement("Publisher", book.Publisher),
                            new XElement("Year", book.Year),
                            new XElement("Pages", book.NumberOfPages),
                            new XElement("Price", book.Price)
                            ));
            // Save Xml document
            xEle.Save(_relativePath + "\\" + "Books.xml");
        }

        /// <summary>
        /// Save all books to Json file
        /// </summary>
        public void ToJSON()
        {
            // !!!!!!!Encoding to UTF8 for cyrillic symbols!!!!!!!!
            File.WriteAllText(_relativePath + "\\" + "Books.json", JsonConvert.SerializeObject(_db.Books, Formatting.Indented), Encoding.UTF8);
        }

        // Convert list of books into array of bytes
        public byte[] StoreBooksInMemory()
        {
            return _booksInBytes;
        }
        // Restore books from memory
        public IEnumerable<Book> RestoreBooksFromMemory()
        {
            return _db.DeserializeFromBytes(_booksInBytes);
        }

        public void SortByTag(IComparer<Book> tag)
        {
            _db.SortByTag(tag);
        }

        public override string ToString()
        {
            return _db.ToString();
        }

        //private void Validate(Book book)
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
        //}
    }
}