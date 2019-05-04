using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using BankAccountApp.DAL.Entities;
using BankAccountApp.DAL.Interfaces;
using Newtonsoft.Json;

namespace BankAccountApp.DAL.Storages
{
    // Class emulates JSON storage
    public sealed class JsonStorage : IStorage<BankAccount>
    {
        private readonly string _fullPath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\AppData\\" + "BankAccounts.json";
        private List<BankAccount> _storage;

        public JsonStorage(IEnumerable<BankAccount> storage)
        {
            _storage = new List<BankAccount>(storage);
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
