using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using BankAccountApp.DAL.Entities;
using BankAccountApp.DAL.Interfaces;

namespace BankAccountApp.DAL.Storages
{
    // Class emulates binary storage
    public sealed class BinaryStorage : IStorage<BankAccount>
    {
        //private readonly string _fullPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\AppData\\" + "BankAccountsDB";
        private readonly string _fullPath = ConfigurationManager.AppSettings["BinaryStoragePath"];

        private List<BankAccount> _storage;

        // Constructor
        public BinaryStorage(IEnumerable<BankAccount> storage)
        {
            _storage = new List<BankAccount>(storage);
        }

        /// <summary>
        /// Load from binary file
        /// </summary>
        /// <returns> Collection of bank accounts </returns>
        public IEnumerable<BankAccount> Load()
        {
            if (File.Exists(_fullPath))
            {
                _storage.Clear();
                using (FileStream stream = new FileStream(_fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (BinaryReader binaryReader = new BinaryReader(stream))
                    {
                        binaryReader.BaseStream.Seek(0, SeekOrigin.Begin);

                        while (binaryReader.PeekChar() != -1) // for FileStream binaryReader.PeekChar() != -1 for MemoryStream  binaryReader.PeekChar() != 0
                        {
                            _storage.Add(ReadFromStream(binaryReader));
                        }
                    }
                }

                return _storage;
            }
            else
            {
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
        }

        // Write bank account as array of bytes to stream
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

        // Read all bytes from stream as bank account item
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
