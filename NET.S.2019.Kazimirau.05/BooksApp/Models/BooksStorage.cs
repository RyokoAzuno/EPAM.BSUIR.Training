using System;
using System.Collections.Generic;
using System.IO;

namespace BooksApp
{
    // Simple class that emulate books storage database
    public class BooksStorage
    {
        private string _fullPath;
        private List<Book> _books = new List<Book> {
            new Book{ ISBN = "1-61-729453-5", Author = "Jon Skeet", Name = "C# in Depth", NumberOfPages = 528, Price = 43m, Publisher = "Manning Publications", Year = 2019 },
            new Book{ ISBN = "9-78-149198-6", Author = "Joseph Albahari", Name = "C# 7.0 in a Nutshell", NumberOfPages = 1088, Price = 65m, Publisher = "O'Reilly Media", Year = 2017 },
            new Book{ ISBN = "1-48-423017-5", Author = "Andrew Troelsen, Phil Japikse", Name = "Pro C# 7: With .NET and .NET Core", NumberOfPages = 1372, Price = 32.82m, Publisher = "Apress", Year = 2017 },
            new Book{ ISBN = "0-73-566745-4", Author = "Jeffrey Richter", Name = "CLR via C#", NumberOfPages = 896, Price = 49.17m, Publisher = "Microsoft Press", Year = 2012 },
            new Book{ ISBN = "9-78-026203-8", Author = "Thomas Cormen, Ronals Rivest", Name = "Introduction to Algorithms", NumberOfPages = 1320, Price = 87.67m, Publisher = "The MIT Press", Year = 2009 },
        };

        // Constructor
        public BooksStorage()
        {
            _fullPath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\AppData\\" + "BooksDB";

            using (FileStream stream = new FileStream(_fullPath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(stream))
                {
                    foreach (var book in _books)
                    {
                        binaryWriter.Write(book.ISBN);
                        binaryWriter.Write(book.Author);
                        binaryWriter.Write(book.Name);
                        binaryWriter.Write(book.Publisher);
                        binaryWriter.Write(book.Year);
                        binaryWriter.Write(book.NumberOfPages);
                        binaryWriter.Write(book.Price);
                    }
                }
            }
        }
        /// <summary>
        /// Get all books as List
        /// </summary>
        public List<Book> Books
        {
            get
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
                            string isbn = binaryReader.ReadString();
                            string author = binaryReader.ReadString();
                            string name = binaryReader.ReadString();
                            string publisher = binaryReader.ReadString();
                            int year = binaryReader.ReadInt32();
                            int numberOfPages = binaryReader.ReadInt32();
                            decimal price = binaryReader.ReadDecimal();

                            books.Add(new Book { ISBN = isbn, Author = author, Name = name, Publisher = publisher, Year = year, NumberOfPages = numberOfPages, Price = price });
                        }
                    }
                }
                return books;
            }
        }
        // Indexer
        public Book this[int index]
        {
            get
            {
                if (index > -1)
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
                using (FileStream stream = new FileStream(_fullPath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                {
                    using (BinaryWriter binaryWriter = new BinaryWriter(stream))
                    {
                        binaryWriter.Write(book.ISBN);
                        binaryWriter.Write(book.Author);
                        binaryWriter.Write(book.Name);
                        binaryWriter.Write(book.Publisher);
                        binaryWriter.Write(book.Year);
                        binaryWriter.Write(book.NumberOfPages);
                        binaryWriter.Write(book.Price);
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
                using (FileStream stream = new FileStream(_fullPath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
                {
                    using (BinaryWriter binaryWriter = new BinaryWriter(stream))
                    {
                        foreach (var b in books)
                        {
                            binaryWriter.Write(b.ISBN);
                            binaryWriter.Write(b.Author);
                            binaryWriter.Write(b.Name);
                            binaryWriter.Write(b.Publisher);
                            binaryWriter.Write(b.Year);
                            binaryWriter.Write(b.NumberOfPages);
                            binaryWriter.Write(b.Price);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Serialize books as bytes in memory
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
                        binaryWriter.Write(book.ISBN);
                        binaryWriter.Write(book.Author);
                        binaryWriter.Write(book.Name);
                        binaryWriter.Write(book.Publisher);
                        binaryWriter.Write(book.Year);
                        binaryWriter.Write(book.NumberOfPages);
                        binaryWriter.Write(book.Price);
                    }
                }
                //stream.Flush();
                return stream.GetBuffer();
            }

        }
        /// <summary>
        /// Deserialize bytes as List of books
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
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
                        string isbn = binaryReader.ReadString();
                        string author = binaryReader.ReadString();
                        string name = binaryReader.ReadString();
                        string publisher = binaryReader.ReadString();
                        int year = binaryReader.ReadInt32();
                        int numberOfPages = binaryReader.ReadInt32();
                        decimal price = binaryReader.ReadDecimal();

                        books.Add(new Book { ISBN = isbn, Author = author, Name = name, Publisher = publisher, Year = year, NumberOfPages = numberOfPages, Price = price });
                    }
                }
            }

            return books;
        }
        // Sort books
        public void SortByTag(IComparer<Book> tag)
        {
            Books.Sort(tag);
        }

        public override string ToString()
        {
            string result = string.Empty;
            foreach (var book in Books)
            {
                //result += $"ISBN:       {item.ISBN}{Environment.NewLine}";
                //result += $"Author:     {item.Author}{Environment.NewLine}";
                //result += $"Name:       {item.Name}{Environment.NewLine}";
                //result += $"Publisher:  {item.Publisher}{Environment.NewLine}";
                //result += $"Year:       {item.Year}{Environment.NewLine}";
                //result += $"Pages:      {item.NumberOfPages}{Environment.NewLine}";
                //result += $"Price:      {item.Price}{Environment.NewLine}";
                //result += "***********************************************" + Environment.NewLine;
                result += $"{book.ToString()}";
            }

            return result;
        }
    }
}