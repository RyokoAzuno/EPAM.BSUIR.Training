using BankAccount.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BankAccount.Services
{
    // Class emulates JSON storage
    public sealed class JsonStorage : IStorage<BankAccount>
    {
        private List<BankAccount> _storage;
        private readonly string _fullPath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\AppData\\" + "BankAccounts.json";

        public JsonStorage(List<BankAccount> storage)
        {
            _storage = storage;
        }

        /// <summary>
        /// Load from JSON file
        /// </summary>
        /// <returns> Collection of bank accounts </returns>
        public IEnumerable<BankAccount> Load()
        {
            if (File.Exists(_fullPath))
            {
                _storage.Clear();
                _storage = JsonConvert.DeserializeObject<List<BankAccount>>(File.ReadAllText(_fullPath, Encoding.UTF8));

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
