using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using UriToXmlExporter.Interfaces;
using UriToXmlExporter.Models;

namespace UriToXmlExporter.Storages
{
    public class XmlStorage : IStorage<UrlAddress>
    {
        private readonly string _path = ConfigurationManager.AppSettings["XmlStoragePath"];
        private List<UrlAddress> _storage;

        public XmlStorage(IEnumerable<UrlAddress> storage)
        {
            _storage = new List<UrlAddress>(storage);
        }

        public IEnumerable<UrlAddress> Load()
        {
            if (File.Exists(_path))
            {
                _storage.Clear();
                XDocument xDoc = XDocument.Load(_path);
                List<string> segments = new List<string>();
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                foreach (XElement urlAddressElement in xDoc.Element("urlAddresses").Elements("urlAddress"))
                {
                    XElement schemeElement = urlAddressElement.Element("scheme");
                    XElement hostElement = urlAddressElement.Element("host");
                    XAttribute nameAttribute = hostElement.Attribute("name");
                    XElement uriElement = urlAddressElement.Element("uri");
                    foreach (var segment in uriElement.Elements("segment"))
                    {
                        segments.Add(segment.Value);
                    }
                    XElement parametersElement = urlAddressElement.Element("parameters");
                    foreach (var item in parametersElement.Elements("parameter"))
                    {
                        parameters.Add(item.Attribute("key").Value, item.Attribute("value").Value);
                    }

                    if (schemeElement != null && hostElement != null)
                    {
                        _storage.Add(new UrlAddress
                        {
                            Scheme = schemeElement.Value,
                            Host = nameAttribute.Value,
                            Segments = segments.ToArray(),
                            Parameters = parameters
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

        public void Save()
        {
            var xEle = new XElement(
                                    "urlAddresses",
                                    _storage.Select(elt => new XElement(
                                                    "urlAddress",
                                                    new XElement("scheme", elt.Scheme),
                                                    new XElement("host", new XAttribute("name", elt.Host)),
                                                    new XElement("uri", elt.Segments.Select(seg => new XElement("segment", seg))),
                                                    new XElement("parameters", new XElement("parameter", elt.Parameters.Select(param => new XAttribute("key", param.Key)),
                                                                               elt.Parameters.Select(param => new XAttribute("value", param.Value)))))));

            // Save Xml document
            xEle.Save(_path);
        }
    }
}
