using BooksApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BooksApp.Storages
{
    // Simple class that emulates book storage database
    public sealed class BookStorage
    {
        // Path to working directory
        private readonly string _fullPath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\AppData\\" + "BooksDB";
        // List of books that emulates database
        private List<Book> _books = new List<Book> {
            new Book{Id = 0, ISBN = "1-61-729453-5", Author = "Jon Skeet", Name = "C# in Depth", NumberOfPages = 528, Price = 43m, Publisher = "Manning Publications", Year = 2019 },
            new Book{Id = 1, ISBN = "9-78-149198-6", Author = "Joseph Albahari", Name = "C# 7.0 in a Nutshell", NumberOfPages = 1088, Price = 65m, Publisher = "O'Reilly Media", Year = 2017 },
            new Book{Id = 2, ISBN = "1-48-423017-5", Author = "Andrew Troelsen, Phil Japikse", Name = "Pro C# 7: With .NET and .NET Core", NumberOfPages = 1372, Price = 32.82m, Publisher = "Apress", Year = 2017 },
            new Book{Id = 3, ISBN = "0-73-566745-4", Author = "Jeffrey Richter", Name = "CLR via C#", NumberOfPages = 896, Price = 49.17m, Publisher = "Microsoft Press", Year = 2012 },
            new Book{Id = 4, ISBN = "9-78-026203-8", Author = "Thomas Cormen, Ronals Rivest", Name = "Introduction to Algorithms", NumberOfPages = 1320, Price = 87.67m, Publisher = "The MIT Press", Year = 2009 },
            new Book{Id = 5, ISBN = "9-78-032157-1", Author = "Mario Hewardt", Name = "Advanced .NET Debugging", NumberOfPages = 552, Price = 44.95m, Publisher = "Addison-Wesley Professional", Year = 2008 }
        };

        // Constructor
        public BookStorage()
        {
            if (File.Exists(_fullPath))
                _books = LoadFromBinaryFile();
            else
                SaveToBinaryFile(FileMode.Create, _books);
        }

        /// <summary>
        /// Get all books as List
        /// </summary>
        public List<Book> Books
        {
            get
            {
                List<Book> books = LoadFromBinaryFile();

                return books;
            }
        }

        // Indexer
        public Book this[int index]
        {
            get
            {
                if (index > -1 && index < Books.Count)
                    return Books[index];

                throw new IndexOutOfRangeException();
            }
            set
            {
                if (value != null)
                    Books[index] = value;
            }
        }

        /// <summary>
        /// Add book into BooksStorage
        /// </summary>
        /// <param name="book"> Book to add </param>
        public void Add(Book book)
        {
            if (book != null)
            {
                int id = Books.Max(b => b.Id) + 1;
                book.Id = id;

                using (FileStream stream = new FileStream(_fullPath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                {
                    using (BinaryWriter binaryWriter = new BinaryWriter(stream))
                    {
                        //binaryWriter.BaseStream.Seek(0, SeekOrigin.End);
                        WriteToStream(binaryWriter, book);
                    }
                }
            }
        }

        /// <summary>
        /// Remove book from storage
        /// </summary>
        /// <param name="book"> Book to remove </param>
        public void Remove(Book book)
        {
            if (book != null)
            {
                List<Book> books = Books;
                books.Remove(book);
                SaveToBinaryFile(FileMode.Create, books);
            }
        }

        /// <summary>
        /// Update book from storage
        /// </summary>
        /// <param name="book"> Book to update </param>
        public void Update(Book book)
        {
            if(book != null)
            {
                List<Book> books = Books;
                Book b = books.Where(item => item.Id == book.Id).FirstOrDefault();
                if(b != null)
                {
                    b.ISBN = book.ISBN;
                    b.Author = book.Author;
                    b.Name = book.Name;
                    b.Publisher = book.Publisher;
                    b.Year = book.Year;
                    b.NumberOfPages = book.NumberOfPages;
                    b.Price = book.Price;
                    SaveToBinaryFile(FileMode.Create, books);
                }
            }
        }

        // Sort books
        public void SortByTag(IComparer<Book> tag)
        {
            List<Book> books = Books;
            books.Sort(tag);
            SaveToBinaryFile(FileMode.Create, books);
        }

        // Represent a BookStorage object as a string 
        public override string ToString()
        {
            string result = string.Empty;
            foreach (var book in Books)
            {
                result += $"{book.ToString()}";
            }

            return result;
        }

        /// <summary>
        /// Serialize books in memory as array of bytes
        /// </summary>
        /// <returns></returns>
        public byte[] SerializeToBytes()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(stream))
                {
                    foreach (var book in Books)
                    {
                        WriteToStream(binaryWriter, book);
                    }
                }
                //stream.Flush();
                return stream.GetBuffer();
            }
        }

        /// <summary>
        /// Deserialize bytes as List of books
        /// </summary>
        /// <param name="bytes"> Books as array of bytes</param>
        /// <returns> List of books </returns>
        public List<Book> DeserializeFromBytes(byte[] bytes)
        {
            List<Book> books = new List<Book>();
            using (MemoryStream stream = new MemoryStream(bytes))
            {
                using (BinaryReader binaryReader = new BinaryReader(stream))
                {
                    // Read each value while not EOF
                    while (binaryReader.PeekChar() != 0)
                    {
                        books.Add(ReadFromStream(binaryReader));
                    }
                }
            }

            return books;
        }

        // Write book as array of bytes to stream
        private void WriteToStream(BinaryWriter binaryWriter, Book book)
        {
            if (book != null && binaryWriter != null)
            {
                binaryWriter.Write(book.Id);
                binaryWriter.Write(book.ISBN);
                binaryWriter.Write(book.Author);
                binaryWriter.Write(book.Name);
                binaryWriter.Write(book.Publisher);
                binaryWriter.Write(book.Year);
                binaryWriter.Write(book.NumberOfPages);
                binaryWriter.Write(book.Price);
            }
            else
                throw new ArgumentNullException();
        }

        // Read all bytes from stream as Book
        private Book ReadFromStream(BinaryReader binaryReader)
        {
            if (binaryReader != null)
            {
                int id = binaryReader.ReadInt32();
                string isbn = binaryReader.ReadString();
                string author = binaryReader.ReadString();
                string name = binaryReader.ReadString();
                string publisher = binaryReader.ReadString();
                int year = binaryReader.ReadInt32();
                int numberOfPages = binaryReader.ReadInt32();
                decimal price = binaryReader.ReadDecimal();
                return new Book { Id = id, ISBN = isbn, Author = author, Name = name, Publisher = publisher, Year = year, NumberOfPages = numberOfPages, Price = price };
            }
            else
                throw new ArgumentNullException();
        }
        /// <summary>
        /// Save List of books to binary file
        /// </summary>
        /// <param name="fileMode"> File mode </param>
        /// <param name="books"> Books to save </param>
        private void SaveToBinaryFile(FileMode fileMode, List<Book> books)
        {
            using (FileStream stream = new FileStream(_fullPath, fileMode, FileAccess.Write, FileShare.ReadWrite))
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(stream))
                {
                    foreach (var item in books)
                    {
                        WriteToStream(binaryWriter, item);
                    }
                }
            }
        }
        /// <summary>
        /// Load books from binary file 
        /// </summary>
        /// <returns> List of books </returns>
        private List<Book> LoadFromBinaryFile()
        {
            List<Book> books = new List<Book>();
            using (FileStream stream = new FileStream(_fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (BinaryReader binaryReader = new BinaryReader(stream))
                {
                    binaryReader.BaseStream.Seek(0, SeekOrigin.Begin);
                    // Read each value while not EOF
                    while (binaryReader.PeekChar() != -1) // for FileStream binaryReader.PeekChar() != -1 for MemoryStream  binaryReader.PeekChar() != 0
                    {
                        books.Add(ReadFromStream(binaryReader));
                    }
                }
            }

            return books;
        }
    }
}