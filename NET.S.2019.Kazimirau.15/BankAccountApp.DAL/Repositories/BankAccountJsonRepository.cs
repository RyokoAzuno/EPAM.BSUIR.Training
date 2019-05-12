using BankAccountApp.DAL.Entities;
using BankAccountApp.DAL.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;

namespace BankAccountApp.DAL.Repositories
{
    public class BankAccountJsonRepository : IRepository<BankAccount>
    {
        private readonly string _fullPath;

        public BankAccountJsonRepository()
        {
            _fullPath = ConfigurationManager.AppSettings["JsonStoragePath"];
        }

        public void Create(BankAccount bankAccount)
        {
            if(bankAccount != null)
            {
                if (File.Exists(_fullPath))
                {
                    List<BankAccount> bankAccounts = JsonConvert.DeserializeObject<List<BankAccount>>(File.ReadAllText(_fullPath, Encoding.UTF8));
                    bankAccounts.Add(bankAccount);

                    // !!!!!!!Encoding to UTF8 for cyrillic symbols!!!!!!!!
                    File.WriteAllText(_fullPath, JsonConvert.SerializeObject(bankAccounts, Formatting.Indented), Encoding.UTF8);
                }
                else
                {
                    // !!!!!!!Encoding to UTF8 for cyrillic symbols!!!!!!!!
                    File.WriteAllText(_fullPath, JsonConvert.SerializeObject(bankAccount, Formatting.Indented), Encoding.UTF8);
                }
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public void Delete(int id)
        {
            List<BankAccount> bankAccounts = new List<BankAccount>(GetAll());
            BankAccount bankAccount = bankAccounts.Where(a => a.Id == id).FirstOrDefault();

            if (bankAccount != null)
            {
                bankAccounts.Remove(bankAccount);
                // !!!!!!!Encoding to UTF8 for cyrillic symbols!!!!!!!!
                File.WriteAllText(_fullPath, JsonConvert.SerializeObject(bankAccounts, Formatting.Indented), Encoding.UTF8);
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public IEnumerable<BankAccount> GetAll()
        {
            if (File.Exists(_fullPath))
            {
                List<BankAccount> bankAccounts = JsonConvert.DeserializeObject<List<BankAccount>>(File.ReadAllText(_fullPath, Encoding.UTF8));

                return bankAccounts;
            }
            else
            {
                throw new FileNotFoundException();
            }
        }

        public BankAccount GetById(int id)
        {
            BankAccount bankAccount = GetAll().Where(a => a.Id.Equals(id)).FirstOrDefault();

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
    }
}
