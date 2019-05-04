using BankAccountApp.DAL.Entities;
using BankAccountApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace BankAccountApp.DAL.Storages
{
    public sealed class MemoryStorage : IStorage<BankAccount>
    {
        private List<BankAccount> _bankAccounts;
        private byte[] _storage;

        public MemoryStorage()
        {
            _bankAccounts = new List<BankAccount>();
        }

        // Constructor
        public MemoryStorage(List<BankAccount> bankAccounts)
        {
            _bankAccounts = bankAccounts;
        }

        /// <summary>
        /// Deserialize bytes as List of books
        /// </summary>
        public IEnumerable<BankAccount> Load()
        {
            if(_storage == null)
            {
                throw new Exception("Can't load!. Memory storage is null or empty!");
            }

            using (MemoryStream stream = new MemoryStream(_storage))
            {
                using (BinaryReader binaryReader = new BinaryReader(stream))
                {
                    // Read each value while not EOF
                    while (binaryReader.PeekChar() != 0)
                    {
                        _bankAccounts.Add(ReadFromStream(binaryReader));
                    }
                }
            }

            return _bankAccounts;
        }

        /// <summary>
        /// Serialize books in memory as array of bytes
        /// </summary>
        public void Save()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(stream))
                {
                    foreach (var bankAccount in _bankAccounts)
                    {
                        WriteToStream(binaryWriter, bankAccount);
                    }
                }

                _storage = stream.GetBuffer();
            }
        }

        // Write book as array of bytes to stream
        private void WriteToStream(BinaryWriter binaryWriter, BankAccount bankAccount)
        {
            if (bankAccount != null && binaryWriter != null)
            {
                binaryWriter.Write(bankAccount.Id);
                binaryWriter.Write(bankAccount.FirstName);
                binaryWriter.Write(bankAccount.SecondName);
                binaryWriter.Write(bankAccount.Balance);
                binaryWriter.Write(bankAccount.BonusPoints);
                binaryWriter.Write((int)bankAccount.Type);
                binaryWriter.Write(bankAccount.IsOpened);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        // Read all bytes from stream as Book
        private BankAccount ReadFromStream(BinaryReader binaryReader)
        {
            if (binaryReader != null)
            {
                int id = binaryReader.ReadInt32();
                string firstName = binaryReader.ReadString();
                string secondName = binaryReader.ReadString();
                decimal balance = binaryReader.ReadDecimal();
                int bonusPoints = binaryReader.ReadInt32();
                AccountType type = (AccountType)binaryReader.ReadInt32();
                bool isOpened = binaryReader.ReadBoolean();

                return new BankAccount
                {
                    Id = id,
                    FirstName = firstName,
                    SecondName = secondName,
                    Balance = balance,
                    BonusPoints = bonusPoints,
                    Type = type,
                    IsOpened = isOpened
                };
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
    }
}
