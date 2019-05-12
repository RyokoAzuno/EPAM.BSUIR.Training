using BankAccountApp.DAL.Entities;
using BankAccountApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace BankAccountApp.DAL.Repositories
{
    public class BankAccountBinaryRepository : IRepository<BankAccount>
    {
        private readonly string _fullPath;

        public BankAccountBinaryRepository()
        {
            _fullPath = ConfigurationManager.AppSettings["BinaryStoragePath"];
        }

        public void Create(BankAccount bankAccount)
        {
            if(bankAccount != null)
            {
                List<BankAccount> bankAccounts = new List<BankAccount>(LoadFromBinaryFile());
                bankAccounts.Add(bankAccount);
                SaveToBinaryFile(bankAccounts);
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public void Delete(int id)
        {
            BankAccount bankAccount = GetById(id);

            if (bankAccount != null)
            {
                List<BankAccount> bankAccounts = new List<BankAccount>(LoadFromBinaryFile());
                //bankAccounts.Remove(bankAccount); !!!!!!!!!!!!!!!!!!!!!!!!!! Not working
                bankAccounts.Remove(bankAccounts.Where(a => a.Id == id).FirstOrDefault());
                SaveToBinaryFile(bankAccounts);
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public IEnumerable<BankAccount> GetAll()
        {
            return LoadFromBinaryFile();
        }

        public BankAccount GetById(int id)
        {
            BankAccount bankAccount = LoadFromBinaryFile().Where(a => a.Id.Equals(id)).FirstOrDefault();

            if(bankAccount != null)
            {
                return bankAccount;
            }

            throw new NullReferenceException();
        }

        public void Update(BankAccount bankAccount)
        {
            if (bankAccount != null)
            {
                Delete(bankAccount.Id);
                Create(bankAccount);
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        /// <summary>
        /// Save to binary file
        /// </summary>
        private void SaveToBinaryFile(List<BankAccount> bankAccounts)
        {
            using (FileStream stream = new FileStream(_fullPath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(stream))
                {
                    foreach (var item in bankAccounts)
                    {
                        WriteToStream(binaryWriter, item);
                    }
                }
            }
        }

        /// <summary>
        /// Load from binary file
        /// </summary>
        /// <returns> Collection of bank accounts </returns>
        public IEnumerable<BankAccount> LoadFromBinaryFile()
        {
            if (File.Exists(_fullPath))
            {
                List<BankAccount> bankAccounts = new List<BankAccount>();
                using (FileStream stream = new FileStream(_fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (BinaryReader binaryReader = new BinaryReader(stream))
                    {
                        binaryReader.BaseStream.Seek(0, SeekOrigin.Begin);

                        while (binaryReader.PeekChar() != -1) // for FileStream binaryReader.PeekChar() != -1 for MemoryStream  binaryReader.PeekChar() != 0
                        {
                            bankAccounts.Add(ReadFromStream(binaryReader));
                        }
                    }
                }

                return bankAccounts;
            }
            else
            {
                throw new FileNotFoundException();
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
