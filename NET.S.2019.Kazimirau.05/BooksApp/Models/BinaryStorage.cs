using BooksApp.Interfaces;
using BooksApp.Loggers;
using System;
using System.Collections.Generic;
using System.IO;

namespace BooksApp.Models
{
    // Class emulates binary storage
    public sealed class BinaryStorage : IStorage<Book>
    {
        private List<Book> _storage;
        private readonly string _fullPath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\AppData\\" + "BooksDB";
        // Constructor
        public BinaryStorage(List<Book> storage)
        {
            _storage = storage;
        }

        /// <summary>
        /// Load from binary file
        /// </summary>
        /// <returns> Collection of books </returns>
        public IEnumerable<Book> Load()
        {
            if (File.Exists(_fullPath))
            {
                _storage.Clear();
                using (FileStream stream = new FileStream(_fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (BinaryReader binaryReader = new BinaryReader(stream))
                    {
                        binaryReader.BaseStream.Seek(0, SeekOrigin.Begin);
                        // Read each value while not EOF
                        while (binaryReader.PeekChar() != -1) // for FileStream binaryReader.PeekChar() != -1 for MemoryStream  binaryReader.PeekChar() != 0
                        {
                            _storage.Add(ReadFromStream(binaryReader));
                        }
                    }
                }

                MyLogger.GetLogger().Info("Binary file was successfully loaded!");

                return _storage;
            }
            else
            {
                MyLogger.GetLogger().Info("Binary file Not Found!");
                throw new FileNotFoundException();
            }
            
        }

        /// <summary>
        /// Save to binary file
        /// </summary>
        public void Save()
        {
            using (FileStream stream = new FileStream(_fullPath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(stream))
                {
                    foreach (var item in _storage)
                    {
                        WriteToStream(binaryWriter, item);
                    }
                }
            }
            MyLogger.GetLogger().Info("Binary file was successfully saved!");
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
            {
                MyLogger.GetLogger().Info("Argument Null Exception!");
                throw new ArgumentNullException();
            }
        }

        // Read all bytes from stream as book item
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
                return new Book
                {
                    Id = id,
                    ISBN = isbn,
                    Author = author,
                    Name = name,
                    Publisher = publisher,
                    Year = year,
                    NumberOfPages = numberOfPages,
                    Price = price
                };
            }
            else
            {
                MyLogger.GetLogger().Info("Argument Null Exception!");
                throw new ArgumentNullException();
            }
        }
    }
}
