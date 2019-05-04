using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using BankAccountApp.DAL.Entities;
using BankAccountApp.DAL.Interfaces;

namespace BankAccountApp.DAL.Storages
{
    // Class emulates XML storage
    public sealed class XmlStorage : IStorage<BankAccount>
    {
        //private readonly string _fullPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\AppData\\" + "BankAccounts.xml";
        private readonly string _fullPath = ConfigurationManager.AppSettings["XmlStoragePath"];
        private List<BankAccount> _storage;

        public XmlStorage(IEnumerable<BankAccount> storage)
        {
            _storage = new List<BankAccount>(storage);
        }

        /// <summary>
        /// Load from XML file
        /// </summary>
        /// <returns> Collection of bank accounts </returns>
        public IEnumerable<BankAccount> Load()
        {
            if (File.Exists(_fullPath))
            {
                _storage.Clear();
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
                        _storage.Add(new BankAccount
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

                return _storage;
            }
            else
            {
                throw new FileNotFoundException();
            }
        }

        /// <summary>
        /// Save to XML file
        /// </summary>
        public void Save()
        {
            // Constuct Xml structure
            var xEle = new XElement(
                                    "BankAccounts",
                                    _storage.Select(elt => new XElement(
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
    }
}
