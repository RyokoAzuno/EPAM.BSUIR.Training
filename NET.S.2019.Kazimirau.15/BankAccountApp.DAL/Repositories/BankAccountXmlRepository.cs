using BankAccountApp.DAL.Entities;
using BankAccountApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace BankAccountApp.DAL.Repositories
{
    public class BankAccountXmlRepository : IRepository<BankAccount>
    {
        private readonly string _fullPath;

        public BankAccountXmlRepository()
        {
            _fullPath = ConfigurationManager.AppSettings["XmlStoragePath"];
        }

        public void Create(BankAccount bankAccount)
        {
            if(bankAccount != null)
            {
                List<BankAccount> bankAccounts = null;

                if (File.Exists(_fullPath))
                {
                    bankAccounts = LoadFromXml().ToList();
                    bankAccounts.Add(bankAccount);
                    SaveToXml(bankAccounts);
                }
                else
                {
                    bankAccounts = new List<BankAccount>();
                    bankAccounts.Add(bankAccount);
                }
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public void Delete(int id)
        {
            List<BankAccount> bankAccounts = new List<BankAccount>(LoadFromXml());
            BankAccount bankAccount = bankAccounts.Where(a => a.Id == id).FirstOrDefault();

            if (bankAccount != null)
            {
                bankAccounts.Remove(bankAccount);
                SaveToXml(bankAccounts);                
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public IEnumerable<BankAccount> GetAll()
        {
            return LoadFromXml();
        }

        public BankAccount GetById(int id)
        {
            BankAccount bankAccount = LoadFromXml().Where(a => a.Id.Equals(id)).FirstOrDefault();

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

        private IEnumerable<BankAccount> LoadFromXml()
        {
            if (File.Exists(_fullPath))
            {
                List<BankAccount> bankAccounts = new List<BankAccount>();
                XDocument xDoc = XDocument.Load(_fullPath);
                foreach (XElement bankAccountElement in xDoc.Element("BankAccounts").Elements("BankAccount"))
                {
                    XAttribute idAttribute = bankAccountElement.Attribute("Id");
                    XElement firstNameElement = bankAccountElement.Element("FirstName");
                    XElement secondNameElement = bankAccountElement.Element("SecondName");
                    XElement balanceElement = bankAccountElement.Element("Balance");
                    XElement pointsElement = bankAccountElement.Element("BonusPoints");
                    XElement typeElement = bankAccountElement.Element("Type");
                    XElement statusElement = bankAccountElement.Element("Status");

                    if (idAttribute != null && firstNameElement != null && secondNameElement != null &&
                        balanceElement != null && pointsElement != null && typeElement != null && statusElement != null)
                    {
                        bankAccounts.Add(new BankAccount
                        {
                            Id = int.Parse(idAttribute.Value),
                            FirstName = firstNameElement.Value,
                            SecondName = secondNameElement.Value,
                            Balance = decimal.Parse(balanceElement.Value, new CultureInfo("en-US")),
                            BonusPoints = int.Parse(pointsElement.Value),
                            Type = (AccountType)Enum.Parse(typeof(AccountType), typeElement.Value),
                            IsOpened = bool.Parse(statusElement.Value)
                        });
                    }
                }

                return bankAccounts;
            }
            else
            {
                throw new FileNotFoundException();
            }
        }

        private void SaveToXml(List<BankAccount> bankAccounts)
        {
            // Constuct Xml structure
            var xEle = new XElement(
                                    "BankAccounts",
                                    bankAccounts.Select(elt => new XElement(
                                                    "BankAccount",
                                                    new XAttribute("Id", elt.Id),
                                                    new XElement("FirstName", elt.FirstName),
                                                    new XElement("SecondName", elt.SecondName),
                                                    new XElement("Balance", elt.Balance),
                                                    new XElement("BonusPoints", elt.BonusPoints),
                                                    new XElement("Type", elt.Type),
                                                    new XElement("Status", elt.IsOpened))));

            // Save Xml document
            xEle.Save(_fullPath);
        }

        //public void Create(BankAccount bankAccount)
        //{
        //    if (bankAccount != null)
        //    {
        //        if (File.Exists(_fullPath))
        //        {
        //            List<BankAccount> bankAccounts = null;
        //            XmlSerializer xs = new XmlSerializer(typeof(BankAccount[]));
        //            using (Stream stream = File.OpenRead(_fullPath))
        //            {
        //                BankAccount[] accs = (BankAccount[])xs.Deserialize(stream);
        //                bankAccounts = accs.ToList();
        //            }

        //            bankAccounts.Add(bankAccount);

        //            using (Stream stream = File.Create(_fullPath))
        //            {
        //                xs.Serialize(stream, bankAccounts.ToArray());
        //            }
        //        }
        //        else
        //        {
        //            XmlSerializer xs = new XmlSerializer(typeof(BankAccount));
        //            using (Stream stream = File.Create(_fullPath))
        //            {
        //                xs.Serialize(stream, bankAccount);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        throw new NullReferenceException();
        //    }
        //}

        //public void Delete(int id)
        //{
        //    BankAccount bankAccount = GetById(id);

        //    if (bankAccount != null)
        //    {
        //        List<BankAccount> bankAccounts = GetAll().ToList();
        //        bankAccounts.Remove(bankAccount);

        //        XmlSerializer xs = new XmlSerializer(typeof(BankAccount[]));
        //        using (Stream stream = File.Create(_fullPath))
        //        {
        //            xs.Serialize(stream, bankAccounts.ToArray());
        //        }
        //    }
        //    else
        //    {
        //        throw new NullReferenceException();
        //    }
        //}

        //public IEnumerable<BankAccount> GetAll()
        //{
        //    if (File.Exists(_fullPath))
        //    {
        //        List<BankAccount> bankAccounts = null;
        //        XmlSerializer xs = new XmlSerializer(typeof(BankAccount[]));
        //        using (Stream stream = File.OpenRead(_fullPath))
        //        {
        //            bankAccounts = ((BankAccount[])xs.Deserialize(stream)).ToList();
        //        }

        //        return bankAccounts;
        //    }
        //    else
        //    {
        //        throw new FileNotFoundException();
        //    }
        //}

        //public BankAccount GetById(int id)
        //{
        //    BankAccount bankAccount = GetAll().Where(a => a.Id.Equals(id)).FirstOrDefault();

        //    if (bankAccount != null)
        //    {
        //        return bankAccount;
        //    }

        //    throw new NullReferenceException();
        //}

        //public void Update(BankAccount bankAccount)
        //{
        //    if (bankAccount != null)
        //    {
        //        Delete(bankAccount.Id);
        //        Create(bankAccount);
        //    }
        //    else
        //    {
        //        throw new NullReferenceException();
        //    }
        //}
    }
}
