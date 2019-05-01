using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using BooksApp.Interfaces;
using BooksApp.Models;
using Newtonsoft.Json;

namespace BooksApp.Storages
{
    // Class emulates JSON storage
    public sealed class JsonStorage : IStorage<Book>
    {
        private readonly string _fullPath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\AppData\\" + "BankAccounts.json";
        private List<Book> _storage;

        public JsonStorage(List<Book> storage)
        {
            _storage = storage;
        }

        /// <summary>
        /// Load from JSON file
        /// </summary>
        /// <returns> Collection of books </returns>
        public IEnumerable<Book> Load()
        {
            if (File.Exists(_fullPath))
            {
                _storage.Clear();
                _storage = JsonConvert.DeserializeObject<List<Book>>(File.ReadAllText(_fullPath, Encoding.UTF8));

                return _storage;
            }
            else
            {
                throw new FileNotFoundException();
            }
        }

        /// <summary>
        /// Save to JSON file
        /// </summary>
        public void Save()
        {
            // !!!!!!!Encoding to UTF8 for cyrillic symbols!!!!!!!!
            File.WriteAllText(_fullPath, JsonConvert.SerializeObject(_storage, Formatting.Indented), Encoding.UTF8);
        }
    }
}
