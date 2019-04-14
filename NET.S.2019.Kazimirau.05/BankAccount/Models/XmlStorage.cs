using BankAccount.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace BankAccount.Services
{
    // Class emulates XML storage
    public sealed class XmlStorage : IStorage<BankAccount>
    {
        private List<BankAccount> _storage;
        private readonly string _fullPath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\AppData\\" + "BankAccounts.xml";

        public XmlStorage(List<BankAccount> storage)
        {
            _storage = storage;
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
                    XElement ownerElement = bankAccountElement.Element("Owner");
                    XElement balanceElement = bankAccountElement.Element("Balance");
                    XElement pointsElement = bankAccountElement.Element("Points");
                    XElement typeElement = bankAccountElement.Element("Type");
                    XElement statusElement = bankAccountElement.Element("Status");

                    if (idAttribute != null && ownerElement != null && 
                        balanceElement != null && pointsElement != null &&
                        typeElement != null && statusElement != null)
                    {
                        _storage.Add(new BankAccount
                        {
                            Id = int.Parse(idAttribute.Value),
                            Owner = ownerElement.Value,
                            Balance = decimal.Parse(balanceElement.Value, new CultureInfo("en-US")),
                            Points = int.Parse(pointsElement.Value),
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
            var xEle = new XElement("BankAccounts",
                _storage.Select(elt => new XElement("BankAccount",
                                                    new XAttribute("Id", elt.Id),
                                                    new XElement("Owner", elt.Owner),
                                                    new XElement("Balance", elt.Balance),
                                                    new XElement("Points", elt.Points),
                                                    new XElement("Type", elt.Type),
                                                    new XElement("Status", elt.IsOpened))));
            // Save Xml document
            xEle.Save(_fullPath);
        }
    }
}
