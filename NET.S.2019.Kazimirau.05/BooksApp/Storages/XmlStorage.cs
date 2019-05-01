using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using BooksApp.Interfaces;
using BooksApp.Models;

namespace BooksApp.Storages
{
    // Class emulates XML storage
    public sealed class XmlStorage : IStorage<Book>
    {
        private readonly string _fullPath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\AppData\\" + "BankAccounts.xml";
        private List<Book> _storage;

        public XmlStorage(List<Book> storage)
        {
            _storage = storage;
        }

        /// <summary>
        /// Load from XML file
        /// </summary>
        /// <returns> Collection of bank accounts </returns>
        public IEnumerable<Book> Load()
        {
            if (File.Exists(_fullPath))
            {
                _storage.Clear();
                XDocument xDoc = XDocument.Load(_fullPath);
                foreach (XElement bankAccountElement in xDoc.Element("Books").Elements("Book"))
                {
                    XAttribute idAttribute = bankAccountElement.Attribute("Id");
                    XElement isbnElement = bankAccountElement.Element("ISBN");
                    XElement authorElement = bankAccountElement.Element("Author");
                    XElement nameElement = bankAccountElement.Element("Name");
                    XElement publisherElement = bankAccountElement.Element("Publisher");
                    XElement yearElement = bankAccountElement.Element("Year");
                    XElement pagesElement = bankAccountElement.Element("Pages");
                    XElement priceElement = bankAccountElement.Element("Price");

                    if (idAttribute != null && isbnElement != null &&
                        authorElement != null && nameElement != null &&
                        publisherElement != null && yearElement != null &&
                        pagesElement != null && priceElement != null)
                    {
                        _storage.Add(new Book
                        {
                            Id = int.Parse(idAttribute.Value),
                            ISBN = isbnElement.Value,
                            Author = authorElement.Value,
                            Name = nameElement.Value,
                            Publisher = publisherElement.Value,
                            Year = int.Parse(yearElement.Value),
                            NumberOfPages = int.Parse(pagesElement.Value),
                            Price = decimal.Parse(priceElement.Value, new CultureInfo("en-US")),
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
                                    "Books",
                                    _storage.Select(elt => new XElement(
                                                    "Book",
                                                    new XAttribute("Id", elt.Id),
                                                    new XElement("ISBN", elt.ISBN),
                                                    new XElement("Author", elt.Author),
                                                    new XElement("Name", elt.Name),
                                                    new XElement("Publisher", elt.Publisher),
                                                    new XElement("Year", elt.Year),
                                                    new XElement("Pages", elt.NumberOfPages),
                                                    new XElement("Price", elt.Price))));
            //// Save Xml document
            xEle.Save(_fullPath);
        }
    }
}
